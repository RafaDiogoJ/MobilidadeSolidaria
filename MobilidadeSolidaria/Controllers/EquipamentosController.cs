using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MobilidadeSolidaria.Data;
using MobilidadeSolidaria.Models;
using MobilidadeSolidaria.ViewModels;
using System.Security.Claims;

namespace MobilidadeSolidaria.Controllers
{
    public class EquipamentosController : Controller
    {
        private readonly AppDbContext _context;

        public EquipamentosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Cadastro()
        {
            ViewBag.Categorias = _context.Categoria
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                }).ToList();

            var vm = new CadastroEquipamentoVM();
            return View(vm);
        }



        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(CadastroEquipamentoVM vm, List<IFormFile> fotos)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _context.Categoria
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome
                    }).ToList();

                return View(vm);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var categoria = await _context.Categoria.FindAsync(vm.CategoriaId);

            if (categoria == null)
            {
                ModelState.AddModelError("CategoriaId", "Categoria inválida");
                ViewBag.Categorias = _context.Categoria
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome
                    }).ToList();
                return View(vm);
            }

            var equipamento = new Equipamento
            {
                Nome = vm.Nome,
                Descricao = vm.Descricao,
                Categoria = categoria,
                UsuarioId = userId,
                Fotos = new List<EquipamentoFoto>(),
                Status = vm.Status
            };

            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "equipamentos");
            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            if (fotos != null && fotos.Any())
            {
                foreach (var foto in fotos)
                {
                    if (foto.Length > 0)
                    {
                        var nomeArquivo = Guid.NewGuid() + Path.GetExtension(foto.FileName);
                        var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            await foto.CopyToAsync(stream);
                        }

                        equipamento.Fotos.Add(new EquipamentoFoto
                        {
                            ArquivoFoto = "/imagens/equipamentos/" + nomeArquivo
                        });
                    }
                }
            }

            _context.Equipamentos.Add(equipamento);
            await _context.SaveChangesAsync();

            TempData["Mensagem"] = "Equipamento cadastrado com sucesso!";
            return RedirectToAction("Index", "Home");
        }




        // GET: Equipamentos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Equipamentos.Include(e => e.Categoria).Include(e => e.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Disponiveis()
        {
            var equipamentosDisponiveis = await _context.Equipamentos
                .Where(e => e.Status != StatusEquipamento.Indisponivel)
                .Include(e => e.Fotos)  // Incluindo as fotos dos equipamentos
                .ToListAsync();

            return View(equipamentosDisponiveis);
        }



        // GET: Equipamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamentos
                .Include(e => e.Categoria)
                .Include(e => e.Usuario)
                .Include(e => e.Fotos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // GET: Equipamentos/Create
        public IActionResult Create()
        {
            var categorias = _context.Categoria
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                }).ToList();

            ViewBag.Categorias = categorias;

            return View();
        }


        // POST: Equipamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Status,Cidade,Estado,UsuarioId,CategoriaId")] Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", equipamento.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", equipamento.UsuarioId);
            return View(equipamento);
        }

        // GET: Equipamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamentos.FindAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", equipamento.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", equipamento.UsuarioId);
            ViewBag.Categorias = new SelectList(_context.Categoria, "Id", "Nome", equipamento.CategoriaId);

            return View(equipamento);
        }

        // POST: Equipamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Status,Cidade,Estado,UsuarioId,CategoriaId")] Equipamento equipamento)
        {
            if (id != equipamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamentoExists(equipamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", equipamento.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", equipamento.UsuarioId);
            return View(equipamento);
        }

        // GET: Equipamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamentos
                .Include(e => e.Categoria)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // POST: Equipamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);
            if (equipamento != null)
            {
                _context.Equipamentos.Remove(equipamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamentoExists(int id)
        {
            return _context.Equipamentos.Any(e => e.Id == id);
        }
    }
}

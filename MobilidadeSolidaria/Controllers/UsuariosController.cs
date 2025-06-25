using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobilidadeSolidaria.Data;
using MobilidadeSolidaria.Models;

namespace MobilidadeSolidaria.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public UsuariosController(UserManager<Usuario> userManager, AppDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // LISTA DE USUÁRIOS
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // DETALHES DO USUÁRIO
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        // CRIAR USUÁRIO
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,DataNascimento,Foto,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // EDITAR USUÁRIO
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nome,DataNascimento,Foto,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Usuario usuario)
        {
            if (id != usuario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Usuarios.Any(e => e.Id == usuario.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // EXCLUIR USUÁRIO
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        // LISTAR EQUIPAMENTOS DO USUÁRIO LOGADO
        public async Task<IActionResult> Equipamentos()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var equipamentos = await _context.Equipamentos
                .Include(e => e.Fotos)
                .Where(e => e.UsuarioId == usuario.Id)
                .ToListAsync();

            return View("Equipamentos/Index", equipamentos);
        }

        // GET: Usuarios/Equipamentos/Editar/5
        [HttpGet]
        public async Task<IActionResult> EditarEquipamento(int? id)
        {
            if (id == null) return NotFound();

            var equipamento = await _context.Equipamentos
                .Include(e => e.Fotos)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipamento == null) return NotFound();

            ViewBag.Categorias = new SelectList(_context.Categoria, "Id", "Nome", equipamento.CategoriaId);
            return View("Equipamentos/Editar", equipamento);
        }

        // POST: Usuarios/Equipamentos/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarEquipamento(Equipamento equipamento, List<IFormFile> fotos)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = new SelectList(_context.Categoria, "Id", "Nome", equipamento.CategoriaId);
                return View("Equipamentos/Editar", equipamento);
            }

            try
            {
                var usuario = await _userManager.GetUserAsync(User);
                equipamento.UsuarioId = usuario.Id;

                _context.Update(equipamento);
                await _context.SaveChangesAsync();

                // Salvar novas fotos, se houver
                if (fotos != null && fotos.Any())
                {
                    var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "equipamentos");

                    if (!Directory.Exists(caminhoPasta))
                        Directory.CreateDirectory(caminhoPasta);

                    foreach (var foto in fotos)
                    {
                        if (foto.Length > 0)
                        {
                            var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
                            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                            using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                            await foto.CopyToAsync(stream);

                            var novaFoto = new EquipamentoFoto
                            {
                                EquipamentoId = equipamento.Id,
                                ArquivoFoto = "/imagens/equipamentos/" + nomeArquivo
                            };

                            _context.Add(novaFoto);
                        }
                    }

                    await _context.SaveChangesAsync();
                }

                TempData["Mensagem"] = "Equipamento atualizado com sucesso!";
                return RedirectToAction("Equipamentos");
            }
            catch
            {
                return View("Equipamentos/Editar", equipamento);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobilidadeSolidaria.Data;
using MobilidadeSolidaria.Models;
using System.Diagnostics;
using MobilidadeSolidaria.ViewModels;

namespace MobilidadeSolidaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Action para a página inicial (equipamentos)
        public IActionResult Index(int i = 0)
        {
            int equipamentosPorSlide = 10;

            // Obter a lista de equipamentos disponíveis para exibição na página inicial
            var equipamentos = _context.Equipamentos
                .Include(e => e.Fotos)  // Incluindo as fotos dos equipamentos
                .Where(e => e.Status != StatusEquipamento.Indisponivel)  // Excluindo equipamentos com status "Indisponível"
                .Skip(i * equipamentosPorSlide)  // Paginação
                .Take(equipamentosPorSlide)  // Limita a quantidade de equipamentos por página
                .ToList();

            // Passando a lista de equipamentos diretamente para a view
            return View(equipamentos);
        }

        // Action para exibir os detalhes de um equipamento
        public IActionResult Equipamento(int id)
        {
            // Buscando o equipamento específico
            var equipamento = _context.Equipamentos
                .Include(e => e.Fotos)  // Incluindo as fotos
                .Include(e => e.Categoria)  // Incluindo a categoria
                .FirstOrDefault(e => e.Id == id);

            // Se o equipamento não for encontrado, retorna erro 404 (Not Found)
            if (equipamento == null)
            {
                return NotFound();
            }

            // Obtendo a lista de todos os equipamentos
            var equipamentos = _context.Equipamentos
                .Include(e => e.Fotos)  // Incluindo as fotos de todos os equipamentos
                .Where(e => e.Status != StatusEquipamento.Indisponivel)  // Excluindo equipamentos com status "Indisponível"
                .ToList();

            // Passando os dados diretamente para a view (não usa ViewModel)
            ViewData["Equipamento"] = equipamento;
            ViewData["Equipamentos"] = equipamentos;

            // Retorna a View
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

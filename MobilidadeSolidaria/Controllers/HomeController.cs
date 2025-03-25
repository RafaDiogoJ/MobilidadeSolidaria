using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobilidadeSolidaria.Data;
using MobilidadeSolidaria.Models;

namespace MobilidadeSolidaria.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
    var equipamentosController = new EquipamentosController(_context);
    var equipamentos = equipamentosController.ObterEquipamentosDisponiveis();
    
    return View(equipamentos);

        // var equipamentos = _context.Equipamentos
        //         .Include(e => e.Fotos) // Incluindo as fotos dos equipamentos
        //         .Where(e => e.Status != StatusEquipamento.Indisponivel) // Garantindo que o status não seja 'Indisponível'
        //         .ToList();
        // return View(equipamentos); // Passando os equipamentos para a View
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

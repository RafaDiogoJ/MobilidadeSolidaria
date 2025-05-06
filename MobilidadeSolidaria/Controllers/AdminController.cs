using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilidadeSolidaria.Data;


namespace MobilidadeSolidaria.Controllers;

[Authorize(Roles = "Administrador")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context, ILogger<AdminController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var totalUsuarios = _context.Usuarios.Count(); // Tabela de usuários
        var totalEquipamentosDisponiveis = _context.Equipamentos
            .Count(e => e.Status == Models.StatusEquipamento.Doacao || e.Status == Models.StatusEquipamento.Emprestimo);
        var totalEquipamentosIndisponiveis = _context.Equipamentos
            .Count(e => e.Status == Models.StatusEquipamento.Indisponivel);

        ViewBag.TotalUsuarios = totalUsuarios;
        ViewBag.TotalEquipamentos = totalEquipamentosDisponiveis;
        ViewBag.TotalIndisponiveis = totalEquipamentosIndisponiveis;



        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
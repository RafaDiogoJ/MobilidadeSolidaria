using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobilidadeSolidaria.Models;
using MobilidadeSolidaria.Data;

namespace MobilidadeSolidaria.Controllers
{
    public class EquipamentosController : Controller
{
    private readonly AppDbContext _context;

    public EquipamentosController(AppDbContext context)
    {
        _context = context;
    }

    public List<Equipamento> ObterEquipamentosDisponiveis()
    {
        return _context.Equipamentos
            .Include(e => e.Fotos)
            .Where(e => e.Status != StatusEquipamento.Indisponivel)
            .ToList();
    }
}
}
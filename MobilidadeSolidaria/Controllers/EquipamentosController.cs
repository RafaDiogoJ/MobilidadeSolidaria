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

        public async Task<IActionResult> Index()
        {
            var equipamentos = await _context.Equipamentos
                .Include(e => e.Fotos) // Incluindo as fotos dos equipamentos
                .Where(e => e.Status != StatusEquipamento.Indisponivel) // Garantindo que o status não seja 'Indisponível'
                .ToListAsync();

            return View(equipamentos); // Passando os equipamentos para a View
        }


    }
}
using Microsoft.AspNetCore.Mvc;
using MobilidadeSolidaria.Models;
using MobilidadeSolidaria.ViewModels;

namespace MobilidadeSolidaria.Controllers
{
    public class UsuarioController : Controller
    {
        // Ação para exibir o formulário de cadastro
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        // Ação para processar o cadastro (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(CadastroUsuarioVM model)
        {
            if (ModelState.IsValid)
            {
                // Lógica para cadastrar o usuário no banco de dados (a ser implementada)
                // Exemplo de salvar no banco ou realizar outras ações:
                // _usuarioService.CadastrarUsuario(model);

                TempData["SuccessMessage"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Login", "Usuario"); // Ou para outra página
            }

            // Se a validação falhar, retornar para a mesma página com os erros
            return View(model);
        }
    }
}

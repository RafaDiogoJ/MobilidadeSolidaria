using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobilidadeSolidaria.Models;
using MobilidadeSolidaria.ViewModels;
using System.Net.Mail;
using System.Security.Claims;
using MobilidadeSolidaria.Data;
using MobilidadeSolidaria.Helpers;
using Microsoft.AspNetCore.Authorization;


namespace MobilidadeSolidaria.Controllers;
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly UserManager<Usuario> _userManager;
    private readonly IWebHostEnvironment _host;
    private readonly AppDbContext _db;

    public AccountController(
        ILogger<AccountController> logger,
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager,
        IWebHostEnvironment host,
        AppDbContext db
    )
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _host = host;
        _db = db;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        LoginVM login = new()
        {
            UrlRetorno = returnUrl ?? Url.Content("~/")
        };
        return View(login);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (ModelState.IsValid)
        {
            string userName = login.Email;
            if (IsValidEmail(login.Email))
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user != null)
                    userName = user.UserName;
            }

            var result = await _signInManager.PasswordSignInAsync(
                userName, login.Senha, login.Lembrar, lockoutOnFailure: true
            );

            if (result.Succeeded)
            {
                _logger.LogInformation($"Usuário {login.Email} acessou o sistema");
                return LocalRedirect(login.UrlRetorno);
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning($"Usuário {login.Email} esta bloqueado");
                ModelState.AddModelError("", "Sua conta está bloqueada, aguarda alguns minutos e tente novamente");
            }
            else
            if (result.IsNotAllowed)
            {
                _logger.LogWarning($"Usuário {login.Email} não confirmou sua conta");
                ModelState.AddModelError(string.Empty, "Sua conta não esta confirmada, verifique seu email!");
            }
            else
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!");
        }
        return View(login);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        _logger.LogInformation($"Usuário {ClaimTypes.Email} fez logoff");
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Registro()
    {
        RegistroVM register = new();
        return View(register);
    }

    // Método para usuário gerenciar o próprio perfil

    [Authorize]
    public async Task<IActionResult> Perfil()
    {
        var user = await _userManager.GetUserAsync(User);

        var vm = new PerfilVM
        {
            Nome = user.Nome,
            Email = user.Email,
            FotoUrl = user.Foto,
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Perfil(PerfilVM vm)
    {
        var usuario = await _userManager.GetUserAsync(User);

        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        usuario.Nome = vm.Nome;
        // Se o email foi alterado
        if (usuario.Email != vm.Email)
        {
            var setEmailResult = await _userManager.SetEmailAsync(usuario, vm.Email);
            var setUserNameResult = await _userManager.SetUserNameAsync(usuario, vm.Email);

            if (!setEmailResult.Succeeded || !setUserNameResult.Succeeded)
            {
                ModelState.AddModelError("", "Erro ao atualizar email.");
                return View(vm);
            }
        }
        usuario.UserName = vm.Email;
        if (!string.IsNullOrEmpty(vm.SenhaAtual) && !string.IsNullOrEmpty(vm.NovaSenha))
        {
            var resultSenha = await _userManager.ChangePasswordAsync(usuario, vm.SenhaAtual, vm.NovaSenha);
            if (!resultSenha.Succeeded)
            {
                foreach (var error in resultSenha.Errors)
                {
                    ModelState.AddModelError("", TranslateIdentityErrors.TranslateErrorMessage(error.Code));
                }
                return View(vm);
            }
        }


        if (vm.Foto != null)
        {
            string nomeArquivo = usuario.Id + Path.GetExtension(vm.Foto.FileName);
            string caminho = Path.Combine(_host.WebRootPath, @"images\usuarios");
            string novoArquivo = Path.Combine(caminho, nomeArquivo);

            using (var stream = new FileStream(novoArquivo, FileMode.Create))
            {
                vm.Foto.CopyTo(stream);
            }

            usuario.Foto = @"\images\usuarios\" + nomeArquivo;

            await _db.SaveChangesAsync();
        }

        await _userManager.UpdateAsync(usuario);

        TempData["Success"] = "Perfil atualizado com sucesso!";
        return RedirectToAction("Editar");
    }




    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Registro(RegistroVM registro)
    {
        if (ModelState.IsValid)
        {
            var usuario = Activator.CreateInstance<Usuario>();
            usuario.Nome = registro.Nome;
            usuario.DataNascimento = registro.DataNascimento;
            usuario.UserName = registro.Email;
            usuario.NormalizedUserName = registro.Email.ToUpper();
            usuario.Email = registro.Email;
            usuario.PhoneNumber = registro.PhoneNumber;
            usuario.NormalizedEmail = registro.Email.ToUpper();
            usuario.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(usuario, registro.Senha);

            if (result.Succeeded)
            {
                _logger.LogInformation($"Novo usuário registrado com o email {registro.Email}.");

                await _userManager.AddToRoleAsync(usuario, "Cliente");

                if (registro.Foto != null)
                {
                    string nomeArquivo = usuario.Id + Path.GetExtension(registro.Foto.FileName);
                    string caminho = Path.Combine(_host.WebRootPath, @"images\usuarios");
                    string novoArquivo = Path.Combine(caminho, nomeArquivo);
                    using (var stream = new FileStream(novoArquivo, FileMode.Create))
                    {
                        registro.Foto.CopyTo(stream);
                    }
                    usuario.Foto = @"\images\usuarios\" + nomeArquivo;
                    await _db.SaveChangesAsync();
                }

                // Loga o usuário automaticamente após o registro
                await _signInManager.SignInAsync(usuario, isPersistent: false);

                TempData["Success"] = "Conta criada com Sucesso!";
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, TranslateIdentityErrors.TranslateErrorMessage(error.Code));
        }
        return View(registro);
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    public bool IsValidEmail(string email)
    {
        try
        {
            MailAddress m = new(email);
            return true;
        }
        catch (FormatException)
        {

            return false;
        }
    }
}
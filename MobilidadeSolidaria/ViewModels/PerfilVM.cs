using System.ComponentModel.DataAnnotations;
namespace MobilidadeSolidaria.ViewModels
{
    public class PerfilVM
    {

        [Display(Name = "Nome Completo", Prompt = "Informe seu nome completo")]
        [Required(ErrorMessage = "Por favor, informe seu nome")]
        [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
        public string Nome { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string SenhaAtual { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha de acesso", Prompt = "Informe sua senha para acesso")]
        [Required(ErrorMessage = "Por favor, informe sua senha de acesso")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve possuir no mínimo 6 e no máximo 20 caracteres")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha de acesso", Prompt = "Confirme sua senha de acesso")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmacaoNovaSenha { get; set; }

        public IFormFile Foto { get; set; }

        public string FotoUrl { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MobilidadeSolidaria.ViewModels;

    public class RegistroVM
    {
        [Display(Name="Nome Completo", Prompt = "Informe seu nome completo")]
        [Required(ErrorMessage ="Por favor, informe seu nome")]
        [StringLength(60, ErrorMessage ="O nome deve possuir no máximo 60 caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Data de nascimento", Prompt = "Informe sua data de nascimento")]
        [Required(ErrorMessage ="Por favor, informe sua data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Prompt = "Informe seu Email")]
        [Required(ErrorMessage ="Por favor, informe seu Email")]
        [EmailAddress(ErrorMessage ="Por favor, informe um Email válido")]
        [StringLength(100, ErrorMessage ="O Email deve possuir no máximo 100 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Informe seu Telefone")]
        [Required(ErrorMessage ="Por favor, informe seu Telefone")]
        [Phone(ErrorMessage ="Por favor, informe um Telefone válido")]
        [StringLength(15, ErrorMessage ="O telefone deve possuir no máximo 15 caracteres")]
        public string PhoneNumber { get; set;}

        [DataType(DataType.Password)]
        [Display(Name="Senha de acesso", Prompt = "Informe sua senha para acesso")]
        [Required(ErrorMessage ="Por favor, informe sua senha de acesso")]
        [StringLength(20, MinimumLength =6 , ErrorMessage ="A senha deve possuir no mínimo 6 e no máximo 20 caracteres" )]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirmar senha de acesso", Prompt = "Confirme sua senha de acesso")]
        [Compare("Senha", ErrorMessage ="As senhas não conferem")]
        public string ConfirmacaoSenha { get; set; }

        public IFormFile Foto { get; set; }
    }
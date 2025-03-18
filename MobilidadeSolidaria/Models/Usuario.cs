using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MobilidadeSolidaria.Models;
public class Usuario : IdentityUser
{

    [Required(ErrorMessage = "Por favor, insira o nome")]
    [StringLength(60, ErrorMessage = "O nome deve conter no máximo 60 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Por favor, insira a senha")]
    [StringLength(30, ErrorMessage = "a senha deve conter no máximo 30 caracteres")]
    public string Senha { get; set; }

    public List<Equipamento> Equipamentos { get; set; }  // Um usuário pode ter vários equipamentos

}
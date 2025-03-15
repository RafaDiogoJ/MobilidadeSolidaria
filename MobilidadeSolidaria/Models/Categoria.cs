using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZstdSharp.Unsafe;

namespace MobilidadeSolidaria.Models;

[Table("categoria")]
public class Categoria
{
    [Key]
    public int Id { get; set; }  

    [Required(ErrorMessage ="Por favor, informe o nome")]
    [StringLength(30, ErrorMessage = "O nome deve conter no máximo 30 caracteres")]
    public string Nome { get; set; }

    [StringLength(200)]
    public string Foto { get; set; }
}
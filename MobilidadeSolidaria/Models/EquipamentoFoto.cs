using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilidadeSolidaria.Models;

[Table("equipamento_foto")]
public class EquipamentoFoto
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage ="Por favor informe o equipamento")]
    public int EquipamentoId { get; set; }
    
    [ForeignKey("EquipamentoId")]
    public Equipamento Equipamento { get; set; }

    [Display(Name ="Arquivo")]
    [Required(ErrorMessage ="Por favor, informe o arquivo")]
    [StringLength(300)]
    public string ArquivoFoto { get; set; }

    [Display(Name ="Descrição")]
    [StringLength(100, ErrorMessage ="A descrição deve conter no máximo 100 caracteres")]
    public string Descricao { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace MobilidadeSolidaria.Models
{
    public enum StatusEquipamento
    {
        [Display(Name ="Empréstimo")]
        Emprestimo,   // Equipamento disponível para empréstimo
        [Display(Name ="Doação")]
        Doacao,       // Equipamento disponível para doação
        [Display(Name ="Indisponível")]
        Indisponivel  // Equipamento que já foi emprestado ou doado
    }
}

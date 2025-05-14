using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobilidadeSolidaria.Models;

namespace MobilidadeSolidaria.ViewModels
{
    public class CadastroEquipamentoVM
    {
        [Required(ErrorMessage ="Por favor, informe o nome")]
        [Display(Name="Nome", Prompt = "Informe o nome do Equipamento")]
        [StringLength(50, ErrorMessage ="O nome deve possuir no máximo 60 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage ="Por favor, informe a descrição")]
        [Display(Name="Nome", Prompt = "Informe a descrição do equipamento")]
        [StringLength(150, ErrorMessage ="O nome deve possuir no máximo 150 caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Por favor, selecione uma categoria")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        public StatusEquipamento Status { get; set; }

        public IEnumerable<SelectListItem> StatusDisponiveis { get; set; }

    }
}
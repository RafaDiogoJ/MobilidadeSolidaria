using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobilidadeSolidaria.Models;

namespace MobilidadeSolidaria.ViewModels
{
    public class CadastroEquipamentoVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome")]
        [Display(Name = "Nome", Prompt = "Informe o nome do Equipamento")]
        [StringLength(50, ErrorMessage = "O nome deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Por favor, informe a descrição")]
        [Display(Name = "Descrição", Prompt = "Informe a descrição do equipamento")]
        [StringLength(200, ErrorMessage = "A descrição deve possuir no máximo 200 caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Por favor, selecione uma categoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor, selecione uma categoria válida")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        // Campo apenas para exibição, não enviado no form
        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Display(Name = "Status")]
        public StatusEquipamento Status { get; set; }

        public IEnumerable<SelectListItem> StatusDisponiveis { get; set; }

        [Display(Name = "Fotos")]
        public List<IFormFile> Fotos { get; set; }
    }
}

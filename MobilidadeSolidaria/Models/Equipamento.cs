using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Mysqlx;
using System.ComponentModel.DataAnnotations.Schema;


namespace MobilidadeSolidaria.Models
{
    public class Equipamento
    {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, insira o nome do equipamento")]
    [StringLength(60, ErrorMessage ="O nome do equipamento não pode conter mais de 60 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Por favor, insira uma descrição")]
    [StringLength(200, ErrorMessage ="A descrição não pode conter mais de 200 caracteres")]
    public string Descricao { get; set; }

    public string Cidade { get; set; } // A cidade onde o equipamento está disponível
    public string Estado { get; set; } // Opcional, se quiser refinar a busca

    public List<EquipamentoFoto> Fotos { get; set; }

    [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
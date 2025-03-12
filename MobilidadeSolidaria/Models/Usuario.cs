using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilidadeSolidaria.Models
{
    public class Usuario
    {
        public int id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }


    }
}
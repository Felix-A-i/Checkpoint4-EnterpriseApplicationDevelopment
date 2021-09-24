using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Models
{
    public class Integrantes
    {
        public Integrantes(string nome, int rm)
        {
            Nome = nome;
            Rm = rm;
        }
        public string Nome { get; set; }
        [Display(Name = "RM")]
        public int Rm { get; set; }
    }
}

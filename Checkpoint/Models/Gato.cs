using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Models
{
    public class Gato
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public string Cor { get; set; }
        [Display(Name = "Raça")]
        public string Raca { get; set; }
        public bool Castrado { get; set; }
        [Display(Name= "Data de Nascimento"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
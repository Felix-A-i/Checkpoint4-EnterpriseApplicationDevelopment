using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Models
{
    [Table("Tbl_Cachorro")]
    public class Cachorro
    {
        [Column("Id"), HiddenInput]
        public int CachorroId { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; }
        public Sexo? Sexo { get; set; }
        [Required, MaxLength(30)]
        public string Cor { get; set; }
        [Display(Name = "Raça")]
        public string Raca { get; set; }
        public bool Castrado { get; set; }
        [Display(Name= "Data de Nascimento"),Required, DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        //Many-To-One
        public Tutor Tutor { get; set; }
        public int? TutorId { get; set; }

        //Many-to-Many
        public IList<Amigo> Amigos { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Models
{
    [Table("Tbl_Tutor")]
    public class Tutor
    {
        [Column("Id"), HiddenInput]
        public int TutorId { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }
        [Display(Name = "Gênero")]
        public GeneroTutor GeneroTutor { get; set; }
        [Column("Dt_Nascimento", TypeName = "Date"), DataType(DataType.Date), Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        //One-to-One
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }//FK

        //One-to-Many
        public IList<Gato> Gatos { get; set; }

    }

    public enum GeneroTutor
    {
        Feminino,Masculino,Outros
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint.Models
{
    [Table("Tbl_Amigo")]
    public class Amigo
    {
        public int CachorroId { get; set; }
        public Cachorro Cachorro { get; set; }
        public int GatoId { get; set; }
        public Gato Gato { get; set; }
    }
}
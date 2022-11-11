using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistraduriaBackenNetApiCore.Models
{
    [Table("Registros")]
    public class Registro
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codRegistro { get; set; }
        public int registro { get; set; }
        public int cedula { get; set; }
        public Persona? persona { get; set; }
    }
}

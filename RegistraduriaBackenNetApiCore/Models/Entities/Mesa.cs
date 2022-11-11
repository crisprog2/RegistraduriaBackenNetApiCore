using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistraduriaBackenNetApiCore.Models.Entities
{
    [Table("Mesas")]
    public class Mesa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codMesa { get; set; }
        public int mesa { get; set; }
        public string? codLugarVoto { get; set; }
        public LugarVoto? lugarVoto { get; set; }
        public ICollection<Persona>? Personas { get; set; }
    }
}

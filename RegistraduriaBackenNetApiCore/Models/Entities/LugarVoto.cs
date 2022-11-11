using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistraduriaBackenNetApiCore.Models.Entities
{
    [Table("LugarVotaciones")]
    public class LugarVoto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? codLugarVoto { get; set; }
        public string? nombreLugarVoto { get; set; }
        public string? direccionLugarVoto { get; set; }
        public string? codCiudad { get; set; }
        public Ciudad? ciudad { get; set; }
        public ICollection<Mesa>? Mesas { get; set; }
    }
}

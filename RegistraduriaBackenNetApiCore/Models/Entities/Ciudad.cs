using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistraduriaBackenNetApiCore.Models.Entities
{
    [Table("Ciudades")]
    public class Ciudad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? codCiudad { get; set; }
        public string? ciudad { get; set; }
        public string? codDepartamento { get; set; }
        public Departamento? departamento { get; set; }
        public ICollection<LugarVoto>? Lugares { get; set; }
    }
}

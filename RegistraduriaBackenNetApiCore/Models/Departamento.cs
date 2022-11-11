using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registraduria_Backend_Api.Models
{
    [Table("Departamentos")]
    public class Departamento
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? codDepartamento { get; set; }
        public string? departamentoNombre { get; set; }
        public ICollection<Ciudad>? Ciudades { get; set; }

    }
}

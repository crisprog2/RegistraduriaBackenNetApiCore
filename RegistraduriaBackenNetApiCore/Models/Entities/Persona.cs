using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistraduriaBackenNetApiCore.Models.Entities
{
    [Table("Personas")]
    public class Persona
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cedula { get; set; }
        public string? primerNombre { get; set; }
        public string? segundoNombre { get; set; }
        public string? primerApellido { get; set; }
        public string? segundoApellido { get; set; }
        public string? genero { get; set; }
        public int edad { get; set; }
        public string? jurado { get; set; }
        public int codMesa { get; set; }
        public Mesa? mesa { get; set; }
        public ICollection<Registro>? Registros { get; set; }

    }
}

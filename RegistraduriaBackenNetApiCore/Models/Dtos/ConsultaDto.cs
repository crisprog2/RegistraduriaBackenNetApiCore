namespace RegistraduriaBackenNetApiCore.Models.Dtos
{
    public class ConsultaDto
    {
        public int cedula { get; set; }
        public string? primerNombre { get; set; }
        public string? segundoNombre { get; set; }
        public string? primerApellido { get; set; }
        public string? segundoApellido { get; set; }
        public string? genero { get; set; }
        public string? jurado { get; set; }
        public int mesa { get; set; }
        public string? nombreLugarVoto { get; set; }
        public string? direccionLugarVoto { get; set; }
        public string? ciudad { get; set; }
        public string? departamentoNombre { get; set; }
    }
}

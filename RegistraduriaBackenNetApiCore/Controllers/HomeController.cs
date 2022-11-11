using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistraduriaBackenNetApiCore.DataBaseContext;
using RegistraduriaBackenNetApiCore.Models.Dtos;
using RegistraduriaBackenNetApiCore.Models.Entities;

namespace RegistraduriaBackenNetApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DBContext _context;
        public HomeController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaDto>> GetConsulta(int id)
        {
            ConsultaDto consultaDto = new ConsultaDto();
            var persona = await _context.Persona.FindAsync(id);
            if (persona != null)
            {
                var mesa = await _context.Mesa.FindAsync(persona.codMesa);
                var lugarVoto = await _context.LugarVotaciones.FindAsync(mesa.codLugarVoto);
                var ciudad = await _context.Ciudades.FindAsync(lugarVoto.codCiudad);
                var departamento = await _context.Departamentos.FindAsync(ciudad.codDepartamento);
                consultaDto.primerNombre = persona.primerNombre;
                consultaDto.segundoNombre = persona.segundoNombre;
                consultaDto.primerApellido = persona.primerApellido;
                consultaDto.segundoApellido = persona.segundoApellido;
                consultaDto.cedula = persona.cedula;
                consultaDto.genero = persona.genero;
                if (persona.jurado.Equals("Y"))
                {
                    consultaDto.jurado = "Es jurado de votacion";
                }
                else
                {
                    consultaDto.jurado = "No es Jurado de votacion";
                }
                consultaDto.mesa = mesa.mesa;
                consultaDto.nombreLugarVoto = lugarVoto.nombreLugarVoto;
                consultaDto.direccionLugarVoto = lugarVoto.direccionLugarVoto;
                consultaDto.ciudad = ciudad.ciudad;
                consultaDto.departamentoNombre = departamento.departamentoNombre;

                return consultaDto;
                
            }

            return NotFound();

        }

    }
}

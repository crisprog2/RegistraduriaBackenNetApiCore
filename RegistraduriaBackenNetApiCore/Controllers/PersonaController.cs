using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistraduriaBackenNetApiCore.DataBaseContext;
using RegistraduriaBackenNetApiCore.Models.Entities;

namespace RegistraduriaBackenNetApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DBContext _context;

        public PersonaController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
        {
            return await _context.Persona.ToListAsync();
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Persona/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.cedula)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Persona
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Persona.Add(persona);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonaExists(persona.cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersona", new { id = persona.cedula }, persona);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.cedula == id);
        }
    }
}

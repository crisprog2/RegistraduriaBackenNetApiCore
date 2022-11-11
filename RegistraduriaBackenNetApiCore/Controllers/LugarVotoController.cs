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
    public class LugarVotoController : ControllerBase
    {
        private readonly DBContext _context;

        public LugarVotoController(DBContext context)
        {
            _context = context;
        }

        // GET: api/LugarVoto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LugarVoto>>> GetLugarVotaciones()
        {
            return await _context.LugarVotaciones.ToListAsync();
        }

        // GET: api/LugarVoto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LugarVoto>> GetLugarVoto(string id)
        {
            var lugarVoto = await _context.LugarVotaciones.FindAsync(id);

            if (lugarVoto == null)
            {
                return NotFound();
            }

            return lugarVoto;
        }

        // PUT: api/LugarVoto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLugarVoto(string id, LugarVoto lugarVoto)
        {
            if (id != lugarVoto.codLugarVoto)
            {
                return BadRequest();
            }

            _context.Entry(lugarVoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LugarVotoExists(id))
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

        // POST: api/LugarVoto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LugarVoto>> PostLugarVoto(LugarVoto lugarVoto)
        {
            _context.LugarVotaciones.Add(lugarVoto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LugarVotoExists(lugarVoto.codLugarVoto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLugarVoto", new { id = lugarVoto.codLugarVoto }, lugarVoto);
        }

        // DELETE: api/LugarVoto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLugarVoto(string id)
        {
            var lugarVoto = await _context.LugarVotaciones.FindAsync(id);
            if (lugarVoto == null)
            {
                return NotFound();
            }

            _context.LugarVotaciones.Remove(lugarVoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LugarVotoExists(string id)
        {
            return _context.LugarVotaciones.Any(e => e.codLugarVoto == id);
        }
    }
}

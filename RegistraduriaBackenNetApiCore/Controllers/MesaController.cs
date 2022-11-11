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
    public class MesaController : ControllerBase
    {
        private readonly DBContext _context;

        public MesaController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Mesa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesa()
        {
            return await _context.Mesa.ToListAsync();
        }

        // GET: api/Mesa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mesa>> GetMesa(int id)
        {
            var mesa = await _context.Mesa.FindAsync(id);

            if (mesa == null)
            {
                return NotFound();
            }

            return mesa;
        }

        // PUT: api/Mesa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, Mesa mesa)
        {
            if (id != mesa.codMesa)
            {
                return BadRequest();
            }

            _context.Entry(mesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesaExists(id))
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

        // POST: api/Mesa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mesa>> PostMesa(Mesa mesa)
        {
            _context.Mesa.Add(mesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesa", new { id = mesa.codMesa }, mesa);
        }

        // DELETE: api/Mesa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            var mesa = await _context.Mesa.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            _context.Mesa.Remove(mesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesaExists(int id)
        {
            return _context.Mesa.Any(e => e.codMesa == id);
        }
    }
}

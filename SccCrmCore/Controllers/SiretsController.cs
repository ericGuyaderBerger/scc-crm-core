using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SccCrmCore.Models.Entities;

namespace SccCrmCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiretsController : ControllerBase
    {
        private readonly CrmDbContext _context;

        public SiretsController(CrmDbContext context)
        {
            _context = context;
        }

        // GET: api/Sirets
        [HttpGet]
        public IEnumerable<Siret> GetSirets()
        {
            return _context.Sirets;
        }

        // GET: api/Sirets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiret([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var siret = await _context.Sirets.FindAsync(id);

            if (siret == null)
            {
                return NotFound();
            }

            return Ok(siret);
        }

        // PUT: api/Sirets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiret([FromRoute] int id, [FromBody] Siret siret)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siret.Id)
            {
                return BadRequest();
            }

            _context.Entry(siret).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiretExists(id))
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

        // POST: api/Sirets
        [HttpPost]
        public async Task<IActionResult> PostSiret([FromBody] Siret siret)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sirets.Add(siret);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiret", new { id = siret.Id }, siret);
        }

        // DELETE: api/Sirets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiret([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var siret = await _context.Sirets.FindAsync(id);
            if (siret == null)
            {
                return NotFound();
            }

            _context.Sirets.Remove(siret);
            await _context.SaveChangesAsync();

            return Ok(siret);
        }

        private bool SiretExists(int id)
        {
            return _context.Sirets.Any(e => e.Id == id);
        }
    }
}
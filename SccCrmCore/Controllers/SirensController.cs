using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SccCrmCore.Models.Dto;
using SccCrmCore.Models.Entities;

namespace SccCrmCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirensController : ControllerBase
    {
        private readonly CrmDbContext _context;

        public SirensController(CrmDbContext context)
        {
            _context = context;
        }

        // GET: api/Sirens
        [HttpGet]
        public IEnumerable<Siren> GetSirens()
        {
            return _context.Sirens;
        }

        // GET: api/Sirens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiren([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var siren = await _context.Sirens.FindAsync(id);

            if (siren == null)
            {
                return NotFound();
            }

            return Ok(siren);
        }

        // PUT: api/Sirens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiren([FromRoute] int id, [FromBody] Siren siren)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siren.Id)
            {
                return BadRequest();
            }

            _context.Entry(siren).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SirenExists(id))
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

        // POST: api/Sirens
        [HttpPost]
        public async Task<IActionResult> PostSiren([FromBody] SirenForInsertDto sirenDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Siren siren = new Siren()
            {
                Nom = sirenDto.Nom,
                Numero = sirenDto.Numero,
                Actif = sirenDto.Actif
            };

            _context.Sirens.Add(siren);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiren", new { id = siren.Id }, siren);
        }

        // DELETE: api/Sirens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiren([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var siren = await _context.Sirens.FindAsync(id);
            if (siren == null)
            {
                return NotFound();
            }

            _context.Sirens.Remove(siren);
            await _context.SaveChangesAsync();

            return Ok(siren);
        }

        private bool SirenExists(int id)
        {
            return _context.Sirens.Any(e => e.Id == id);
        }
    }
}
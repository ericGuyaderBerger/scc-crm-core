using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SccCrmCore.Models.Dto;
using SccCrmCore.Models.Entities;
using SccCrmCore.Services;

namespace SccCrmCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirensController : ControllerBase
    {
        private readonly IPersistanceLayer _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public SirensController(IPersistanceLayer context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        // GET: api/Sirens
        [HttpGet]
        public IEnumerable<Siren> GetSirens([FromQuery] string numero = null,
            [FromQuery] string nom = null, [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 0)
        {
            if (pageSize == 0)
            {
                pageSize = Convert.ToInt32(_config["Paging:pageSize"]);
            }
            
            return _context.getSirens(page, pageSize, numero, nom);
        }

        // GET: api/Sirens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiren([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var siren = await _context.getSirenFromIdAsync(id);

            if (siren == null)
            {
                return NotFound();
            }

            return Ok(siren);
        }

        // PUT: api/Sirens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiren([FromRoute] int id, [FromBody] SirenForUpdateDto siren)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siren.Id)
            {
                return BadRequest();
            }

            Siren sirenEntity = await _context.getSirenFromIdAsync(id);

            if (sirenEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(siren,sirenEntity);
            await _context.SaveAsync();

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

            Siren siren = _mapper.Map<Siren>(sirenDto);
            try
            {
               await _context.insertSirenAsync(siren);
     
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Erreur lors de l'ajout du Siren");
            }

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

            var siren = await _context.getSirenFromIdAsync(id);
            if (siren == null)
            {
                return NotFound();
            }


            try
            {
                await _context.deleteSirenAsync(siren);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error has occured while triyng to delete siren");
            }

            return Ok(siren);
        }

        
    }
}
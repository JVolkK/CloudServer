using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasAPI.Data;
using PersonasAPI.Modelos;
using PersonasAPI.Modelos.DTOs;
using PersonasAPI.Repositorio;

namespace PersonasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {

        private readonly IPersonaRepositorio _repositorio;
        private ResponseDto _response;
        private readonly DataContext _context;

        public PersonasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personas>>> GetPersonas()
        {
          if (_context.Personas == null)
          {
              return NotFound();
          }
            return await _repositorio.GetPersonas();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personas>> GetPersonas(int id)
        {
            _response = await _repositorio.CrearOActualizar(personas)   
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonas(int id, Personas personas)
        {
            if (id != personas.Id)
            {
                return BadRequest();
            }

            _context.Entry(personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personas>> PostPersonas(Personas personas)
        {
          if (_context.Personas == null)
          {
              return Problem("Entity set 'DataContext.Personas'  is null.");
          }
            _context.Personas.Add(personas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas", new { id = personas.Id }, personas);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonas(int id)
        {
            _response.IsSuccess = await _repositorio.DeletePersonas(id);
            _response.DisplayMassage = $"Se elimino";
            return Ok(_response);
        }

        private bool PersonasExists(int id)
        {
            return (_context.Personas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FigurasApi.Data;
using FigurasApi.Models;

namespace FigurasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FigurasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FigurasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/figuras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Figura>>> GetFiguras()
        {
            return await _context.Figuras.ToListAsync();
        }

        // GET: api/figuras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Figura>> GetFigura(int id)
        {
            var figura = await _context.Figuras.FindAsync(id);
            if (figura == null)
                return NotFound();
            return figura;
        }

        // POST: api/figuras
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Figura>> PostFigura(Figura figura)
        {
            figura.CalcularVolumen();
            _context.Figuras.Add(figura);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFigura), new { id = figura.Id }, figura);
        }

        // PUT: api/figuras/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFigura(int id, Figura figura)
        {
            if (id != figura.Id)
                return BadRequest();

            var figuraExistente = await _context.Figuras.FindAsync(id);
            if (figuraExistente == null)
                return NotFound();

            figuraExistente.TipoFigura = figura.TipoFigura;
            figuraExistente.Arista = figura.Arista;
            figuraExistente.Radio = figura.Radio;
            figuraExistente.Altura = figura.Altura;
            figuraExistente.Base = figura.Base;
            figuraExistente.CalcularVolumen();

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/figuras/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFigura(int id)
        {
            var figura = await _context.Figuras.FindAsync(id);
            if (figura == null)
                return NotFound();
            _context.Figuras.Remove(figura);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 
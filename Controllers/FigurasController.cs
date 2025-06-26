using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FigurasApi.Data;
using FigurasApi.Models;
using FigurasApi.Services;

namespace FigurasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FigurasController : ControllerBase
    {
        private readonly IFiguraService _figuraService;

        public FigurasController(IFiguraService figuraService)
        {
            _figuraService = figuraService;
        }

        // GET: api/figuras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Figura>>> GetFiguras()
        {
            var figuras = await _figuraService.GetAllAsync();
            return Ok(figuras);
        }

        // GET: api/figuras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Figura>> GetFigura(int id)
        {
            var figura = await _figuraService.GetByIdAsync(id);
            if (figura == null)
                return NotFound();
            return Ok(figura);
        }

        // POST: api/figuras
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Figura>> PostFigura(Figura figura)
        {
            var nuevaFigura = await _figuraService.AddAsync(figura);
            return CreatedAtAction(nameof(GetFigura), new { id = nuevaFigura.Id }, nuevaFigura);
        }

        // PUT: api/figuras/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFigura(int id, Figura figura)
        {
            if (id != figura.Id)
                return BadRequest();

            var actualizada = await _figuraService.UpdateAsync(figura);
            if (actualizada == null)
                return NotFound();
            return NoContent();
        }

        // DELETE: api/figuras/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFigura(int id)
        {
            var eliminado = await _figuraService.DeleteAsync(id);
            if (!eliminado)
                return NotFound();
            return NoContent();
        }
    }
} 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FigurasApi.Data;
using FigurasApi.Models;

namespace FigurasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/calculos/area/rectangulo
        [HttpPost("area/rectangulo")]
        [Authorize]
        public async Task<IActionResult> CalcularAreaRectangulo([FromBody] RectanguloDto dto)
        {
            if (dto.Base <= 0 || dto.Altura <= 0)
                return BadRequest("Base y altura deben ser mayores a cero.");
            var area = dto.Base * dto.Altura;
            // Guardar como figura
            var figura = new Figura
            {
                TipoFigura = "rectangulo",
                Base = dto.Base,
                Altura = dto.Altura,
                Volumen = area // Usamos el campo Volumen para guardar el área
            };
            _context.Figuras.Add(figura);
            await _context.SaveChangesAsync();
            return Ok(new { area, figuraId = figura.Id });
        }

        // POST: api/calculos/area/circulo
        [HttpPost("area/circulo")]
        [Authorize]
        public async Task<IActionResult> CalcularAreaCirculo([FromBody] CirculoDto dto)
        {
            if (dto.Radio <= 0)
                return BadRequest("El radio debe ser mayor a cero.");
            var area = Math.PI * Math.Pow(dto.Radio, 2);
            // Guardar como figura
            var figura = new Figura
            {
                TipoFigura = "circulo",
                Radio = dto.Radio,
                Volumen = area // Usamos el campo Volumen para guardar el área
            };
            _context.Figuras.Add(figura);
            await _context.SaveChangesAsync();
            return Ok(new { area, figuraId = figura.Id });
        }

        // POST: api/calculos/volumen/cuboide
        [HttpPost("volumen/cuboide")]
        [Authorize]
        public async Task<IActionResult> CalcularVolumenCuboide([FromBody] CuboideDto dto)
        {
            if (dto.Largo <= 0 || dto.Ancho <= 0 || dto.Alto <= 0)
                return BadRequest("Largo, ancho y alto deben ser mayores a cero.");
            var volumen = dto.Largo * dto.Ancho * dto.Alto;
            // Guardar como figura
            var figura = new Figura
            {
                TipoFigura = "cuboide",
                Largo = dto.Largo,
                Ancho = dto.Ancho,
                Altura = dto.Alto,
                Volumen = volumen
            };
            _context.Figuras.Add(figura);
            await _context.SaveChangesAsync();
            return Ok(new { volumen, figuraId = figura.Id });
        }

        // POST: api/calculos/volumen/cono
        [HttpPost("volumen/cono")]
        [Authorize]
        public async Task<IActionResult> CalcularVolumenCono([FromBody] ConoDto dto)
        {
            if (dto.Radio <= 0 || dto.Altura <= 0)
                return BadRequest("Radio y altura deben ser mayores a cero.");
            var volumen = (1.0 / 3.0) * Math.PI * Math.Pow(dto.Radio, 2) * dto.Altura;
            // Guardar como figura
            var figura = new Figura
            {
                TipoFigura = "cono",
                Radio = dto.Radio,
                Altura = dto.Altura,
                Volumen = volumen
            };
            _context.Figuras.Add(figura);
            await _context.SaveChangesAsync();
            return Ok(new { volumen, figuraId = figura.Id });
        }
    }

    public class RectanguloDto
    {
        public double Base { get; set; }
        public double Altura { get; set; }
    }
    public class CirculoDto
    {
        public double Radio { get; set; }
    }
    public class CuboideDto
    {
        public double Largo { get; set; }
        public double Ancho { get; set; }
        public double Alto { get; set; }
    }
    public class ConoDto
    {
        public double Radio { get; set; }
        public double Altura { get; set; }
    }
} 
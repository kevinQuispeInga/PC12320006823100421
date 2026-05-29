using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC12320006823100421.CORE.CORE.Entities;
using PC12320006823100421.CORE.Infrastructure.Data;

namespace PC12320006823100421.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicioController : ControllerBase
    {
        private readonly TallerMecanicoDbContext _context;

        public TipoServicioController(TallerMecanicoDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoServicio
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _context.TipoServicio.ToListAsync();

            return Ok(lista);
        }

        // GET: api/TipoServicio/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoServicio =
                await _context.TipoServicio.FindAsync(id);

            if (tipoServicio == null)
                return NotFound();

            return Ok(tipoServicio);
        }

        // POST: api/TipoServicio
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoServicio tipoServicio)
        {
            _context.TipoServicio.Add(tipoServicio);

            await _context.SaveChangesAsync();

            return Ok(tipoServicio);
        }

        // PUT: api/TipoServicio
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TipoServicio tipoServicio)
        {
            var existe =
                await _context.TipoServicio.FindAsync(tipoServicio.Id);

            if (existe == null)
                return NotFound();

            existe.Nombre = tipoServicio.Nombre;
            existe.PrecioBase = tipoServicio.PrecioBase;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/TipoServicio/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoServicio =
                await _context.TipoServicio.FindAsync(id);

            if (tipoServicio == null)
                return NotFound();

            _context.TipoServicio.Remove(tipoServicio);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using PC12320006823100421.CORE.CORE.Entities;
using PC12320006823100421.CORE.Core.Interfaces;

namespace PC12320006823100421.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenServicioController : ControllerBase
    {
        private readonly IOrdenServicioService _service;

        public OrdenServicioController(IOrdenServicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _service.GetAll();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ordenServicio = await _service.GetById(id);

            if (ordenServicio == null)
                return NotFound();

            return Ok(ordenServicio);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdenServicio ordenServicio)
        {
            await _service.Create(ordenServicio);
            return Ok(ordenServicio);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrdenServicio ordenServicio)
        {
            var existe = await _service.GetById(ordenServicio.Id);

            if (existe == null)
                return NotFound();

            await _service.Update(ordenServicio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = await _service.GetById(id);

            if (existe == null)
                return NotFound();

            await _service.Delete(id);
            return NoContent();
        }
    }
}
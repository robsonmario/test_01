using Taking.Robson.Application.Interfaces;
using Taking.Robson.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Taking.Robson.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _service;

        public VendaController(IVendaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ObterVendasAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.ObterVendaPorIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Venda venda)
        {
            await _service.CriarVendaAsync(venda);
            return CreatedAtAction(nameof(Get), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Venda venda)
        {
            venda.Id = id;
            await _service.AtualizarVendaAsync(venda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.CancelarVendaAsync(id);
            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pon.Site.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _service;

        public CarritoController(ICarritoService service)
        {
            _service = service;
        }

        // GET api/<CarritoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var carrito = await _service.Get(id);

            return Ok(carrito);
        }

        // GET api/<CarritoController>/5
        [HttpGet("clienteId/{clienteId}")]
        public async Task<IActionResult> GetByClienteId(Guid clienteId)
        {
            var carrito = await _service.GetByClienteId(clienteId);

            return Ok(carrito);
        }

        // PUT api/<CarritoController>/5
        [HttpPut("{id}/addProduct")]
        public async Task<IActionResult> AddProduct(Guid id, [FromBody] Producto producto)
        {
            var carrito = await _service.AddProduct(id, producto);
            return Ok(carrito);
        }

        // DELETE api/<CarritoController>/5
        [HttpPut("{id}/removeProduct")]
        public async Task<IActionResult> RemoveProduct(Guid id, [FromBody] Producto producto)
        {
            var carrito = await _service.RemoveProduct(id, producto);
            return Ok(carrito);
        }

        [HttpPut("{id}/emptyCart")]
        public async Task<IActionResult> EmptyCart(Guid id)
        {
            var carrito = await _service.EmptyCart(id);
            return Ok(carrito);
        }
    }
}

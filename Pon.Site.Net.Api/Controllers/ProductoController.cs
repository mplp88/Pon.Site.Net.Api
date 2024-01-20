using Microsoft.AspNetCore.Mvc;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Responses;
using Pon.Site.Net.Api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pon.Site.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var productos = await _service.GetAll();
                return Ok(productos);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse("Error obteniendo la lista de productos.", ex));
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var producto = await _service.GetById(id);
                if(producto == null)
                {
                    return NotFound(new
                    {
                        Message = "Producto no encontrado."
                    });
                }

                return Ok(producto);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse("Error obteniendo el producto", ex));
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto productoNuevo)
        {
            try
            {
                var producto = await _service.Add(productoNuevo);
                return Ok(producto);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse("Error agregando el producto.", ex));
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Producto productoActualizado)
        {
            try
            {
                var producto = await _service.GetById(id);
                if (producto == null)
                {
                    return NotFound(new
                    {
                        Mensaje = "Producto no encontrado."
                    });
                }

                producto = await _service.Update(productoActualizado);
                return Ok(producto);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse("Error actualizando el producto", ex));
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var producto = await _service.GetById(id);
                if(producto == null)
                {
                    return NotFound(new
                    {
                        Mensaje = "Producto no encontrado."
                    });
                }

                await _service.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse("Error eliminando el producto", ex));
            }
        }
    }
}

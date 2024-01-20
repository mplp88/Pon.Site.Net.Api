using Microsoft.AspNetCore.Mvc;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Responses;
using Pon.Site.Net.Api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pon.Site.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categorias = await _service.GetAll();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse("Error obteniendo la lista de categorías", ex));
            }
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var categoria = await _service.GetById(id);
                if (categoria == null)
                {
                    return NotFound(new
                    {
                        Mensaje = "No se encontró la categoría"
                    });
                }

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse("Error obteniendo la categoría", ex));
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                var entity = await _service.Add(categoria);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse("Error agregando nueva categoría", ex));
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Categoria categoriaActualizada)
        {
            try
            {
                var categoria = await _service.GetById(id);
                if (categoria == null)
                {
                    return NotFound(new
                    {
                        Mensaje = "No se encontró la categoría"
                    });
                }

                var actualizada = await _service.Update(categoriaActualizada);
                return Ok(actualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse("Error actualizando la categoría.", ex));
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var categoria = await _service.GetById(id);
                if (categoria == null)
                {
                    return NotFound(new
                    {
                        Mensaje = "No se encontró la categoría."
                    });
                }

                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse("Error eliminando la categoría.", ex));
            }
        }
    }
}

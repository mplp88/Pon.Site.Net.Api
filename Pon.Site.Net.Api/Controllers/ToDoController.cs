using Microsoft.AspNetCore.Mvc;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Responses;
using Pon.Site.Net.Api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pon.Site.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IService<Item> _service;

        public ToDoController(IService<Item> service)
        {
            _service = service;
        }

        // GET: api/<ToDoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var todos = await _service.Get();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ErrorResponse("Error obteniendo la lista de items", ex));
            }
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var todo = await _service.Get(id);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ErrorResponse("Error obteniendo el item", ex));
            }
        }

        // POST api/<ToDoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item toDo)
        {
            try
            {
                var todo = await _service.Add(toDo);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse("Error agregando el item", ex));
            }
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Item updatedToDo)
        {
            try
            {
                var toDo = await _service.Get(id);

                if (toDo == null)
                {
                    return NotFound(new
                    {
                        Error = "Item no encontrado"
                    });
                }

                toDo = await _service.Update(updatedToDo);

                return Ok(toDo);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ErrorResponse("Error actualizando el item", ex));
            }
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ErrorResponse("Error eliminando el item", ex));
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pon.Site.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

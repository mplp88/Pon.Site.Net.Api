using Microsoft.AspNetCore.Mvc;

namespace Pon.Site.Net.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Api is working");
        }
    }
}

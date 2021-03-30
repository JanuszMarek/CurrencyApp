using Microsoft.AspNetCore.Mvc;

namespace CurrencyApi.Controllers
{
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("/connection")]
        public IActionResult Connection()
        {
            return Ok();
        }
    }
}

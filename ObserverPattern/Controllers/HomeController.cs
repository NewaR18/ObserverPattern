using Microsoft.AspNetCore.Mvc;
using ObserverPattern.Models;

namespace ObserverPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        protected IActionResult Index()
        {
            return Ok("Hello");
        }

    }
}

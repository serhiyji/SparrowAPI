using Microsoft.AspNetCore.Mvc;

namespace SparrowAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SparrowAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

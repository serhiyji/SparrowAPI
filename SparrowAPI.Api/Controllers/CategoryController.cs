using Microsoft.AspNetCore.Mvc;

namespace SparrowAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(null);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparrowAPI.Core.DTOs.Category;
using SparrowAPI.Core.Interfaces;
using SparrowAPI.Core.Validation.Category;

namespace SparrowAPI.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this._categoryService.GetAll());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto model)
        {
            var validationResult = await new CreateCategoryValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                await this._categoryService.Create(model);
                return Ok();
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto model)
        {
            var validationResult = await new UpdateCategoryValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                await this._categoryService.Update(model);
                return Ok();
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryDto model)
        {
            await this._categoryService.Delete(model.Id);
            return Ok();
        }
    }
}

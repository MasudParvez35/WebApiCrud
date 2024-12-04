using Microsoft.AspNetCore.Mvc;
using OA.Core.Domain;
using OA.Services;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Methods

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> Categories()
        {
            var categorys = await _categoryService.GetAllCategory();

            return Ok(categorys);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(Category category)
        {
            if (category == null)
                return BadRequest();

            await _categoryService.InsertCategoryAsync(category);

            return Ok(category);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, Category updatedCategory)
        {
            if (updatedCategory == null)
                return BadRequest();

            // Retrieve the existing category by ID
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            category.Name = updatedCategory.Name;

            await _categoryService.UpdateCategoryAsync(category);

            return Ok(category);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            await _categoryService.DeleteCategoryAsync(category);

            return Ok(category);
        }

        #endregion
    }
}

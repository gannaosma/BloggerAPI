using BloggerAPI.DTO;
using BloggerAPI.Models;
using BloggerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
			_service = service;
        }

        [HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			var categories = await _service.GetAll();
			return Ok(categories);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromBody]CategoryDTO categorydto)
		{
			if (categorydto == null)
				return BadRequest("invalid category");

			var category = new Category()
			{
				Title = categorydto.Title,
				Description = categorydto.Description
			};

			await _service.Add(category);

			return Ok(category);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCategoryById([FromRoute]int id)
		{
			if (id <= 0)
				return BadRequest("invalid Id");

			var category =await _service.GeteById(id);

			if (category == null)
				return BadRequest($"No category with this  {id}");

			return Ok(category);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateCategory([FromRoute]int id,[FromBody]CategoryDTO categorydto)
		{
			if (id <= 0)
				return BadRequest("invalid id");

			var category = await _service.GeteById(id);

			if (category == null)
				return NotFound($"No category with this {id}");

			category.Title = categorydto.Title;
			category.Description = categorydto.Description;

			await _service.Update(category);

			return Ok(category);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteCategory([FromRoute] int id)
		{
			if (id <= 0)
				return BadRequest("invalid id");

			var category = await _service.GeteById(id);

			if (category == null)
				return NotFound($"No category with this {id}");

			await _service.Remove(category);

			return Ok(category);
		}


	}
}

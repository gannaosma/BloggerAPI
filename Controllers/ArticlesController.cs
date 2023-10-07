using BloggerAPI.DTO;
using BloggerAPI.Models;
using BloggerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticlesController : ControllerBase
	{
		private readonly IArticlesService _service;
		private readonly ICategoriesService _categoriesService;
        public ArticlesController(IArticlesService service, ICategoriesService categoriesService)
        {
			_service = service;
			_categoriesService = categoriesService;
        }

		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromBody]ArticleDTO articledto)
		{
			if (articledto == null)
				return BadRequest("invalid Article");

			var validCategory = await _categoriesService.IsValidCategory(articledto.CategoryId);

			if (!validCategory)
				return BadRequest("Invalid Category Id");

			var article = new Article()
			{
				Title = articledto.Title,
				Author = articledto.Author,
				Content = articledto.Content,
				PublicationDate = articledto.PublicationDate,
				CategoryId = articledto.CategoryId
			};

			var newArticle = await _service.Add(article);

			return Ok(newArticle);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllArticles()
		{
			var articles = await _service.GetAll();
			return Ok(articles);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetArticleById(int id)
		{
			if (id <= 0)
				return BadRequest("invalid id");

			var article = await _service.GeteById(id);

			if (article == null)
				return NotFound($"No Article with this {id}");

			await _service.GeteById(id);

			return Ok(article);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateArticle(int id, [FromBody]ArticleDTO articledto)
		{
			if (id <= 0)
				return BadRequest("invalid id");

			var article = await _service.GeteById(id);

			if (article == null)
				return NotFound($"No Article with this {id}");

			var validCategory = await _categoriesService.IsValidCategory(articledto.CategoryId);
			if (!validCategory)
				return BadRequest("Invalid Category Id");

			article.Title = articledto.Title;
			article.Author = articledto.Author;
			article.PublicationDate = articledto.PublicationDate;
			article.Content = articledto.Content;
			article.CategoryId = articledto.CategoryId;

			var updatedArticle = await _service.Update(article);

			return Ok(updatedArticle);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteArticle(int id)
		{
			if (id <= 0)
				return BadRequest("invalid id");

			var article = await _service.GeteById(id);

			if(article == null)
				return NotFound($"No Article with this {id}");

			await _service.Remove(article);

			return Ok(article);
		}
	}
}

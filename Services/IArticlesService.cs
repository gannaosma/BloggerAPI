using BloggerAPI.Models;

namespace BloggerAPI.Services
{
	public interface IArticlesService
	{
		Task<Article> Add(Article article);
		Task<List<Article>> GetAll();
		Task<Article> GeteById(int id);
		Task<Article> Update(Article article);
		Task<Article> Remove(Article article);

	}
}

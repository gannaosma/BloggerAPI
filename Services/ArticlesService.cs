using BloggerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggerAPI.Services
{
	public class ArticlesService:IArticlesService
	{
		private readonly ApplicationDbContext _context;
		public ArticlesService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<Article> Add(Article article)
		{
			await _context.AddAsync(article);
			await _context.SaveChangesAsync();
			return article;
		}
		public async Task<List<Article>> GetAll()
		{
			return await _context.Articles.Include(c => c.Category).ToListAsync();
		}
		public async Task<Article> GeteById(int id)
		{
			return await _context.Articles.Include(c => c.Category).FirstOrDefaultAsync(i => i.Id == id);
		}
		public async Task<Article> Update(Article article)
		{
			_context.Articles.Update(article);
			await _context.SaveChangesAsync();
			return article;
		}
		public async Task<Article> Remove(Article article)
		{
			_context.Articles.Remove(article);
			await _context.SaveChangesAsync();
			return article;
		}
	}
}

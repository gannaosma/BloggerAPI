using BloggerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggerAPI.Services
{
	public class CategoriesService: ICategoriesService
	{
        private readonly ApplicationDbContext _context;
        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }
		public async Task<Category> Add(Category category)
		{
			await _context.AddAsync(category);
			await _context.SaveChangesAsync();
			return category;
		}
		public async Task<List<Category>> GetAll()
		{
			return await _context.Categories.ToListAsync();
		}
		public async Task<Category> GeteById(int id)
		{
			return await _context.Categories.FirstOrDefaultAsync(i => i.Id == id);
		}
		public async Task<Category> Update(Category category)
		{
			_context.Categories.Update(category);
			await _context.SaveChangesAsync();
			return category;
		}
		public async Task<Category> Remove(Category category)
		{
			_context.Categories.Remove(category);
			await _context.SaveChangesAsync();
			return category;
		}

		public async Task<bool> IsValidCategory(int id)
		{
			return await _context.Categories.AnyAsync(i=> i.Id == id);
		}
	}
}

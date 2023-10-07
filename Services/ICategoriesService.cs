using BloggerAPI.Models;

namespace BloggerAPI.Services
{
	public interface ICategoriesService
	{
		Task<Category> Add(Category category);
		Task<List<Category>> GetAll();
		Task<Category> GeteById(int id);
		Task<Category> Update(Category category);
		Task<Category> Remove(Category category);
		Task<bool> IsValidCategory(int id);
	}
}

using System.ComponentModel.DataAnnotations;

namespace BloggerAPI.DTO
{
	public class CategoryDTO
	{
		[Required]
		[StringLength(50)]
		public string Title { get; set; }
		[Required]
		[StringLength(200)]
		public string Description { get; set; }
	}
}

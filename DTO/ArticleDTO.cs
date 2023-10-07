using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BloggerAPI.DTO
{
	public class ArticleDTO
	{
		[Required]
		[StringLength(50)]
		public string Title { get; set; }
		[Required]
		public string Content { get; set; }

		[DataType(DataType.Date)]
		public DateTime PublicationDate { get; set; }
		public string Author { get; set; }
		public int CategoryId { get; set; }

	}
}

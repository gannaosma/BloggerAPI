using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerAPI.Models
{
	public class Article
	{
		[Key]
        public int Id { get; set; }
		[Required]
		[StringLength(50)]
        public string Title { get; set; }
		[Required]
        public string Content { get; set; }

		[Display(Name = "Publication Date")]
		[DataType(DataType.Date)]
		public DateTime PublicationDate { get; set; }
		public string Author { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
	}


public static class ArticleEndpoints
{
	public static void MapArticleEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Article").WithTags(nameof(Article));

        group.MapGet("/", () =>
        {
            return new [] { new Article() };
        })
        .WithName("GetAllArticles")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Article { ID = id };
        })
        .WithName("GetArticleById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Article input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateArticle")
        .WithOpenApi();

        group.MapPost("/", (Article model) =>
        {
            //return TypedResults.Created($"/api/Articles/{model.ID}", model);
        })
        .WithName("CreateArticle")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Article { ID = id });
        })
        .WithName("DeleteArticle")
        .WithOpenApi();
    }
}}

﻿using System.ComponentModel.DataAnnotations;

namespace BloggerAPI.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}

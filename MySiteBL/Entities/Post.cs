using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySiteBL.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Length cannot be more than 50 characters")]
        public string? Title { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Length cannot be more than 500 characters")]
        public string? Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? PublishedDateTime { get; set; }
        public List<Comment>? Comments { get; set; }
		
		public int BlogId { get; set; }
        public Blog? Blog { get; set; }

		[NotMapped]
		[DisplayName("Upload File")]
		public IFormFile? ImageFile { get; set; }

		[Display(Name = "Select Name")]
		public string? ImagePath { get; set; }

	}
}

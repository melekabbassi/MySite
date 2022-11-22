using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySiteBL.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Length cannot be more than 50 characters")]
        public string? Title { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Length cannot be more than 250 characters")]
        public string? Content { get; set; }

        [Required]
        public string? Author { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityWeb.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public Question Question { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string ImageUrls { get; set; }

        public bool IsAccepted { get; set; }

        public string CodeBlock { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
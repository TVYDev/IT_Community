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
        [MaxLength(255)]
        public string UserId { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string ImageUrls { get; set; }

        public bool IsAccepted { get; set; }
    }
}
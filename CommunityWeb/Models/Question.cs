using System;
using System.ComponentModel.DataAnnotations;

namespace CommunityWeb.Models
{
    public class Question
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string ImageUrls { get; set; }
    }
}
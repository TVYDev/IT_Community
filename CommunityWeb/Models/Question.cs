using System;
using System.ComponentModel.DataAnnotations;

namespace CommunityWeb.Models
{
    public class Question
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "ចំណងជើង")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "ការពិព័ណ៌នា")]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public string ImageUrls { get; set; }
    }
}
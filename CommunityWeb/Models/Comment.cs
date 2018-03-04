using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityWeb.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public Answer Answer { get; set; }

        [Required]
        public int AnswerId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
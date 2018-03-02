using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommunityWeb.Models
{
    public class Chat
    {
        public enum ChatStatus { Read = 10 };

        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Body { get; set; }

        public DateTime SentDate { get; set; }

        public int Status { get; set; }
    }
}
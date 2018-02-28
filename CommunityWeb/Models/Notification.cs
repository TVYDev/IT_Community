using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommunityWeb.Models
{
    public class Notification
    {
        public enum NoticationType
        {
            HasAnswer = 10,
            HasQuestion = 20
        };

        public int Id { get; set; }

        public Question Question { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public Answer Answer { get; set; }

        [Required]
        public int AnswerId { get; set; }

        public int Type { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }
    }
}
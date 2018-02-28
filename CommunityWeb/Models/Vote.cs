using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityWeb.Models
{
    public class Vote
    {
        public enum VoteType { UpVote = 10, DownVote = 20};

        public ApplicationUser User { get; set; }

        public Answer Answer { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AnswerId { get; set; }

        public int Type { get; set; }
    }
}
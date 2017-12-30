using System.ComponentModel.DataAnnotations;

namespace CommunityWeb.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string  Name { get; set; }
    }
}
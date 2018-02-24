using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityWeb.Models
{
    /*
        This class is an associate class of M:N relationship between Question and Topic
    */

    public class QuestionTopicDetail
    {
        public Question Question { get; set; }

        public Topic Topic { get; set; }

        //We are using composite primary keys, so we need to specify their column order
        [Key]
        [Column(Order = 1)]
        public int QuestionId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TopicId { get; set; }
    }
}
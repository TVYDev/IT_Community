using CommunityWeb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityWeb.ViewModels
{
    /*
    This viewModel is created to be the model for "Ask" view
    We need a list of topics in "Ask" view, and we don't want to change the "Question" model class
    So it is good practice to create this viewModel
    */
    public class QuestionViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "ចំណងជើង")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "ការពិព័ណ៌នា")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "ប្រធានបទ")]
        public int TopicId { get; set; }

        public IEnumerable<Topic> Topics { get; set; }
    }
}
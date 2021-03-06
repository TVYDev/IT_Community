﻿using CommunityWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityWeb.ViewModels
{
    public class AnswerViewModel
    {
        public Question Question { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionTopicDetail> Topics { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityWeb.ViewModels
{
    public class ChatViewModel
    {       
        public int chatID { get; set; }
        public string body { get; set; }
        public DateTime sentDate { get; set; }

    }
}
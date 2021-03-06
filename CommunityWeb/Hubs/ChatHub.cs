﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRTest.Hubs
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }


        public void SendNotification(string author, string message)
        {
            Clients.All.broadcastNotification(author, message);
        }
    }
}
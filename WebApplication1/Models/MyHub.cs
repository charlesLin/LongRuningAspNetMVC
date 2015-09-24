using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication1.Models
{
    public class MyHub : Hub
    {
        public void Report(string message)
        {
            Clients.All.report(message);
        }
    }
}
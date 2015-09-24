using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HostingEnvironment.QueueBackgroundWorkItem(t =>
            {
                new Processor().LongWork();
            });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class Processor
    {
        public void LongWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                var hub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                hub.Clients.All.report("step " + i.ToString());
            }

        }
    }
}
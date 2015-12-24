using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcQuartzNetTest.Scheduler;
using Quartz;
using Quartz.Impl.Matchers;

namespace MvcQuartzNetTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var sched = DefaultScheduler.GetScheduler();

            var executingJobs = sched.GetTriggerKeys(GroupMatcher<TriggerKey>.AnyGroup());
            foreach (var job in executingJobs)
            {
                sched.UnscheduleJob(new TriggerKey(job.Name));
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
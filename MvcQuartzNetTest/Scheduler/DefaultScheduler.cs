using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.Quartz;
using Autofac.Integration.Mvc;
using MvcQuartzNetTest.Jobs;
using MvcQuartzNetTest.Models;
using MvcQuartzNetTest.Triggers;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace MvcQuartzNetTest.Scheduler
{
    public class DefaultScheduler
    {
        public static void Start()
        {
            var config = (NameValueCollection)ConfigurationManager.GetSection("quartz");

            ISchedulerFactory schedFact = new StdSchedulerFactory(config);

            var sched = schedFact.GetScheduler();

            var scoppe = AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<AutofacJobFactory>();

            sched.JobFactory = scoppe;

            sched.Start();

            //var trigger = QuartzTrigger.GetDefaultTrigger();
            
            //var job = DataJob.BuildJob();

            var serTest = new SerializationTestModel
            {
                Age = 32,
                Name = "Artem",
                Adress = new Adress
                {
                    Street = "Beregovogo",
                    Number = 25
                }
            };

            var testJobSer = JsonConvert.SerializeObject(serTest);

            var job = JobBuilder.Create<IJob>()
                    .WithIdentity("QProcJob", "A3Group")
                    .UsingJobData("dataValue", 4444)
                    .UsingJobData("anotherValue", 77777)
                    .UsingJobData("ser", testJobSer)
                    .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("QProcTrigger", "A3Group")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();


            sched.ScheduleJob(job, trigger);
        }

        public static IScheduler GetScheduler()
        {
            var config = (NameValueCollection)ConfigurationManager.GetSection("quartz");
            ISchedulerFactory schedFact = new StdSchedulerFactory(config);
            return schedFact.GetScheduler();
        }
    }
}

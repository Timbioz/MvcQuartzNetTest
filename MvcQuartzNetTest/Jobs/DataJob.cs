using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.Quartz;
using Autofac.Integration.Mvc;
using MvcQuartzNetTest.Models;
using MvcQuartzNetTest.Services;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;

namespace MvcQuartzNetTest.Jobs
{
    public class DataJob : IJob
    {

        

        private readonly IDataService _service;
        private readonly IAnoterService _anoterService;

        public DataJob(IDataService service, IAnoterService anoterService)
        {
            _service = service;
            _anoterService = anoterService;
        }

        public void Execute(IJobExecutionContext context)
        {

            var dataMap = context.JobDetail.JobDataMap;

            var dataValue = dataMap.GetIntValue("dataValue");
            var anotherValue = dataMap.GetIntValue("anotherValue");
            var testSer = dataMap.GetString("ser");

            var m = JsonConvert.DeserializeObject<SerializationTestModel>(testSer);

            var rand = new Random();

            using (var db = new DataDbContext())
            {
                var model = new DataModel
                {
                    UserId = rand.Next(),
                    Name = $"Name {m.Name}. Street: {m.Adress.Street} - {m.Adress.Number}",
                    Time = DateTime.Now.ToString("HH:mm:ss")
                };

                db.DataModels.Add(model);
                db.SaveChanges();
            }
            Debug.WriteLine("Перед Процесс пошел");

            var container = _service;

            //var service = AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<IDataService>();

            _service.AddData(m.Age);
            _anoterService.AddData(anotherValue);
        }

        public static IJobDetail BuildJob()
        {
            var job = JobBuilder.Create<DataJob>().Build();
            return job;
        }
    }
}

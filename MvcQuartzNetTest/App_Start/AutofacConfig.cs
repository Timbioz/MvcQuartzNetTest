using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.Quartz;
using Autofac.Integration.Mvc;
using MvcQuartzNetTest.Jobs;
using MvcQuartzNetTest.Services;
using Quartz;

namespace MvcQuartzNetTest
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new QuartzAutofacFactoryModule());

            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(DataJob).Assembly));

            builder.RegisterType<DataJob>().As<IJob>().InstancePerLifetimeScope();

            builder.RegisterType<DataService>().As<IDataService>().InstancePerLifetimeScope();
            builder.RegisterType<AnoterService>().As<IAnoterService>().InstancePerLifetimeScope();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

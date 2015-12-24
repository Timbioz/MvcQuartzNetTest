using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace MvcQuartzNetTest.Triggers
{
    public class QuartzTrigger
    {
        public static ITrigger GetDefaultTrigger()
        {
            var trigger = TriggerBuilder.Create()
                                .StartNow()
                                .WithSimpleSchedule(x => x
                                    .WithIntervalInSeconds(5)
                                    .RepeatForever())
                                .Build();

            return trigger;
        }
    }
}

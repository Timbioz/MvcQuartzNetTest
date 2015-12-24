using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcQuartzNetTest.Models
{
    public class DataDbContextInitializer : DropCreateDatabaseIfModelChanges<DataDbContext>
    {
        protected override void Seed(DataDbContext context)
        {

            var model = new List<DataModel>
            {
                new DataModel
                {
                    UserId = 113490963846, Name = "Steeve", Time = DateTime.Now.ToString("HH:mm:ss")
                },
                new DataModel
                {
                    UserId = 34578907346907, Name = "Gibson", Time = DateTime.Now.ToString("HH:mm:ss")
                },
                new DataModel
                {
                    UserId = 34878922934492, Name = "Harry", Time = DateTime.Now.ToString("HH:mm:ss")
                },
                new DataModel
                {
                    UserId = 695978447733, Name = "Bill", Time = DateTime.Now.ToString("HH:mm:ss")
                },
                new DataModel
                {
                    UserId = 9777463563635, Name = "Artem", Time = DateTime.Now.ToString("HH:mm:ss")
                }
            };

            context.DataModels.AddRange(model);

            context.SaveChanges();
        }
    }
}

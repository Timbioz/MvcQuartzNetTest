using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcQuartzNetTest.Models;

namespace MvcQuartzNetTest.Services
{
    public interface IAnoterService
    {
        void AddData(int id);
    }

    public class AnoterService : IAnoterService
    {
        public void AddData(int id)
        {
            using (var db = new DataDbContext())
            {
                var model = new DataModel
                {
                    UserId = id,
                    Name = $"Another {id}",
                    Time = DateTime.Now.ToString("HH:mm:ss")
                };

                db.DataModels.Add(model);
                db.SaveChanges();
            }

            Debug.WriteLine("Процесс пошел");
        }
    }
}

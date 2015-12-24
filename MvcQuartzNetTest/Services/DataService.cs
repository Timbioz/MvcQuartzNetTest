using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcQuartzNetTest.Models;

namespace MvcQuartzNetTest.Services
{
    public interface IDataService
    {
        void AddData(int id);
    }

    public class DataService : IDataService
    {
        public void AddData(int id)
        {
            using (var db = new DataDbContext())
            {
                var model = new DataModel
                {
                    UserId = id, Name = $"Autofac {id}", Time = DateTime.Now.ToString("HH:mm:ss")
                };

                db.DataModels.Add(model);
                db.SaveChanges();
            }

            Debug.WriteLine("Процесс пошел");
        }
    }
}

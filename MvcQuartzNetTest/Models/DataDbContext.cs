using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcQuartzNetTest.Models
{
    public class DataDbContext : DbContext
    {
        public DataDbContext() : base("DataDbContext")
        {
            Database.SetInitializer(new DataDbContextInitializer());
        }

        public DbSet<DataModel> DataModels { get; set; }
    }
}

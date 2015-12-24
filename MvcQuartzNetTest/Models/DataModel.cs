using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcQuartzNetTest.Models
{
    public class DataModel
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}

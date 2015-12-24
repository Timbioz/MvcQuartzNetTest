using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcQuartzNetTest.Models
{
    [Serializable]
    public class SerializationTestModel
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Adress Adress { get; set; }
    }

    public class Adress
    {
        public string Street { get; set; }
        public int Number { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHelperDB.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public float Proteine { get; set; }

        public float Calories { get; set; }

        public float Fat { get; set; }
    }
}


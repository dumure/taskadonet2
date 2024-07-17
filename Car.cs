using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_ado_2
{
    internal class Car
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public override string ToString()
        {
            return $"{Mark}: {Model}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    abstract class Detail
    {
        protected Detail(double weight, string name)
        {
            Weight = weight;
            Name = name;
        }

        public double Weight { get; private set; }
        public string Name { get; private set; }
    }
}

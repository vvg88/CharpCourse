using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    abstract class Detail
    {
        public abstract double Weight { get; protected set; }
        public abstract string Name { get; protected set; }
    }
}

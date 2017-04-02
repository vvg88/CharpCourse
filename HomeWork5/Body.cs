using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Body : Detail, IRotatable, IDoor
    {
        public Body(double weight)
        {
            Name = "Рама";
            Weight = weight;
        }

        public override double Weight { get; protected set; }
        public override string Name { get; protected set; }

        public void Move(string carModel)
        {
            Console.WriteLine($"Машина {carModel} едет.");
        }

        public void Open(string carModel)
        {
            Console.WriteLine("Увы, это не дверь.");
        }
    }
}

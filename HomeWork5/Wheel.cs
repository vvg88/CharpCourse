using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Wheel : Detail, IRotatable
    {
        public Wheel(uint number, double weight) : base(weight, "Колесо")
        {
            Number = number;
        }

        public uint Number { get; private set; }

        public void Move(string carModel)
        {
            Console.WriteLine($"Колесо №{Number} машины {carModel} вращается.");
        }
    }
}

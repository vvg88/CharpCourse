using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Door : Detail, IDoor
    {
        public Door(uint number, double weight)
        {
            Name = "Дверь";
            Weight = weight;
            Number = number;
        }

        public override double Weight { get; protected set; }
        public override string Name { get; protected set; }

        public uint Number { get; private set; }

        private bool isOpened;

        public void Open(string carModel)
        {
            Console.WriteLine($"Дверь №{Number} машины {carModel} {(isOpened ? "закрыта" : "открыта")}.");
            isOpened = !isOpened;
        }
    }
}

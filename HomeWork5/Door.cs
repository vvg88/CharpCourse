using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Door : Detail, IDoor
    {
        public Door(uint number, double weight) : base(weight, "Дверь")
        {
            Number = number;
        }

        public uint Number { get; private set; }

        /// <summary>
        /// Признак открытия двери
        /// </summary>
        private bool isOpened;

        public void Open(string carModel)
        {
            Console.WriteLine($"Дверь №{Number} машины {carModel} {(isOpened ? "закрыта" : "открыта")}.");
            isOpened = !isOpened;
        }
    }
}

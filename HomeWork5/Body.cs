using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    /// <summary>
    /// Класс рама
    /// </summary>
    class Body : Detail, IRotatable, IDoor
    {
        public Body(double weight) : base (weight, "Рама")
        { }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Car : Detail
    {
        public Car(string model, uint numOfWheels, uint numOfDoors,
                   double carWeight = 1500, double doorWeight = 35.5, double wheelWeight = 15.4, double bodyWeight = 356.7)
        {
            Name = "Автомобиль";
            Weight = carWeight;
            Model = model;

            var carDetailsArray = new Detail[numOfDoors + numOfWheels + 1];     // Инициализировать коллекцию деталей автомобиля
            for (int i = 0; i < numOfDoors; i++)
            {
                carDetailsArray[i] = new Door((uint)i, doorWeight);
            }
            for (uint i = numOfDoors; i < numOfDoors + numOfWheels; i++)
            {
                carDetailsArray[i] = new Wheel(i - numOfDoors, wheelWeight);
            }
            carDetailsArray[numOfDoors + numOfWheels] = new Body(bodyWeight);
        }

        public override double Weight { get; protected set; }
        public override string Name { get; protected set; }

        public string Model { get; private set; }
        
        IReadOnlyCollection<Detail> carDetailsArray;
    }
}

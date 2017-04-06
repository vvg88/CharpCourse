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
                   double carWeight = 1500, double doorWeight = 35.5, double wheelWeight = 15.4,
                   double bodyWeight = 356.7)
                    : base(carWeight, "Автомобиль")
        {
            Model = model;
            var carDetailsArray = new Detail[numOfDoors + numOfWheels + 1];     // Инициализировать коллекцию деталей автомобиля
            for (uint i = 0; i < numOfDoors; i++)                               // Создать указанное число дверей
            {
                carDetailsArray[i] = new Door(i + 1, doorWeight);
            }
            for (uint i = numOfDoors; i < numOfDoors + numOfWheels; i++)        // Создать указанное число колес
            {
                carDetailsArray[i] = new Wheel(i - numOfDoors + 1, wheelWeight);
            }
            carDetailsArray[numOfDoors + numOfWheels] = new Body(bodyWeight);   // Добавить раму
            this.carDetailsArray = carDetailsArray;
        }

        /// <summary>
        /// Название модели автомобиля
        /// </summary>
        public string Model { get; private set; }
        
        /// <summary>
        /// Коллекция деталей автомобиля
        /// </summary>
        public IReadOnlyCollection<Detail> carDetailsArray { get; private set; }
    }
}

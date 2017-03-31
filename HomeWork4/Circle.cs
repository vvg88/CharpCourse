using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    class Circle : Sector
    {
        public Circle(double radius) : base(radius, 2 * Math.PI, "Круг")
        {
            perimeterOfShape = archLength;
        }
    }

    class Sector : Shape
    {
        public Sector(double radius, double angle) : this(radius, angle, "Сектор")
        { }

        protected Sector(double radius, double angle, string shapeName) : base(shapeName)
        {
            areaOfShape = angle * radius * radius / 2;
            archLength = angle * radius;
            perimeterOfShape = archLength + 2 * radius;
        }

        /// <summary>
        /// Длина дуги окружности сектора
        /// </summary>
        protected double archLength;
    }
}

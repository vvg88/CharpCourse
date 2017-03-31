using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork4
{
    class Triangle : Shape
    {
        /// <summary>
        /// Конструктор, который получает координаты вершин треугольника
        /// </summary>
        public Triangle(Point vertexA, Point vertexB, Point vertexC) : base("Треугольник")
        {
            Vector sideAB = vertexB - vertexA;      // Получить стороны треугольника
            Vector sideAC = vertexC - vertexA;
            Vector sideBC = vertexC - vertexB;

            perimeterOfShape = sideAB.Length + sideAC.Length + sideBC.Length;

            // Вычислить площадь треугольника по формуле Герона
            var halfOfPerimeter = perimeterOfShape / 2;
            areaOfShape = Math.Sqrt(halfOfPerimeter
                                    * (halfOfPerimeter - sideAB.Length)
                                    * (halfOfPerimeter - sideAC.Length)
                                    * (halfOfPerimeter - sideBC.Length));
        }
    }
}

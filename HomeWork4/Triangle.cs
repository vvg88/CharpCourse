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

            Console.WriteLine($"Точка А({vertexA.X}, {vertexA.Y})");
            Console.WriteLine($"Точка B({vertexB.X}, {vertexB.Y})");
            Console.WriteLine($"Точка C({vertexC.X}, {vertexC.Y})");

            Console.WriteLine($"Вектор АB({sideAB.X}, {sideAB.Y})");
            Console.WriteLine($"Вектор AC({sideAC.X}, {sideAC.Y})");
            Console.WriteLine($"Вектор BC({sideBC.X}, {sideBC.Y})");

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

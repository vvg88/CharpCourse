using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapesArray = new Shape[]
            {
                new Rectangle(5, 6),
                new Square(3),
                new Sector(4, Math.PI / 1.3),
                new Circle(5),
                new Triangle(new Point(1, 2), new Point(5, 2), new Point(3, 6))
            };

            foreach (var shape in shapesArray)
            {
                Console.WriteLine($"Название фигуры: {shape.GetShapeName():F2}.");
                Console.WriteLine($"Площадь фигуры: {shape.GetShapeArea():F2}.");
                Console.WriteLine($"Периметр фигуры: {shape.GetShapePerimeter():F2}.\n");
            }

            Console.ReadLine();
        }
    }
}

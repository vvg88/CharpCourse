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
                new Triangle(new Point(1, 2), new Point(5, 2), new Point(3, 6))
            };

            foreach (var shape in shapesArray)
            {
                Console.WriteLine($"Название фигуры: {shape.GetShapeName()}.");
                Console.WriteLine($"Площадь фигуры: {shape.GetShapeArea()}.");
                Console.WriteLine($"Периметр фигуры: {shape.GetShapePerimeter()}.");
            }

            Console.ReadLine();
        }
    }
}

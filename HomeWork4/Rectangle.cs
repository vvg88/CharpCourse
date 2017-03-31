using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    class Rectangle : Shape
    {
        public Rectangle(double rectWidth, double rectLength) : this(rectWidth, rectLength, "Прямоугольник")
        { }

        protected Rectangle(double rectWidth, double rectLength, string shapeName) : base(shapeName)
        {
            areaOfShape = rectWidth * rectLength;
            perimeterOfShape = 2 * rectWidth + 2 * rectLength;
        }
    }

    class Square : Rectangle
    {
        public Square(double sideLength) : base(sideLength, sideLength, "Квадрат")
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    abstract class Shape
    {
        public Shape(string shapeName)
        {
            nameOfShape = shapeName;
        }

        protected string nameOfShape;
        protected double areaOfShape;
        protected double perimeterOfShape;

        public virtual string GetShapeName()
        {
            return nameOfShape != null && nameOfShape != string.Empty ? nameOfShape : "Имя формы неизвестно!";
        }

        public virtual double GetShapeArea()
        {
            return areaOfShape;
        }

        public virtual double GetShapePerimeter()
        {
            return perimeterOfShape;
        }
    }
}

using System;

namespace Figures
{
    public class Rectangle
    {
        protected int _height;
        protected int _width;

        public void SetHeight(int height)
        {
            _height = height;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }

        //public double GetArea()
        //{
        //    return _height * _width;
        //}
        
        public float GetArea()
        {
            return new Area().GetRectangleArea(_height , _width);
        }
    }

    public class Area
    {
        public float GetRectangleArea(float height, float width)
        {
            return height * width;
        }
    }
}
namespace Figures
{
    public class Square /*: Rectangle*/
    {
        private int _side;

        public void SetSide(int side)
        {
            //SetHeight(side);
            //SetWidth(side);
            _side = side;
        }

        public float GetArea()
        {
            return new Area().GetRectangleArea(_side, _side);
        }
    }

}
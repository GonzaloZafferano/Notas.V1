using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dimension
    {
        private int verticalY;
        private int horizontalX;

        public Dimension(int verticalY, int horizontalX)
        {
            this.verticalY = verticalY;
            this.horizontalX = horizontalX;
        }

        public int VerticalY { get => verticalY; set => verticalY = value; }
        public int HorizontalX { get => horizontalX; set => horizontalX = value; }
    }
}

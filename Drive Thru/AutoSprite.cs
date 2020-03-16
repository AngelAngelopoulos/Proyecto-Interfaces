using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive_Thru
{
    class AutoSprite
    {
        public int noImg;
        public Rectangle fitImg;


        public AutoSprite(int no_Img, Rectangle rect)
        {
            noImg = no_Img;
            fitImg = rect;
        }
    }
}

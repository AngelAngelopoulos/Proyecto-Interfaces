using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Drive_Thru
{
    class Hilo
    {
        Thread t;

        public void initHilo(PaintEventArgs e)
        {
            t = new Thread(new ParameterizedThreadStart(drawRectangle));
            t.Start(e);
        }

        public void drawRectangle(Object a)
        {
            PaintEventArgs e = (PaintEventArgs)a;
            
            //e.Graphics.FillRectangle(bru, i, 10, 100, 200);
            //e.Graphics.DrawRectangle(pen, i, 10, 100, 200);
            /*i++;
            if (i >= Form1.ActiveForm.Width - 100)
                i--;*/
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace dxLoop
{
    class DxBG
    {
        DxImageObject[] frm = new DxImageObject[2];
        int t;
        DxImageObject backgroundobj;
        DxInitGraphics graphics;
        public DxBG(DxImageObject[] f, DxImageObject bg, DxInitGraphics g)
        {
            frm = f;
            graphics = g;
            backgroundobj = bg;
            t = 0;
        }

        public void run()
        {
            t -= 10;
            if (t > backgroundobj.Width)
            {
                /*Rectangle r1 = new Rectangle(t, 0, backgroundobj.Width - t, backgroundobj.Height);
                Rectangle r2 = new Rectangle(0, 0, t, backgroundobj.Height);
                frm[0].DrawBitmap(0,0,r1,graphics.RenderSurface);
                frm[1].DrawBitmap(backgroundobj.Width - t, 0, r2, graphics.RenderSurface);*/
                Rectangle r1 = new Rectangle(t - backgroundobj.Width, 0, 2 * backgroundobj.Width - t, backgroundobj.Height);
                Rectangle r2 = new Rectangle(0, 0, t - backgroundobj.Width, backgroundobj.Height);
                frm[0].DrawBitmap(0, 0, r1, graphics.RenderSurface);
                frm[1].DrawBitmap(2* backgroundobj.Width - t, 0, r2, graphics.RenderSurface);
            }
            else //if(t>0)
            {
                t = 2 * backgroundobj.Width;
            }
        }

    }
}

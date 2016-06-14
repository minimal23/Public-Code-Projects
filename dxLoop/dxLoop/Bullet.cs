using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dxLoop
{
    class Bullet
    {
        protected DxInitGraphics graphics;
        private DxImageObject bullet;
        private double XPos;
        private double YPos;
        private bool launched = false;
        public Bullet(string imgpath, DxInitGraphics g)
        {
            graphics = g;
            bullet = new DxImageObject(imgpath, BitmapType.TRANSPARENT, 0, graphics.DDDevice);
            XPos = bullet.XPosition = 50;
            YPos = bullet.YPosition = 300;
        }
        public new void Draw()
        {
            if (!launched)
            {
                //bullet.XPosition = ;
                //bullet.YPosition = ;
            }
                bullet.DrawBitmap(graphics.RenderSurface);
        }
        private void checkBounds()
        {
            if (XPos > 640-47)
            {
                XPos = 50;
                launched = false;
            }
        }
        public void move()
        {
            if (launched)
            {
                XPos += 10;
                checkBounds();
                bullet.XPosition = XPos + 30;
            }
        }
        public void Launch()
        {
            launched = true;
        }
    }
}

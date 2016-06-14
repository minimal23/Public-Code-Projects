using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dxLoop
{
    class Cat
    {
        private DxInitGraphics graphics;
        private DxImageObject cat;
        protected static double XPos;
        protected static double YPos;
        protected double XPad;
        protected double YPad;
        public Cat()
        {

        }
        public Cat(string path, DxInitGraphics g)
        {
            graphics = g;
            cat = new DxImageObject(path, BitmapType.TRANSPARENT, 0, graphics.DDDevice);
            XPos = cat.XPosition = 50;
            YPos = cat.YPosition = 300;
        }
        public void Draw()
        {
            cat.DrawBitmap(graphics.RenderSurface);
        }
        public void moveLeft()
        {
            if (cat.XPosition > 0)
            {
                this.cat.XPosition -= 10;
                XPad -= 10;
            }
            else this.cat.XPosition -= 0;
        }
        public void moveRight()
        {
            if (cat.XPosition < (640 - cat.Width))
            {
                this.cat.XPosition += 10;
                XPad += 10;
            }
            else this.cat.XPosition += 0;
        }
        public double X
        {
            get
            {
                return cat.XPosition;
            }
        }
        public double Y
        {
            get
            {
                return cat.YPosition;
            }
        }
        public double Width
        {
            get
            {
                return cat.Width;
            }
        }
        public double Height
        {
            get
            {
                return cat.Height;
            }
        }
    }
}

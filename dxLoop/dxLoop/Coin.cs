using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;
using System.Windows.Forms;

namespace dxLoop
{
    class Coin
    {
        private DxInitGraphics graphics;
        private DxImageObject coin;
        private double XPos;
        private double YPos;
        private double direction = 10;
        public bool checkcollision = false;
        public Coin(string path, DxInitGraphics g)
        {
            graphics = g;
            coin = new DxImageObject(path, BitmapType.TRANSPARENT, 0, graphics.DDDevice);
            XPos = coin.XPosition = 400;
            YPos = coin.YPosition = 396;
        }
        public void Draw()
        {
            if (!checkcollision)
            {
                coin.DrawBitmap(graphics.RenderSurface);
            }
        }
        public void collide(Cat obj)
        {
            if (obj.X + obj.Width >= XPos)
                checkcollision = true;
        }
        public double X
        {
            get
            {
                return coin.XPosition;
            }
            set
            {
                coin.XPosition = value;
            }
        }
        public double Y
        {
            get
            {
                return coin.YPosition;
            }
            set
            {
                coin.YPosition = value;
            }
        }
        public void move()
        {
            coin.YPosition += direction;
            if (coin.YPosition > 430)
            {
                coin.YPosition = 430;
                direction = -10;
            }
            if (coin.YPosition < 0)
            {
                coin.YPosition = 0;
                direction = 10;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dx_game_demo
{
    class SnakeHead
    {
        private DxInitGraphics graphics;
        private DxImageObject head;
        protected double XPos;
        protected double YPos;
        public SnakeHead(string path, DxInitGraphics g)
        {
            graphics = g;
            head = new DxImageObject(path, BitmapType.SOLID, 0, graphics.DDDevice);
            XPos = head.XPosition = 100;
            YPos = head.YPosition = 100;
        }
        public void Draw()
        {
            head.DrawBitmap(graphics.RenderSurface);
        }
        public void MoveUp()
        {
            this.head.YPosition -= 5;
        }
        public void MoveLeft()
        {
            this.head.XPosition -= 5;
        }
        public void MoveRight()
        {
            this.head.XPosition += 5;
        }
        public void MoveDown()
        {
            this.head.YPosition += 5;
        }
        public double X
        {
            get
            {
                return head.XPosition;
            }
        }
        public double Y
        {
            get
            {
                return head.YPosition;
            }
        }
        public double Width
        {
            get
            {
                return head.Width;
            }
        }
        public double Height
        {
            get
            {
                return head.Height;
            }
        }
    }
}

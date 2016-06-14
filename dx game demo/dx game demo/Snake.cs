using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dx_game_demo
{
    class Snake
    {
        List<DxImageObject> snake = new List<DxImageObject>();
        private DxInitGraphics graphics;
        private DxImageObject snakebody;
        public int count = 0;

        public Snake(List<DxImageObject> s, DxImageObject body, DxInitGraphics g)
        {
            snake = s;
            graphics = g;
            snakebody = body;
            for (int i=0;i<5;i++)
            {
                s.Add(null);
                snake[i] = new DxImageObject(Application.StartupPath + "\\sprites\\snake body.png", BitmapType.SOLID, 0, graphics.DDDevice);
            }
            
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    snake[i].XPosition = 100;
                    snake[i].YPosition = 200;
                }
                else
                {
                    snake[i].XPosition = snake[i - 1].XPosition;
                    snake[i].YPosition = snake[i - 1].YPosition + snake[i - 1].Height;
                }
            }
        }
        public void Draw()
        {
            //snake[0].DrawBitmap(graphics.RenderSurface);
            for (int i=0;i<5;i++)
            snake[i].DrawBitmap(graphics.RenderSurface);
        }
        public void MoveUp()
        {
            //snake[4].YPosition = snake[0].YPosition-snake[0].Height;
            //snake[0].YPosition -= 5;
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    //snake[i].XPosition = 100;
                    snake[i].YPosition -= 25 ;
                }
                else
                {
                    snake[i].XPosition = snake[i - 1].XPosition;
                    snake[i].YPosition = snake[i - 1].YPosition + 25;
                }
            }
        }
        public void MoveLeft()
        {
            //snake[4].XPosition = snake[0].XPosition - snake[0].Width;
            snake[0].XPosition -= 5;
        }
        public void MoveRight()
        {
            //snake[4].XPosition = snake[0].XPosition - snake[0].Width;
            //snake[0].XPosition += 5;
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    snake[i].XPosition +=25;
                    //snake[i].YPosition -= 25;
                }
                else
                if (count == i-1)
                {
                    snake[i].XPosition = snake[i - 1].XPosition - 25;
                    snake[i].YPosition = snake[i - 1].YPosition;
                    if (snake[i].YPosition - snake[i - 1].YPosition==25) count++;
                }
                else
                {
                    snake[i].XPosition = snake[i - 1].XPosition;
                    snake[i].YPosition = snake[i - 1].YPosition + 25;
                }
            }
        }
        public void MoveDown()
        {
            //snake[4].YPosition = snake[0].YPosition + snake[0].Height;
            snake[0].YPosition += 5;
        }
    }
}

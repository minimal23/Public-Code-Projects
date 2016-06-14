using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;

namespace dx_game_demo
{
    public enum GameStates
    {
        Run = 0,
        Exit = 1
    }
    class GameLogic
    {
        protected Control target;
        protected DxInitGraphics graphics = null;
        protected DxKeyboard input;
        protected GameStates gameState;
        protected DxTimer t = new DxTimer();
        protected DxImageObject snakebody;
        protected DxImageObject bg;
        protected List<DxImageObject> snake = new List<DxImageObject>(5);
        protected Snake s;
        protected SnakeHead h;
        public GameLogic(Control RenderTarget)
        {
            target = RenderTarget;
            target.GotFocus += new System.EventHandler(this.restore);
            graphics = new DxInitGraphics(this.target);
            gameLoop();
        }
        protected void restore(object Sender, System.EventArgs e)
        {
            this.graphics = new DxInitGraphics(this.target);
        }
        protected void initImages()
        {
            snakebody = new DxImageObject(Application.StartupPath + "\\sprites\\snake body.png", BitmapType.SOLID, 0, graphics.DDDevice);
            bg = new DxImageObject(Application.StartupPath + "\\sprites\\bg.png", BitmapType.SOLID, 0, graphics.DDDevice);
            //snake[0] = new DxImageObject(Application.StartupPath + "\\sprites\\snake body.png", BitmapType.SOLID, 0, graphics.DDDevice);
            s = new Snake(snake, snakebody, graphics);
            //h = new SnakeHead(Application.StartupPath + "\\sprites\\snake body.png", graphics);
        }
        protected void gameLoop()
        {
            t.Init();
            initImages();
            while (target.Created)
            {
                if (!target.Focused)
                {
                    System.Threading.Thread.Sleep(1000);
                    Application.DoEvents();
                    continue;
                }
                this.processInput();
                if (gameState == GameStates.Run)
                {
                    bg.DrawBitmap(graphics.RenderSurface);
                    //h.Draw();
                    s.Draw();
                }
                if (gameState == GameStates.Exit)
                {
                    return;
                }
                graphics.Flip();
                Application.DoEvents();
            }
        }
        protected void processInput()
        {
            KeyboardState state;
            input = new DxKeyboard(target);
            state = this.input.GetkeyboardState();
            if (state != null)
            {
                if (state[Key.Escape])
                {
                    gameState = GameStates.Exit;
                }
                if (state[Key.Left])
                {
                    s.MoveLeft();
                }
                if (state[Key.Right])
                {
                    s.MoveRight();
                }
                if (state[Key.Up])
                {
                    s.MoveUp();
                }
                if (state[Key.Down])
                {
                    s.MoveDown();
                }
            }
        }
    }
}


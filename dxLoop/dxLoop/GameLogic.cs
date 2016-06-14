using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;

namespace dxLoop
{
    public enum GameStates
    {
        Run = 0,
        Exit =1
    }
    class GameLogic
    {
        protected Control target;
        protected DxInitGraphics graphics=null;
        protected DxKeyboard input;
        protected GameStates gameState;
        protected DxImageObject bg;
        protected DxImageObject[] bgarr = new DxImageObject[2];
        protected DxBG bgloop;
        protected DxTimer t = new DxTimer();
        protected DxImageObject[] frm = new DxImageObject[10];
        protected DxAnimationMF girl;
        protected DxAnimationSF catsf;
        protected Cat cat;
        protected Coin coin;
        protected Coin coin2;
        protected Bullet bullet;
        public GameLogic(Control RenderTarget)
        {
            target = RenderTarget;
            target.GotFocus += new System.EventHandler(this.restore);
            graphics = new DxInitGraphics(this.target);
            gameLoop();
        }
        protected void initImages()
        {
            this.bg = new DxImageObject(Application.StartupPath + "\\sprites\\bg.png", 0, 0, graphics.DDDevice);
            bgarr[0] = bg;
            bgarr[1] = bg;
            bgloop = new DxBG(bgarr, bg, graphics);
            cat = new Cat(Application.StartupPath + "\\sprites\\cat2.png", graphics);
            coin = new Coin(Application.StartupPath + "\\sprites\\coin.png", graphics);
            coin2 = new Coin(Application.StartupPath + "\\sprites\\coin.png", graphics);
            coin2.X = 400;
            coin2.Y = 100;
            bullet = new Bullet(Application.StartupPath + "\\sprites\\bullet.png", graphics);
            for (int i = 0; i < frm.Length; i++)
            {
                frm[i] = new DxImageObject(Application.StartupPath + "\\sprites\\animation1\\" + i + ".png", BitmapType.TRANSPARENT, 0, graphics.DDDevice);
            }
            girl = new DxAnimationMF(frm, 20, graphics);
            catsf = new DxAnimationSF(Application.StartupPath + "\\sprites\\animation1\\cat.png", 1, 6, 16, graphics); 
        }
        protected void restore(object Sender, System.EventArgs e)
        {
            this.graphics = new DxInitGraphics(this.target);
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
                if (gameState==GameStates.Run)
                {
                    //bg.DrawBitmap(graphics.RenderSurface);
                    //bullet.Draw();
                    bgloop.run();
                    cat.Draw();
                    coin.Draw();
                    coin2.Draw();
                    coin2.move();
                    //bullet.move();
                    coin.collide(cat);
                    coin2.collide(cat);
                    girl.Play(200,300,Animate.Continuous);
                    catsf.Play(100, 100, Animate.Continuous);
                }
                if (gameState==GameStates.Exit)
                {
                    return;
                }
                graphics.Flip();
                //System.Threading.Thread.Sleep(1000);
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
                    cat.moveLeft();
                }
                if (state[Key.Right])
                {
                    cat.moveRight();
                }
                if (state[Key.Space])
                {
                    bullet.Launch();
                }
            }
        }
    }
}

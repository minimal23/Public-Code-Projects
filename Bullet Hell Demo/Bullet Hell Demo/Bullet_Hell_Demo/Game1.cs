using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Bullet_Hell_Demo
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player p = new Player();
        BG bg = new BG();
        List<Enemy> enemyList = new List<Enemy>();
        Random random = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 480;
            this.Window.Title = "Prepare to die !";
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            p.LoadContent(Content);
            bg.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            foreach (Enemy e in enemyList)
            {
                for (int i = 0; i < e.bulletList.Count; i++)
                {
                    if (p.boundingBox.Intersects(e.bulletList[i].boundingBox))
                    {
                        e.bulletList[i].isVisible = false;
                    }
                }

                for (int i=0;i<p.bulletList.Count;i++)
                {
                    if (e.boundingBox.Intersects(p.bulletList[i].boundingBox))
                    {
                        p.bulletList[i].isVisible = false;
                        e.isVisible = false;
                    }
                }
                e.Update(gameTime);
            }
            p.Update(gameTime);
            bg.Update(gameTime);
            LoadEnemies();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            bg.Draw(spriteBatch);
            p.Draw(spriteBatch);
            foreach (Enemy e in enemyList)
            {
                e.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void LoadEnemies()
        {
            int rndX = random.Next(0, 380);
            int rndY = random.Next(-500, -100);

            if(enemyList.Count() < 3)
            {
                enemyList.Add(new Enemy(Content.Load<Texture2D>("enemy"), new Vector2(rndX, rndY), Content.Load<Texture2D>("enemybullet")));
            }
            
            for (int i=0;i<enemyList.Count;i++)
            {
                if (!enemyList[i].isVisible)
                {
                    enemyList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}

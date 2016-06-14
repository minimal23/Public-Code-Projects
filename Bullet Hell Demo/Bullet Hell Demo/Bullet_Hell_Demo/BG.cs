using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Bullet_Hell_Demo
{
    public class BG
    {
        public Texture2D texture;
        public Vector2 pos1, pos2;
        public int speed;

        public BG()
        {
            texture = null;
            pos1 = new Vector2(0, -1);
            pos2 = new Vector2(0, -640);
            speed = 5;
        }

        public void LoadContent (ContentManager Content)
        {
            texture = Content.Load<Texture2D>("bg");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos1, Color.White);
            spriteBatch.Draw(texture, pos2, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            pos1.Y = pos1.Y + speed;
            pos2.Y = pos2.Y + speed;

            if (pos1.Y >= 640)
            {
                pos1.Y = -1;
                pos2.Y = -640;
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Apple : AppleManager
    {
        public Vector2 Position { get; set; }
        public bool IsCollected { get; set; }
        public int Width { get; internal set; }
        public int Height { get; internal set; }

        private Texture2D apple;

        public Apple(Vector2 position)
        {
            Position = position;
        }

        public void LoadContent(ContentManager content)
        {
            apple = content.Load<Texture2D>("apple32");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(apple, Position, Color.White);
        }
    }
}

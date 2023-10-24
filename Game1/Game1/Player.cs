using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Player
    {
        public Vector2 Position { get; private set; }
        public float Speed { get; set; }

        private Texture2D farmer;

        public Player(Vector2 initialPosition, float speed)
        {
            Position = initialPosition;
            Speed = speed;
        }

        public void LoadContent(ContentManager content)
        {
            farmer = content.Load<Texture2D>("farmer32");
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                direction.X = -1;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                direction.X = 1;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                direction.Y = -1;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                direction.Y = 1;
            }

            Position += direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}

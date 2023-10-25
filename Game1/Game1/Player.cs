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
        public int Width { get; internal set; }
        public int Height { get; internal set; }

        private Texture2D farmer;

        private Tilemap tilemap;

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

            Vector2 newPosition = Position + direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            bool canMove = true;
            Rectangle newPlayerRect = new Rectangle((int)newPosition.X, (int)newPosition.Y, farmer.Width, farmer.Height);

            List<Rectangle> collisionRectangles = tilemap.CollisionRectangles();

            foreach (var collisionRect in collisionRectangles)
            {
                if (newPlayerRect.Intersects(collisionRect))
                {
                    canMove = false;
                    break;
                }
            }

            if (newPosition.X < 0 || newPosition.X + farmer.Width > tilemap.Width)
            {
                canMove = false;
            }
            if (newPosition.Y < 0 || newPosition.Y + farmer.Height > tilemap.Height)
            {
                canMove = false;
            }

            if (canMove)
            {
                Position = newPosition;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(farmer, Position, Color.White);
        }
    }
}

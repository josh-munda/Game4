using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class AppleManager
    {
        private List<Apple> apples = new List<Apple>();
        private Random random = new Random();

        public void Initialize(int numberOfApples, int mapWidth, int mapHeight)
        {
            for (int i = 0; i < numberOfApples; i++)
            {
                int x = random.Next(mapWidth);
                int y = random.Next(mapHeight);
                apples.Add(new Apple { Position = new Vector2(x, y), IsCollected = false });
            }
        }

        public void Update(Player player)
        {
            for (int i = 0; i < apples.Count; i++)
            {
                if (!apples[i].IsCollected)
                {
                    if (IsCollision(player, apples[i]))
                    {
                        apples[i].IsCollected = true;

                        //player.IncrementScore();

                        RepositionApple(apples[i]);
                    }
                }
            }
        }

        private void RepositionApple(Apple apple)
        {
            int x = random.Next(map.Width);
            int y = random.Next(map.Height);
            apple.Position = new Vector2(x, y);
            apple.IsCollected = false;
        }

        private bool IsCollision(Player player, Apple apple)
        {
            Rectangle playerBounds = new Rectangle(
                (int)player.Position.X,
                (int)player.Position.Y,
                player.Width,
                player.Height
            );

            Rectangle appleBounds = new Rectangle(
                (int)apple.Position.X,
                (int)apple.Position.Y,
                apple.Width,
                apple.Height
            );

            if (playerBounds.Intersects(appleBounds))
            {
                return true;
            }

            return false;
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Apple
    {
        public Vector2 Position { get; set; }
        public bool IsCollected { get; set; }
        public int Width { get; internal set; }
        public int Height { get; internal set; }
    }
}

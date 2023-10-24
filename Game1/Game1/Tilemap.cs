using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace Game1
{
    public class Tilemap
    {
        private TmxMap map;
        List<Rectangle> collisionRectangles = new List<Rectangle>();
        Texture2D pixel;
        private Texture2D tilesetImage;

        public Tilemap(TmxMap map)        
        {
            this.map = map;
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            Texture2D tilesetImage = content.Load<Texture2D>("field");

            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new[] { Color.White });

            LoadCollisionObjects(map);
        }

        private void LoadCollisionObjects(TmxMap map)
        {
            collisionRectangles = new List<Rectangle>();

            if(map.ObjectGroups.TryGetValue("collision", out var collisionLayer))
            {
                foreach (var obj in collisionLayer.Objects)
                {
                    Rectangle rect = new Rectangle(
                            (int)obj.X,
                            (int)obj.Y,
                            (int)obj.Width,
                            (int)obj.Height
                        );

                    collisionRectangles.Add(rect);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var layer in map.Layers)
            {
                for (var y = 0; y < map.Height; y++)
                {
                    for (var x = 0; x < map.Width; x++)
                    {
                        var tile = layer.Tiles[x + y * map.Width];

                        if (tile.Gid == 0)
                            continue;

                        // Find the corresponding tileset for the current tile
                        TmxTileset tileset = null;
                        foreach (var ts in map.Tilesets)
                        {
                            if (ts.FirstGid <= tile.Gid)
                            {
                                tileset = ts;
                                break;
                            }
                        }

                        if (tileset == null)
                        {
                            // Handle the case where no tileset is found for this tile's GID
                            continue;
                        }

                        // Calculate the position of the tile.
                        var position = new Vector2(x * map.TileWidth, y * map.TileHeight);

                        // Calculate the source rectangle within the tileset image
                        int localTileId = tile.Gid - tileset.FirstGid;
                        int tilesetWidth = (int)tileset.Columns;
                        int tileX = localTileId % tilesetWidth;
                        int tileY = localTileId / tilesetWidth;
                        var sourceRectangle = new Rectangle(tileX * tileset.TileWidth, tileY * tileset.TileHeight, tileset.TileWidth, tileset.TileHeight);

                        // Draw the tile using the calculated source rectangle
                        spriteBatch.Draw(tilesetImage, position, sourceRectangle, Color.White);
                    }
                }
            }
        }
    }
}

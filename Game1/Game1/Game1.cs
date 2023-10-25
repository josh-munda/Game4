using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
using System.Drawing.Text;
using TiledSharp;
using Color = Microsoft.Xna.Framework.Color;

namespace Game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private Apple _apple;
        private Tilemap _tilemap;
        private TmxMap _tmxMap;
        private Vector2 _position = new Vector2(10,10);
        private float _speed;
        private AppleManager _appleManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _tilemap = new Tilemap(_tmxMap);
            _player = new Player(_position, _speed);
            _apple = new Apple(new Vector2(300, 300));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ContentManager content = new ContentManager(Content.ServiceProvider, "Content");
            GraphicsDevice graphics = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters());

            _player.LoadContent(content);
            _apple.LoadContent(content);
            _tilemap.LoadContent(content, graphics);
            //_tmxMap = content.Load<TmxMap>("field");

            //TmxMap map = Content.Load<TmxMap>("Content/field");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _player.Update(gameTime);
            _appleManager.Update(_player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _tilemap.Draw(_spriteBatch);

            _player.Draw(_spriteBatch);

            _apple.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
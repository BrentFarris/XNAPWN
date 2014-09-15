using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		public static KeyboardState previousKeyboard;

		Platform platform = new Platform(new Rectangle(0, 400, 800, 75));

        private Texture2D up ;
        private Texture2D down ;
        private Texture2D right ;
        private Texture2D left  ;

        private Rectangle rect1 = new Rectangle(750, 400, 40, 40);
        private Rectangle rect2 = new Rectangle(750, 360, 40, 40);
        private Rectangle rect3 = new Rectangle(750, 320, 40, 40);
        private Rectangle rect4 = new Rectangle(750, 280, 40, 40);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

			// Comment the following if you don't want to see the mouse
			IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

			Player.Instance.Load(Content, "Characters/Mario");
			Projectile.StaticLoad(Content, "Effects/bullet");

            Content.Load<Texture2D>("Button/up");
            Content.Load<Texture2D>("Button/down");
            Content.Load<Texture2D>("Button/left");
            Content.Load<Texture2D>("Button/right");
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

			Player.Instance.Update(gameTime);
			platform.Update();

            base.Update(gameTime);
			previousKeyboard = Keyboard.GetState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();

			Player.Instance.Draw(spriteBatch);

            spriteBatch.Draw(up, rect1, Color.White);
            spriteBatch.Draw(down, rect2, Color.White);
            spriteBatch.Draw(right, rect3, Color.White);
            spriteBatch.Draw(left, rect4, Color.White);

			spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

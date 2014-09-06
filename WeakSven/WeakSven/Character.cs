using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
	class Character : Entity
	{
		public Animation animation = new Animation();

		protected Rectangle rect = new Rectangle(0, 0, 0, 0);
		public Rectangle Rect { get { return rect; } }

		public Vector2 Position { get; set; }
		public Vector2 Velocity = Vector2.Zero;
		public float Speed { get; protected set; }

		public Character() : base() { Speed = 0.75f; }
		public Character(string name) : base(name) { Speed = 0.75f; }

		public virtual void Load(ContentManager Content, string imageFile)
		{
			if (animation.FrameCountX == 0)
				animation.FrameCountX = 4;
			if (animation.FrameCountY == 0)
				animation.FrameCountY = 4;
			if (animation.FramesPerSec == 0)
				animation.FramesPerSec = 33;

			animation.SpriteSheet = Content.Load<Texture2D>(imageFile);

			rect.X = (int)Position.X;
			rect.Y = (int)Position.Y;
			rect.Width = animation.FrameWidth;
			rect.Height = animation.FrameHeight;
		}

		public virtual void Update(GameTime gameTime)
		{
			Position += Velocity;

			rect.X = (int)Position.X;
			rect.Y = (int)Position.Y;

			animation.Update(gameTime);
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			animation.Draw(spriteBatch, Position);
		}
	}
}
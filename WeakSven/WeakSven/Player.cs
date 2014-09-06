using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WeakSven
{
	class Player : InteractiveCharacter
	{
		#region Singleton Stuff
		private static Player instance = null;
		public static Player Instance
		{
			get
			{
				if (instance == null)
					instance = new Player();

				return instance;
			}
		}

		private Player() : base() { Speed = 5.0f; }
		#endregion

		public void SetName(string name) { Name = name; }

		public Vector2 PreviousVelocity { get; protected set; }
		public List<Projectile> bullets = new List<Projectile>(10);

		public override void Load(ContentManager Content, string imageFile)
		{
			animation.FramesPerSec = 12;
			animation.FrameCountY = 5;

			base.Load(Content, imageFile);
		}

		public override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Y) &&
				Game1.previousKeyboard.IsKeyUp(Keys.Y))
			{
				bullets.Add(new Projectile(Position, Vector2.UnitY));
			}

			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				animation.sequenceStart = 0;
				animation.sequenceEnd = animation.sequenceStart + animation.FrameCountX * 2;
				Velocity.X = Speed;
				animation.Paused = false;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				animation.sequenceStart = animation.FrameCountX * 2;
				animation.sequenceEnd = animation.sequenceStart + animation.FrameCountX * 2;
				Velocity.X = -Speed;
				animation.Paused = false;
			}
			else
				Velocity.X = 0;

			if (Velocity.Y < -InteractiveCharacter.GRAVITY || Velocity.Y > InteractiveCharacter.GRAVITY)
			{
				if (Velocity.X > 0)
				{
					animation.sequenceStart = 16;
					animation.sequenceEnd = 17;
				}
				else if (Velocity.X < 0)
				{
					animation.sequenceStart = 17;
					animation.sequenceEnd = 18;
				}

				animation.Paused = false;
			}
			else if (Velocity.X == 0)
			{
				if (PreviousVelocity.X < 0)
					StandRight();
				else if (PreviousVelocity.X > 0)
					StandLeft();
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
				Game1.previousKeyboard.IsKeyUp(Keys.Space))
			{
				Velocity.Y = -25;
			}

			foreach (Projectile b in bullets)
				b.Update(gameTime);

			base.Update(gameTime);
			PreviousVelocity = Velocity;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			foreach (Projectile b in bullets)
				b.Draw(spriteBatch);
		}

		private void StandRight()
		{
			animation.sequenceStart = 8;
			animation.sequenceEnd = 9;
			animation.Paused = false;
		}

		private void StandLeft()
		{
			animation.sequenceStart = 0;
			animation.sequenceEnd = 1;
			animation.Paused = false;
		}

		public void Landed(Rectangle other)
		{
			Position = new Vector2(
					Position.X,
					other.Y - Rect.Height
				);

			Velocity = new Vector2(Velocity.X, 0);

			if (animation.sequenceStart == 17)
				StandRight();
			else if (animation.sequenceStart == 16)
				StandLeft();
		}
	}
}
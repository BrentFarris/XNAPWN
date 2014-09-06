using Microsoft.Xna.Framework;
namespace WeakSven
{
	class InteractiveCharacter : Character
	{
		public const float GRAVITY = 1.0f;

		public int Health { get; protected set; }
		public int Attack { get; protected set; }
		public int Defense { get; protected set; }
		public int Money { get; protected set; }

		public InteractiveCharacter()
			: base()
		{

		}

		public override void Update(GameTime gameTime)
		{
			Velocity.Y += GRAVITY;

			base.Update(gameTime);
		}
	}
}
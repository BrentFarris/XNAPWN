using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WeakSven
{
	class Platform
	{
		public Rectangle rect = new Rectangle(0, 0, 0, 0);

		public Platform() { }
		public Platform(Rectangle rectangle)
		{
			rect = rectangle;
		}

		public void Update()
		{
			if (Player.Instance.Rect.Intersects(rect))
			{
				Player.Instance.Landed(rect);
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    class LightningStrikeProjectileController : ProjectileController
    {
        Vector2 _flyingDirection;

        public Vector2 FlyingDirection
        {
            get { return _flyingDirection; }
            set { _flyingDirection = value; }
        }
        public override void UpdatePosition(GameTime gameTime)
        {
            base.UpdatePosition(gameTime);
            Owner.X += FlyingDirection.X * 5;
            Owner.Y += FlyingDirection.Y * 5;
        }
    }
}

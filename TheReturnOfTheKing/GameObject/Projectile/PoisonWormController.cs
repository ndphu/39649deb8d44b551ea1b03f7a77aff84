using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class PoisonWormController : ProjectileController
    {
        public override void UpdatePosition(GameTime gameTime)
        {
            base.UpdatePosition(gameTime);
            Owner.X = Owner.SkillOwner.PlayerOwner.X;
            Owner.Y = Owner.SkillOwner.PlayerOwner.Y;
        }
    }
}

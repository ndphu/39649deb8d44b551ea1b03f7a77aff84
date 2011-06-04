using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class LightningProjectileController : ProjectileController
    {
        public override void UpdatePosition(GameTime gameTime)
        {
            base.UpdatePosition(gameTime);
            if ( Owner._sprite[0].Itexture2D == Owner._sprite[0].Ntexture2D - 1/* && Owner._sprite[0].Check == 0*/)
            {
                Projectile prjt = ((Projectile)((Projectile)Owner).SkillOwner.PlayerOwner.Owner._objectManagerArray[6].CreateObject(9));
                prjt.X = Owner.X;
                prjt.Y = Owner.Y;
                prjt.SkillOwner = ((Projectile)Owner).SkillOwner;
                prjt.MaxDamage = ((Projectile)Owner).MaxDamage;
                prjt.MinDamage = ((Projectile)Owner).MinDamage;
                Owner = prjt;
                ((Projectile)Owner).SkillOwner.PlayerOwner.Owner._listProjectile.Add(prjt);
            }
        }
    }
}

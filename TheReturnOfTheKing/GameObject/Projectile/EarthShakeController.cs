using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class EarthShakeController : ProjectileController
    {        
        int _currentProjectile = 0;

        public int CurrentProjectile
        {
            get { return _currentProjectile; }
            set { _currentProjectile = value; }
        }

        public override void UpdatePosition(GameTime gameTime)
        {
            base.UpdatePosition(gameTime);
            if (CurrentProjectile == 0 && Owner._sprite[0].Itexture2D == Owner._sprite[0].Ntexture2D - 1/* && Owner._sprite[0].Check == 0*/)
            {
                Projectile prjt = ((Projectile)((Projectile)Owner).SkillOwner.PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(((Projectile)Owner).SkillOwner.ListLevel[((Projectile)Owner).SkillOwner.Level].ListSkillInfo[0].ProjectileType + 1));
                prjt.X = Owner.X;
                prjt.Y = Owner.Y;
                prjt.ProjectileController = this;
                prjt.SkillOwner = ((Projectile)Owner).SkillOwner;
                prjt.MaxDamage = ((Projectile)Owner).MaxDamage;
                prjt.MinDamage = ((Projectile)Owner).MinDamage;
                Owner = prjt;
                ((Projectile)Owner).SkillOwner.PlayerOwner.StateOwner._listProjectile.Add(prjt);
                CurrentProjectile = 1;
            }
            else
                if (CurrentProjectile == 1 && Owner._sprite[0].Itexture2D == Owner._sprite[0].Ntexture2D - 1/* && Owner._sprite[0].Check == 0*/)
                {
                    Projectile prjt = ((Projectile)((Projectile)Owner).SkillOwner.PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(((Projectile)Owner).SkillOwner.ListLevel[((Projectile)Owner).SkillOwner.Level].ListSkillInfo[0].ProjectileType + 2));
                    prjt.X = Owner.X;
                    prjt.Y = Owner.Y;
                    prjt.ProjectileController = this;
                    prjt.SkillOwner = ((Projectile)Owner).SkillOwner;
                    prjt.MaxDamage = ((Projectile)Owner).MaxDamage;
                    prjt.MinDamage = ((Projectile)Owner).MinDamage;
                    Owner = prjt;
                    ((Projectile)Owner).SkillOwner.PlayerOwner.StateOwner._listProjectile.Add(prjt);
                    CurrentProjectile = 2;
                }
        }
    }
}

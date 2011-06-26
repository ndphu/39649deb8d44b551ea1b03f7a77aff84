using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class LightningStrike : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new LightningStrike
            {
                X = this.X,
                Y = this.Y,
                Level = this.Level,
                ListLevel = this.ListLevel,
                IdleIcon = this.IdleIcon,
                LargeIcon = this.LargeIcon,
                ClickedIcon = this.ClickedIcon,
                SoundName = this.SoundName,
            };
        }

        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            Projectile prjt = (Projectile)PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(17);
            prjt.X = PlayerOwner.X;
            prjt.Y = PlayerOwner.Y;
            prjt.MinDamage = PlayerOwner.MinDamage / 5;
            prjt.MaxDamage = PlayerOwner.MaxDamage ;
            prjt.IsRemoveAfterEffect = false;
            prjt.LifeTime = 100;
            prjt.SkillOwner = this;
            LightningStrikeProjectileController lspc = new LightningStrikeProjectileController();
            lspc.Owner = prjt;
            lspc.FlyingDirection = new Vector2(PlayerOwner.TargetSkillX - PlayerOwner.X, PlayerOwner.TargetSkillY - PlayerOwner.Y);
            float maxDim = Math.Abs(lspc.FlyingDirection.X) > Math.Abs(lspc.FlyingDirection.Y) ? Math.Abs(lspc.FlyingDirection.X): Math.Abs(lspc.FlyingDirection.Y);
            lspc.FlyingDirection = new Vector2(lspc.FlyingDirection.X / maxDim, lspc.FlyingDirection.Y / maxDim);
            prjt.ProjectileController = lspc;
            PlayerOwner.StateOwner._listProjectile.Add(prjt);
        }

        //public override void DoAdditionalEffect(VisibleGameEntity target)
        //{
        //    base.DoAdditionalEffect(target);
            
        //    for (int i = 0; i < 5; ++i)
        //    {
        //        Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(17);
        //        prjt.X = target.X;
        //        prjt.Y = target.Y;
        //        prjt.MinDamage = PlayerOwner.MinDamage;
        //        prjt.MaxDamage = PlayerOwner.MaxDamage * 5;
        //        prjt.IsRemoveAfterEffect = false;
        //        prjt.LifeTime = int.MaxValue;
        //        prjt.SkillOwner = this;
        //        LightningStrikeProjectileController lspc = new LightningStrikeProjectileController();
        //        lspc.Owner = prjt;
        //        lspc.FlyingDirection = new Vector2(GlobalVariables.GlobalRandom.Next((int)target.X - 10, (int)target.X + 10) - target.X, GlobalVariables.GlobalRandom.Next((int)target.Y - 10, (int)target.Y + 10) - target.Y);
        //        float maxDim = Math.Abs(lspc.FlyingDirection.X) > Math.Abs(lspc.FlyingDirection.Y) ? Math.Abs(lspc.FlyingDirection.X) : Math.Abs(lspc.FlyingDirection.Y);
        //        lspc.FlyingDirection = new Vector2(lspc.FlyingDirection.X / maxDim, lspc.FlyingDirection.Y / maxDim);
        //        prjt.ProjectileController = lspc;
        //        PlayerOwner.Owner._listProjectile.Add(prjt);
        //    }
        //}
    }
}

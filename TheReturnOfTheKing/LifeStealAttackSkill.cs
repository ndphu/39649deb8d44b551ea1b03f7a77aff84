﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class LifeStealAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new LifeStealAttackSkill
            {
                X = this.X,
                Y = this.Y,
                Level = this.Level,
                ListLevel = this.ListLevel,
                SkillIconM = this.SkillIconM,
                SkillIconS = this.SkillIconS,
                SkillIconL = this.SkillIconL,
            };
        }

        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(3);
            prjt.X = _object.X;
            prjt.Y = _object.Y;
            prjt.CollisionRect = new Rectangle(prjt.CollisionRect.X + 3 * GlobalVariables.MapCollisionDim / 8, prjt.CollisionRect.Y + 3 * GlobalVariables.MapCollisionDim / 8, GlobalVariables.MapCollisionDim / 4, GlobalVariables.MapCollisionDim / 4);
            Random r = new Random((int)DateTime.Now.Ticks);
            prjt.MinDamage = PlayerOwner.MinDamage + PlayerOwner.MinDamage * ListLevel[Level].ListSkillInfo[0].PercentDamage / 100;
            prjt.MaxDamage = PlayerOwner.MaxDamage + PlayerOwner.MaxDamage * ListLevel[Level].ListSkillInfo[0].PercentDamage / 100;
            if (r.Next(0, 100) < PlayerOwner.CriticalRate)
            {
                prjt.MinDamage *= 2;
                prjt.MaxDamage *= 2;
            }
            prjt.SkillOwner = this;
            PlayerOwner.Owner._listProjectile.Add(prjt);
            PlayerOwner.Mp += this.ListLevel[Level].ListSkillInfo[0].Mp;
        }

        public override void DoAdditionalEffect(VisibleGameEntity target)
        {
            base.DoAdditionalEffect(target);
            PlayerOwner.Hp += -((Monster)target).RecentHPLost * ListLevel[Level].ListSkillInfo[0].PercentLifeSteal / 100;
            Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(4);
            prjt.X = PlayerOwner.X;
            prjt.Y = PlayerOwner.Y;
            PlayerOwner.Owner._listProjectile.Add(prjt);
        }
    }
}

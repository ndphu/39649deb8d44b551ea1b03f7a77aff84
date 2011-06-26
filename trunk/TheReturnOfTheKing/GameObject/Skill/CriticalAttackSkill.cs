using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class CriticalAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new CriticalAttackSkill
            {
                X = this.X,
                Y = this.Y,
                Level = this.Level,
                ListLevel = this.ListLevel,
                IdleIcon = this.IdleIcon,
                LargeIcon = this.LargeIcon,
                ClickedIcon = this.ClickedIcon,
            };
        }
        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
          
            Projectile prjt = (Projectile)PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].ProjectileType);
            prjt.X = ((Monster)_object).X;
            prjt.Y = ((Monster)_object).Y;
            

            prjt.MinDamage = PlayerOwner.MinDamage + PlayerOwner.MinDamage * ListLevel[Level].ListSkillInfo[0].PercentDamage / 100;
            prjt.MaxDamage = PlayerOwner.MaxDamage + PlayerOwner.MaxDamage * ListLevel[Level].ListSkillInfo[0].PercentDamage / 100;
            
            if (GlobalVariables.GlobalRandom.Next(0, 100) < PlayerOwner.CriticalRate)
            {
                prjt.MinDamage *= 2;
                prjt.MaxDamage *= 2;
            }

            prjt.SkillOwner = this;
            PlayerOwner.StateOwner._listProjectile.Add(prjt);
            PlayerOwner.Mp += this.ListLevel[Level].ListSkillInfo[0].Mp;
        }
    }
}

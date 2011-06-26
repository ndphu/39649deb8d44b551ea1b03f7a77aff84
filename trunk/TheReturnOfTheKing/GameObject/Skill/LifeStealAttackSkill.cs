using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
                IdleIcon = this.IdleIcon,
                LargeIcon = this.LargeIcon,
                ClickedIcon = this.ClickedIcon,
            };
        }

        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            Projectile prjt = (Projectile)PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(3);
            prjt.X = _object.X;
            prjt.Y = _object.Y;
            prjt.CollisionRect = new Rectangle(prjt.CollisionRect.X + 3 * GlobalVariables.MapCollisionDim / 8, prjt.CollisionRect.Y + 3 * GlobalVariables.MapCollisionDim / 8, GlobalVariables.MapCollisionDim / 4, GlobalVariables.MapCollisionDim / 4);
            
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

        public override void DoAdditionalEffect(VisibleGameEntity target)
        {
            base.DoAdditionalEffect(target);
            int _hpRestore = -((Monster)target).RecentHPLost * ListLevel[Level].ListSkillInfo[0].PercentLifeSteal / 100;
            PlayerOwner.Hp += _hpRestore;
            //Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(4);
            //prjt.X = PlayerOwner.X;
            //prjt.Y = PlayerOwner.Y;
            //PlayerOwner.Owner._listProjectile.Add(prjt);
            Projectile prjt = (Projectile)PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(5);
            prjt.X = ((Monster)target).X;
            prjt.Y = ((Monster)target).Y;
            ((Monster)target).AdditionnalEffect.Add(prjt);
            PlayerOwner.StateOwner._displayMessageLayer.MessageArray.Add(new DisplayMessageLayer.Message
            {
                X = PlayerOwner.X,
                Y = PlayerOwner.Y - 2 * GlobalVariables.MapCollisionDim,
                Owner = this,
                DeltaY = -1,
                LifeTime = 45,
                MessageContent = "+ " + _hpRestore.ToString(),
                TextColor = Color.LightGreen,
                DelayTime = 10,
                MinY = (int)PlayerOwner.Y - 2 * GlobalVariables.MapCollisionDim - 30,
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class OverSpeedAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new OverSpeedAttackSkill
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

        public override int Level
        {
            get
            {
                return base.Level;
            }
            set
            {
                //base.Level = value;
                _level = value;
            }
        }

        public override void Active()
        {
            base.Active();
            if (PlayerOwner != null)
            {
                for (int i = 16; i < 32; ++i)
                    PlayerOwner._sprite[i].NDelay = 0;
            }
        }
        public override void Deactive()
        {
            base.Deactive();
            if (PlayerOwner != null)
            {
                for (int i = 16; i < 32; ++i)
                    PlayerOwner._sprite[i].NDelay = PlayerOwner.AttackSpeed;
            }
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
            PlayerOwner.Hp += this.ListLevel[Level].ListSkillInfo[0].Hp;

            prjt = (Projectile)PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(5);
            prjt.X = PlayerOwner.X;
            prjt.Y = PlayerOwner.Y;
            PlayerOwner.AdditionnalEffect.Add(prjt);
        }
    }
}

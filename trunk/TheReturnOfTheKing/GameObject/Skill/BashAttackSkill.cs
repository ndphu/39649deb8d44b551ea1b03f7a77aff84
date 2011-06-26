using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheReturnOfTheKing
{
    public class BashAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new BashAttackSkill
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
            PlayerOwner.Mp += ListLevel[Level].ListSkillInfo[0].Mp;
        }

        public override void DoAdditionalEffect(VisibleGameEntity target)
        {
            base.DoAdditionalEffect(target);
            if (GlobalVariables.GlobalRandom.Next(0, 100) < ListLevel[Level].ListSkillInfo[0].ChanceToBash)
            {
                ((Monster)target).BashTime = ListLevel[Level].ListSkillInfo[0].BashTime;
                Projectile prjt = (Projectile)PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(6);
                prjt.X = target.X;
                prjt.Y = target.Y; 
                ((Monster)target).AdditionnalEffect.Add(prjt);
                ((Monster)target).StateOwner._displayMessageLayer.MessageArray.Add(new DisplayMessageLayer.Message
                    {
                        X = ((Monster)target).X,
                        Y = ((Monster)target).Y - 2 * GlobalVariables.MapCollisionDim,
                        Owner = this,
                        DeltaY = -1,
                        LifeTime = 45,
                        MessageContent = "Bash " + (ListLevel[Level].ListSkillInfo[0].BashTime / 60).ToString() + "s",
                        TextColor = Color.Gray,
                        DelayTime = 10,
                        MinY = (int)((Monster)target).Y - 2 * GlobalVariables.MapCollisionDim - 30,
                    });
            }
        }
    }
}

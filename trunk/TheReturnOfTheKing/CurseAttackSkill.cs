using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TheReturnOfTheKing
{
    public class CurseAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new CurseAttackSkill
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
            if (_object == null || PlayerOwner.Mp + this.ListLevel[Level].ListSkillInfo[0].Mp < 0)
                return;
            Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].ProjectileType);
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
            PlayerOwner.Owner._listProjectile.Add(prjt);
            PlayerOwner.Mp += this.ListLevel[Level].ListSkillInfo[0].Mp;
        }

        public override void DoAdditionalEffect(VisibleGameEntity target)
        {
            base.DoAdditionalEffect(target);
            if (PlayerOwner.Mp + this.ListLevel[Level].ListSkillInfo[0].Mp < 0)
                return;
            if (target != null)
            {
                SkillInfo skillInfo = ListLevel[Level].ListSkillInfo[0];
               

                if (GlobalVariables.GlobalRandom.Next(0, 100) < skillInfo.ChanceToCurse)
                {
                    ((Monster)target).Defense -= skillInfo.AmorReduce;
                    Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(7);
                    prjt.X = target.X;
                    prjt.Y = target.Y;
                    ((Monster)target).AdditionnalEffect.Add(prjt);
                    ((Monster)target).Owner._displayMessageLayer.MessageArray.Add(new DisplayMessageLayer.Message
                    {
                        X = ((Monster)target).X,
                        Y = ((Monster)target).Y - 2 * GlobalVariables.MapCollisionDim,
                        Owner = this,
                        DeltaY = -1,
                        LifeTime = 45,
                        MessageContent = (-skillInfo.AmorReduce).ToString() + " Amor",
                        TextColor = Color.Yellow,
                        MinY = (int)((Monster)target).Y - 2 * GlobalVariables.MapCollisionDim - 30,
                    }
                );
                }

            }
            PlayerOwner.Mp += this.ListLevel[Level].ListSkillInfo[0].Mp;
        }
    }
}

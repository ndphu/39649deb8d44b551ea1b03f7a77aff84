using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TheReturnOfTheKing
{
    public class EarthShakeSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new EarthShakeSkill
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
            if (PlayerOwner.Mp + this.ListLevel[Level].ListSkillInfo[0].Mp < 0)
                return;
            Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].ProjectileType);
            prjt.X = PlayerOwner.TargetSkillX;
            prjt.Y = PlayerOwner.TargetSkillY;
            prjt.MinDamage = ListLevel[Level].ListSkillInfo[0].MinDamage;
            prjt.MaxDamage = ListLevel[Level].ListSkillInfo[0].MaxDamage;
            prjt.SkillOwner = this;
            EarthShakeController esc = new EarthShakeController();
            esc.Owner = prjt;
            prjt.ProjectileController = esc;
            PlayerOwner.Owner._listProjectile.Add(prjt);

            PlayerOwner.Mp += ListLevel[Level].ListSkillInfo[0].Mp;
        }

        public override void DoAdditionalEffect(TheReturnOfTheKing.VisibleGameEntity target)
        {
            base.DoAdditionalEffect(target);
            if (((Monster)target).BashTime != 0)
                return;
            ((Monster)target).BashTime = ListLevel[Level].ListSkillInfo[0].BashTime * 60;
            Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(6);
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
                MessageContent = "Bash " + (ListLevel[Level].ListSkillInfo[0].BashTime).ToString() + "s",
                TextColor = Color.Gray,
                DelayTime = 10,
                MinY = (int)((Monster)target).Y - 2 * GlobalVariables.MapCollisionDim - 30,
            });
        }
    }
}

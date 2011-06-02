using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class SoulReleaseSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new SoulReleaseSkill
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
            for (int i = 0; i < 360; i += 360 / ListLevel[Level].ListSkillInfo[0].NumOfSoul)
            {
                SoulMovingController lmc = new SoulMovingController();
                lmc.Rad = MathHelper.ToRadians(i);
                lmc.MaxA = 300;
                lmc.MaxB = 200;
                Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].ProjectileType);
                prjt.X = PlayerOwner.X;
                prjt.Y = PlayerOwner.Y;
                prjt.IsRemoveAfterEffect = false;
                prjt.MaxDamage = ListLevel[Level].ListSkillInfo[0].MaxDamage;
                prjt.MinDamage = ListLevel[Level].ListSkillInfo[0].MinDamage;
                prjt.SkillOwner = this;
                lmc.Owner = prjt;
                prjt.ProjectileController = lmc;
                prjt.LifeTime = int.MaxValue;
                PlayerOwner.Owner._listProjectile.Add(prjt);                
            }
            PlayerOwner.Mp += ListLevel[Level].ListSkillInfo[0].Mp;
        }
    }
}

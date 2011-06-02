using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    class DeadlyBeeSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new DeadlyBeeSkill
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
            for (int i = 0; i < ListLevel[Level].ListSkillInfo[0].NumOfBee; ++i)
            {
                Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].ProjectileType);
                prjt.X = GlobalVariables.GlobalRandom.Next((int)PlayerOwner.X - 100, (int)PlayerOwner.X + 100);
                prjt.Y = GlobalVariables.GlobalRandom.Next((int)PlayerOwner.Y - 100, (int)PlayerOwner.Y + 100);
                //prjt.X = PlayerOwner.X;
                //prjt.Y = PlayerOwner.Y;
                prjt.MaxDamage = ListLevel[Level].ListSkillInfo[0].MaxDamage;
                prjt.MinDamage = ListLevel[Level].ListSkillInfo[0].MinDamage;
                prjt.ProjectileController = new InsectFlyingController();
                prjt.ProjectileController.Owner = prjt;
                prjt.IsRemoveAfterEffect = false;
                prjt.SkillOwner = this;
                prjt.LifeTime = ListLevel[Level].ListSkillInfo[0].BeeLifeTime;
                ((InsectFlyingController)prjt.ProjectileController).Rad = MathHelper.ToRadians(GlobalVariables.GlobalRandom.Next(0, 360));
                ((InsectFlyingController)prjt.ProjectileController).MaxA = 150;
                ((InsectFlyingController)prjt.ProjectileController).MaxB = 100;
                ((InsectFlyingController)prjt.ProjectileController).CenterX = prjt.X;
                ((InsectFlyingController)prjt.ProjectileController).CenterY = prjt.Y;
                PlayerOwner.Owner._listProjectile.Add(prjt);
            }

            PlayerOwner.Mp += this.ListLevel[Level].ListSkillInfo[0].Mp;
        }
    }
}

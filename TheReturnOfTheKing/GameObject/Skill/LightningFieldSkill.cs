using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class LightningFieldSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new LightningFieldSkill
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }
        
        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            
            for (int i = 0; i < ListLevel[Level].ListSkillInfo[0].NumberOfStar; ++i)
            {
                Projectile prjt = (Projectile)PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].ProjectileType);
                prjt.X = GlobalVariables.GlobalRandom.Next((int)PlayerOwner.X - 200, (int)PlayerOwner.X + 200);
                prjt.Y = GlobalVariables.GlobalRandom.Next((int)PlayerOwner.Y - 100, (int)PlayerOwner.Y + 100);
                prjt.MinDamage = ListLevel[Level].ListSkillInfo[0].MinDamage;
                prjt.MaxDamage = ListLevel[Level].ListSkillInfo[0].MaxDamage;
                prjt.SkillOwner = this;
                LightningProjectileController lpc = new LightningProjectileController();
                lpc.Owner = prjt;
                prjt.ProjectileController = lpc;
                prjt.DelayTime = GlobalVariables.GlobalRandom.Next(0, ListLevel[Level].ListSkillInfo[0].Duration * 60);
                PlayerOwner.StateOwner._listProjectile.Add(prjt);
                
            }
            
        }
    }
}

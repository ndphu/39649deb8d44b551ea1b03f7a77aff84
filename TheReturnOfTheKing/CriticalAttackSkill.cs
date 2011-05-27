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
            if (_object == null || PlayerOwner.Mp + this.ListLevel[Level].ListSkillInfo[0].Mp < 0)
                return;
            //Point targetPoint = new Point();
            //int _dir = PlayerOwner.Dir % 8;

            

            /*switch (_dir)
            {
                case 0:
                    targetPoint = new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), ((int)(PlayerOwner.Y)));
                    break;
                case 1:
                    targetPoint = new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), ((int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    break;
                case 2:
                    targetPoint = new Point((int)(PlayerOwner.X), ((int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    break;
                case 3:
                    targetPoint = new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), ((int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    break;
                case 4:
                    targetPoint = new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), ((int)(PlayerOwner.Y)));
                    break;
                case 5:
                    targetPoint = new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), ((int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    break;
                case 6:
                    targetPoint = new Point((int)(PlayerOwner.X), ((int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    break;
                case 7:
                    targetPoint = new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), ((int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    break;
            }*/

            Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].Type);
            prjt.X = ((Monster)_object).X;
            prjt.Y = ((Monster)_object).Y;
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
    }
}

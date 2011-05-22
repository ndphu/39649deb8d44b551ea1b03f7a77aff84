using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class CleavingAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new CleavingAttackSkill
            {
                X = this.X,
                Y = this.Y,
                Level = this.Level,
                ListLevel = this.ListLevel,
                SkillIconM = this.SkillIconM,
                SkillIconS = this.SkillIconS,
                SkillIconL = this.SkillIconL,
            };
        }

        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            
            List<Point> _listProjectileTarget = new List<Point>();
            int _dir = PlayerOwner.Dir % 8;
            if (PlayerOwner.Mp + this.ListLevel[Level].ListSkillInfo[0].Mp < 0)
                return;
            switch (_dir)
            {
                case 0:
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    break;
                case 1:
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + 2 * GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X), (int)(PlayerOwner.Y - 2 * GlobalVariables.MapCollisionDim)));
                    break;
                case 2:
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    break;
                case 3:
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X), (int)(PlayerOwner.Y - 2 * GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - 2 * GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y)));
                    break;
                case 4:
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    break;
                case 5:
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - 2 * GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X), (int)(PlayerOwner.Y + 2 * GlobalVariables.MapCollisionDim)));
                    break;
                case 6:
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    break;
                case 7:
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X), (int)(PlayerOwner.Y + 2 * GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + 2 * GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y)));
                    break;
                //case 0:
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)PlayerOwner.Y));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                //    break;
                //case 1:
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim / sqrt2), (int)((PlayerOwner.Y - 2 * GlobalVariables.MapCollisionDim) / sqrt2)));
                //    _listProjectileTarget.Add(new Point((int)((PlayerOwner.X + GlobalVariables.MapCollisionDim) / sqrt2), (int)((PlayerOwner.Y - GlobalVariables.MapCollisionDim) / sqrt2)));
                //    _listProjectileTarget.Add(new Point((int)((PlayerOwner.X + 2 * GlobalVariables.MapCollisionDim) / sqrt2), (int)((PlayerOwner.Y) / sqrt2)));
                //    break;
                //case 2:
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                //    break;
                //case 3:
                //    _listProjectileTarget.Add(new Point((int)((PlayerOwner.X - 2 * GlobalVariables.MapCollisionDim) / sqrt2), (int)PlayerOwner.Y));
                //    _listProjectileTarget.Add(new Point((int)((PlayerOwner.X + GlobalVariables.MapCollisionDim) / sqrt2), (int)((PlayerOwner.Y - GlobalVariables.MapCollisionDim) / sqrt2)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X / sqrt2), (int)((PlayerOwner.Y - 2 * GlobalVariables.MapCollisionDim) / sqrt2)));
                //    break;
                //case 4:
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y - GlobalVariables.MapCollisionDim)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                //    break;
                //case 5:
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X / sqrt2), (int)((PlayerOwner.Y + 2 * GlobalVariables.MapCollisionDim) / sqrt2)));
                //    _listProjectileTarget.Add(new Point((int)((PlayerOwner.X + GlobalVariables.MapCollisionDim) / sqrt2), (int)((PlayerOwner.Y - GlobalVariables.MapCollisionDim) / sqrt2)));
                //    _listProjectileTarget.Add(new Point((int)((PlayerOwner.X - 2 * GlobalVariables.MapCollisionDim) / sqrt2), (int)((PlayerOwner.Y) / sqrt2)));
                //    break;
                //case 6:
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X - GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X + GlobalVariables.MapCollisionDim), (int)(PlayerOwner.Y + GlobalVariables.MapCollisionDim)));
                //    break;
                //case 7:
                //    _listProjectileTarget.Add(new Point((int)((PlayerOwner.X + 2 * GlobalVariables.MapCollisionDim) / sqrt2), (int)PlayerOwner.Y));
                //    _listProjectileTarget.Add(new Point((int)((PlayerOwner.X + GlobalVariables.MapCollisionDim) / sqrt2), (int)((PlayerOwner.Y - GlobalVariables.MapCollisionDim) / sqrt2)));
                //    _listProjectileTarget.Add(new Point((int)(PlayerOwner.X / sqrt2), (int)((PlayerOwner.Y + 2 * GlobalVariables.MapCollisionDim) / sqrt2)));
                //    break;
            }

            for (int i = 0; i < _listProjectileTarget.Count; ++i)
            {
                Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].Type);
                prjt.X = _listProjectileTarget[i].X;
                prjt.Y = _listProjectileTarget[i].Y;
                Random r = new Random();
               
                prjt.MinDamage = PlayerOwner.MinDamage + PlayerOwner.MinDamage * ListLevel[Level].ListSkillInfo[0].PercentDamage / 100;
                prjt.MaxDamage = PlayerOwner.MaxDamage + PlayerOwner.MaxDamage * ListLevel[Level].ListSkillInfo[0].PercentDamage / 100;
                if (r.Next(0, 100) < PlayerOwner.CriticalRate)
                {
                    prjt.MinDamage *= 2;
                    prjt.MaxDamage *= 2;
                }

                prjt.SkillOwner = this;
                PlayerOwner.Owner._listProjectile.Add(prjt);
            }
            PlayerOwner.Mp += this.ListLevel[Level].ListSkillInfo[0].Mp;
        }
    }
}

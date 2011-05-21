using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class CleavingAttackSkill : Skill
    {
        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            
            List<Point> _listProjectileTarget = new List<Point>();
            int _dir = PlayerOwner.Dir % 8;
            switch (_dir)
            {
                case 0:
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y + 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y - 32));
                    break;
                case 1:
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y - 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X, (int)PlayerOwner.Y - 32));
                    break;
                case 2:
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y - 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X, (int)PlayerOwner.Y - 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y - 32));
                    break;
                case 3:
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X, (int)PlayerOwner.Y - 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y - 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y));
                    break;
                case 4:
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y - 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y + 32));
                    break;
                case 5:
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y + 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X, (int)PlayerOwner.Y + 32));
                    break;
                case 6:
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X - 32, (int)PlayerOwner.Y + 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X, (int)PlayerOwner.Y + 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y + 32));
                    break;
                case 7:
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X, (int)PlayerOwner.Y + 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y + 32));
                    _listProjectileTarget.Add(new Point((int)PlayerOwner.X + 32, (int)PlayerOwner.Y));
                    break;
            }

            for (int i = 0; i < _listProjectileTarget.Count; ++i)
            {
                Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(0);
                prjt.X = _listProjectileTarget[i].X;
                prjt.Y = _listProjectileTarget[i].Y;
                prjt.Level = 0;
                prjt.ListLevel[0].Hp = 0;
                prjt.ListLevel[0].Mp = 0;
                prjt.ListLevel[0].MaxDamage = PlayerOwner.Attack;
                prjt.ListLevel[0].MinDamage = PlayerOwner.Attack;

                PlayerOwner.Owner._listProjectile.Add(prjt);
            }
        }
    }
}

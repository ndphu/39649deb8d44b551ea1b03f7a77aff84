using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class WaveFormSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new WaveFormSkill
            {
                X = this.X,
                Y = this.Y,
                Level = this.Level,
                ListLevel = this.ListLevel,
                IdleIcon = this.IdleIcon,
                LargeIcon = this.LargeIcon,
                ClickedIcon = this.ClickedIcon,
                Delay = this.Delay,
            };
        }

        //bool _isEffected;

        //public bool IsEffected
        //{
        //    get { return _isEffected; }
        //    set { _isEffected = value; }
        //}

        int _delay;

        public int Delay
        {
            get { return _delay; }
            set { _delay = value; }
        }

        int _check;

        public int Check
        {
            get { return _check; }
            set { _check = value; }
        }

        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            //IsEffected = true;

            if (!PlayerOwner.IsWaveForm)
            {
                if (PlayerOwner.Mp + this.ListLevel[Level].ListSkillInfo[0].Mp < 0)
                    return;
                PlayerOwner.Mp += ListLevel[Level].ListSkillInfo[0].Mp;
            }
            Vector2 vector = new Vector2(PlayerOwner.TargetSkillX - PlayerOwner.X, PlayerOwner.TargetSkillY - PlayerOwner.Y);
            vector.Normalize();
            if (Math.Abs(PlayerOwner.X - PlayerOwner.TargetSkillX) > 5 || Math.Abs(PlayerOwner.Y - PlayerOwner.TargetSkillY) > 5)
            {
                PlayerOwner.X += vector.X * 10;
                PlayerOwner.Y += vector.Y * 10;
                PlayerOwner.DestPoint = new Point((int)PlayerOwner.X, (int)PlayerOwner.Y);
                
                PlayerOwner.IsWaveForm = true;
                PlayerOwner.CellToMove = new List<Point>();
                if (Check == 0)
                {
                    Projectile prjt = (Projectile)PlayerOwner.Owner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].ProjectileType);
                    prjt.X = PlayerOwner.X;
                    prjt.Y = PlayerOwner.Y;
                    prjt.MinDamage = ListLevel[Level].ListSkillInfo[0].MinDamage;
                    prjt.MaxDamage = ListLevel[Level].ListSkillInfo[0].MaxDamage;
                    prjt.SkillOwner = this;
                    PlayerOwner.Owner._listProjectile.Add(prjt);
                    Check = Delay;
                }
                else
                    Check -= 1;
            }
            else
            {
                PlayerOwner.IsWaveForm = false;
            }
            
        }

        public override void DoAdditionalEffect(VisibleGameEntity target)
        {
            base.DoAdditionalEffect(target);
        }
    }
}

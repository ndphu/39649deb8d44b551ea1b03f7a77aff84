using System;
using System.Collections.Generic;
using System.Text;

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
                SkillIconM = this.SkillIconM,
                SkillIconS = this.SkillIconS,
                SkillIconL = this.SkillIconL,
            };
        }

        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            if (_object == null || PlayerOwner.Mp + this.ListLevel[Level].ListSkillInfo[0].Mp < 0)
                return;
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

        public override void DoAdditionalEffect(VisibleGameEntity target)
        {
            base.DoAdditionalEffect(target);
            if (target != null)
            {
                SkillInfo skillInfo = ListLevel[Level].ListSkillInfo[0];
                Random r = new Random((int)DateTime.Now.Ticks);

                if (r.Next(0, 100) < skillInfo.ChanceToCurse)
                {
                    ((Monster)target).Defense -= skillInfo.AmorReduce;
                }

            }
        }
    }
}

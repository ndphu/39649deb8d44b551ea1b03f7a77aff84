using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class LifeStealAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new LifeStealAttackSkill
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
    }
}

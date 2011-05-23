using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class BashAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new BashAttackSkill
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

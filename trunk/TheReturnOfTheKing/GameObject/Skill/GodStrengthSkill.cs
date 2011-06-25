using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class GodStrengthSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new GodStrengthSkill
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
        public override void Active()
        {
            base.Active();
            PlayerOwner.Speed += this.ListLevel[this.Level].ListSkillInfo[0].MS;
            PlayerOwner.AttackSpeed += this.ListLevel[this.Level].ListSkillInfo[0].AS;
        }
    }
}

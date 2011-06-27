using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class GreatFortitudeSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new GreatFortitudeSkill
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
            PlayerOwner.Defense += this.ListLevel[Level].ListSkillInfo[0].Defense;

        }
    }
}

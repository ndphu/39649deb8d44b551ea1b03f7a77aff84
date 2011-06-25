using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class BlurSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new BlurSkill
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
    }
}

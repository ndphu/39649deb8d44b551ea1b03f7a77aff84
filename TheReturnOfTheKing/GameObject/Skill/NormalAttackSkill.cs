using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheReturnOfTheKing
{
    class NormalAttackSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new NormalAttackSkill
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

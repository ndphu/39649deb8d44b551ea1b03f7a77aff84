using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class FireWallSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new FireWallSkill
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

        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
            if (PlayerOwner.Mp + this.ListLevel[Level].ListSkillInfo[0].Mp < 0)
                return;

            PlayerOwner.Mp += ListLevel[Level].ListSkillInfo[0].Mp;
        }
    }
}

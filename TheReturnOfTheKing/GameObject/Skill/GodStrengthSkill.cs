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
            PlayerOwner.Speed += PlayerOwner.Speed * this.ListLevel[this.Level].ListSkillInfo[0].MS / 100;
            int _delayTime = 0;
            switch (this.Level)
            {
                case 1:
                    _delayTime = 3;
                    break;
                case 2:
                    _delayTime = 2;
                    break;
                case 3:
                    _delayTime = 1;
                    break;
            }
            for (int i = 16; i < 32; ++i)
                PlayerOwner._sprite[i].NDelay = _delayTime;
        }
    }
}

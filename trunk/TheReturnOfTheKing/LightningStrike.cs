using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class LightningStrike : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new LightningStrike
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
        }
    }
}

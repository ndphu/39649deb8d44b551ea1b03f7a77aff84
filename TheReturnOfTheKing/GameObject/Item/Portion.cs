using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TheReturnOfTheKing
{
    public class Portion : Item
    {
        int _hP;

        public int HP
        {
            get { return _hP; }
            set { _hP = value; }
        }

        int _mP;

        public int MP
        {
            get { return _mP; }
            set { _mP = value; }
        }

        public override void DoEffect()
        {
            base.DoEffect();
            PlayerOwner.Hp += this.HP;
            PlayerOwner.Mp += this.MP;
            PlayerOwner.StateOwner._displayMessageLayer.InfoMessageArray.Add(new DisplayMessageLayer.InfoMessage
            {
                MessageContent = "Restore " + this.HP.ToString() + " HP and " + this.MP.ToString() + " MP",
                LifeTime = 120,
                TextColor = Color.LightGreen,
            });
            
        }
    }
}

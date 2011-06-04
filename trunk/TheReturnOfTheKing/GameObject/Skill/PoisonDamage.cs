using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheReturnOfTheKing
{
    class PoisonDamage
    {
        int _damageValue;

        public int DamageValue
        {
            get { return _damageValue; }
            set { _damageValue = value; }
        }

        int _duration;

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        int _effectMoment = 30;

        public int EffectMoment
        {
            get { return _effectMoment; }
            set { _effectMoment = value; }
        }
    }
}

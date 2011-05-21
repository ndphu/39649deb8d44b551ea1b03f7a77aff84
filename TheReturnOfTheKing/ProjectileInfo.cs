using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class ProjectileInfo
    {
        int _minDamage;

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }

        int _maxDamage;

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        int _hp;

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        int _mp;

        public int Mp
        {
            get { return _mp; }
            set { _mp = value; }
        }

        List<Projectile> _listProjectile;

        public List<Projectile> ListProjectile
        {
            get { return _listProjectile; }
            set { _listProjectile = value; }
        }
    }
}

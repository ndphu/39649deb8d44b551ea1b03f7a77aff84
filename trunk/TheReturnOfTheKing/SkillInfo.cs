using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class SkillInfo
    {
        int _type;

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        int _percentDamage;

        public int PercentDamage
        {
            get { return _percentDamage; }
            set { _percentDamage = value; }
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

        int _amorReduce;

        public int AmorReduce
        {
            get { return _amorReduce; }
            set { _amorReduce = value; }
        }

        int _chanceToCurse;

        public int ChanceToCurse
        {
            get { return _chanceToCurse; }
            set { _chanceToCurse = value; }
        }

        int _numOfHit;

        public int NumOfHit
        {
            get { return _numOfHit; }
            set { _numOfHit = value; }
        }
    }

    public class SkillLevel
    {
        List<SkillInfo> _listSkillInfo;

        public List<SkillInfo> ListSkillInfo
        {
            get { return _listSkillInfo; }
            set { _listSkillInfo = value; }
        }
    }
}

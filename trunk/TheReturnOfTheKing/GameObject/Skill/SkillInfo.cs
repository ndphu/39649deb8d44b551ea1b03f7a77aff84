using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class SkillInfo
    {
        int _projectileType;

        public int ProjectileType
        {
            get { return _projectileType; }
            set { _projectileType = value; }
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

        int _percentLifeSteal;

        public int PercentLifeSteal
        {
            get { return _percentLifeSteal; }
            set { _percentLifeSteal = value; }
        }

        int _chanceToBash;

        public int ChanceToBash
        {
            get { return _chanceToBash; }
            set { _chanceToBash = value; }
        }

        int _bashTime;

        public int BashTime
        {
            get { return _bashTime; }
            set { _bashTime = value; }
        }
        /// <summary>
        /// So luong ruoi tha ra
        /// </summary>
        int _numOfBee;

        public int NumOfBee
        {
            get { return _numOfBee; }
            set { _numOfBee = value; }
        }
        /// <summary>
        /// Thoi gian song cua ruoi
        /// </summary>
        int _beeLifeTime;

        public int BeeLifeTime
        {
            get { return _beeLifeTime; }
            set { _beeLifeTime = value; }
        }
        /// <summary>
        /// So linh hon
        /// </summary>
        int _numOfSoul;

        public int NumOfSoul
        {
            get { return _numOfSoul; }
            set { _numOfSoul = value; }
        }


        int _coolDown;

        public int CoolDown
        {
            get { return _coolDown; }
            set { _coolDown = value; }
        }

        int _castRange = int.MaxValue;

        public int CastRange
        {
            get { return _castRange; }
            set { _castRange = value; }
        }

        int _numberOfStar;

        public int NumberOfStar
        {
            get { return _numberOfStar; }
            set { _numberOfStar = value; }
        }

        int _duration;

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        int _defense;

        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }

        int _aS;

        public int AS
        {
            get { return _aS; }
            set { _aS = value; }
        }
        int _mS;

        public int MS
        {
            get { return _mS; }
            set { _mS = value; }
        }
        int _changeToDodge;

        public int ChangeToDodge
        {
            get { return _changeToDodge; }
            set { _changeToDodge = value; }
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

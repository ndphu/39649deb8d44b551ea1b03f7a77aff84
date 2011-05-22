using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class EquipItem : Item
    {
        /// <summary>
        /// Damage thêm vào chặn dưới của Damage của player
        /// </summary>
        int _minDamage;

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }
        /// <summary>
        /// Damage thêm vào chặn trên của Damage của player
        /// </summary>
        int _maxDamage;

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        /// <summary>
        /// Tỉ lệ sát thương thêm vào
        /// </summary>
        int _percentDamage;

        public int PercentDamage
        {
            get { return _percentDamage; }
            set { _percentDamage = value; }
        }
        /// <summary>
        /// Máu tối đa tăng thêm
        /// </summary>
        int _maxHP;

        public int MaxHP
        {
            get { return _maxHP; }
            set { _maxHP = value; }
        }
        /// <summary>
        /// Mana tối đa tăng thêm
        /// </summary>
        int _maxMP;

        public int MaxMP
        {
            get { return _maxMP; }
            set { _maxMP = value; }
        }
        /// <summary>
        /// Tỉ lệ tấn công chí mạng thêm vào
        /// </summary>
        int _criticalRate;

        public int CriticalRate
        {
            get { return _criticalRate; }
            set { _criticalRate = value; }
        }
        /// <summary>
        /// Sát thương vật lý thêm vào - mỗi điểm tương đương 5 damage cho cả damage min và max của player
        /// </summary>
        int _physicalDamage;

        public int PhysicalDamage
        {
            get { return _physicalDamage; }
            set { _physicalDamage = value; }
        }
        /// <summary>
        /// Phòng thủ thêm vào
        /// </summary>
        int _defense;

        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }
        /// <summary>
        /// Tỉ lệ né đòn
        /// </summary>
        int _chanceToDodge;

        public int ChanceToDodge
        {
            get { return _chanceToDodge; }
            set { _chanceToDodge = value; }
        }
        /// <summary>
        /// Tốc độ đánh
        /// </summary>
        int _attackSpeed;

        public int AttackSpeed
        {
            get { return _attackSpeed; }
            set { _attackSpeed = value; }
        }
        /// <summary>
        /// Tốc độ xuất chiêu
        /// </summary>
        int _castingSpeed;

        public int CastingSpeed
        {
            get { return _castingSpeed; }
            set { _castingSpeed = value; }
        }
        /// <summary>
        /// Tốc độ di chuyển
        /// </summary>
        int _movingSpeed;

        public int MovingSpeed
        {
            get { return _movingSpeed; }
            set { _movingSpeed = value; }
        }
    }
}

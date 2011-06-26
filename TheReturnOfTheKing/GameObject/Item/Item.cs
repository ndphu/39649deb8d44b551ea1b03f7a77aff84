using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class Item : VisibleGameEntity
    {
        /// <summary>
        /// Nhan vat so huu item
        /// </summary>
        PlayerCharacter _playerOwner;

        public PlayerCharacter PlayerOwner
        {
            get { return _playerOwner; }
            set { _playerOwner = value; }
        }
        /// <summary>
        /// Giá tiền của món đồ
        /// </summary>
        int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public virtual void DoEffect()
        {
            
        }
    }
}

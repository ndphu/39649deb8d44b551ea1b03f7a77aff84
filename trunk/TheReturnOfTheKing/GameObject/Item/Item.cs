using System;
using System.Collections.Generic;
using System.Text;

namespace TheReturnOfTheKing
{
    public class Item : VisibleGameEntity
    {
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

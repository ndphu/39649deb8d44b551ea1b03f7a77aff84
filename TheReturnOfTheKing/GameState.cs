using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace TheReturnOfTheKing
{
    public abstract class GameState
    {
        /// <summary>
        /// Đối tượng đang nắm giữ state (tức là Game chính)
        /// </summary>
        MainGame _owner;

        public MainGame Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        

        //Mảng các objectManager: người dùng cần phải biết mảng hiện thời gôm những
        //objectManager nào và vị trí của nó nằm trong mảng
        //Sau đó sử dụng lệnh createObject để tạo ra đúng đối tượng mình cần.        
        public virtual void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// Set lại các biến của state nếu cần thiết
        /// </summary>
        public virtual void EnterState()
        {

        }
        /// <summary>
        /// Hàm update cho state
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void UpdateState(GameTime gameTime)
        {

        }
        /// <summary>
        /// Chổ này sẽ giải phóng thuộc tính nếu cần thiết
        /// </summary>
        public virtual void ExitState()
        { 

        }
        /// <summary>
        /// Vẽ
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="sb"></param>
        public virtual void DrawState(GameTime gameTime, SpriteBatch sb)
        { 

        }
    }
}

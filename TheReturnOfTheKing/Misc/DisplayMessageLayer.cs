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
    public class DisplayMessageLayer : Misc
    {
        public class Message: VisibleGameEntity
        {


            /// <summary>
            /// Message nay thuoc doi tuong nao
            /// </summary>
            VisibleGameEntity _owner;

            public VisibleGameEntity Owner
            {
                get { return _owner; }
                set { _owner = value; }
            }
            /// <summary>
            /// Noi dung cua message
            /// </summary>
            string _messageContent;

            public string MessageContent
            {
                get { return _messageContent; }
                set { _messageContent = value; }
            }
            /// <summary>
            /// Mau message
            /// </summary>
            Color _textColor;

            public Color TextColor
            {
                get { return _textColor; }
                set { _textColor = value; }
            }
            /// <summary>
            /// Toi gian ton tai
            /// </summary>
            int _liveTime;

            public int LifeTime
            {
                get { return _liveTime; }
                set { _liveTime = value; }
            }
            /// <summary>
            /// Khoang dich chuyen sau moi lan update
            /// </summary>
            int _deltaY;

            public int DeltaY
            {
                get { return _deltaY; }
                set { _deltaY = value; }
            }
            /// <summary>
            /// Khoang cach len toi da
            /// </summary>
            int _minY;

            public int MinY
            {
                get { return _minY; }
                set { _minY = value; }
            }
            /// <summary>
            /// Thoi gian delay truoc khi xuat hien message
            /// </summary>
            int _delayTime;

            public int DelayTime
            {
                get { return _delayTime; }
                set { _delayTime = value; }
            } 

            public override void Draw(GameTime gameTime, SpriteBatch sb)
            {
                if (_delayTime >= 0)
                    sb.DrawString(GlobalVariables.Sf, _messageContent, new Vector2(X + GlobalVariables.dX, Y + GlobalVariables.dY), _textColor);
            }

            public override void Update(GameTime gameTime)
            {
                base.Update(gameTime);
                if (_delayTime > 0)
                {
                    _delayTime -= 1;
                    return;
                }
                LifeTime -= 1;
                if (Y > _minY)
                    Y += _deltaY;
                
            }
 
        }
        List<Message> _messageArray = new List<Message>();

        public List<Message> MessageArray
        {
            get { return _messageArray; }
            set { _messageArray = value; }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            for (int i = 0; i < _messageArray.Count; ++i)
            {
                _messageArray[i].Draw(gameTime, sb);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            for (int i = 0; i < _messageArray.Count; ++i)
            {
                if (_messageArray[i].LifeTime <= 0)
                    _messageArray.Remove(_messageArray[i]);
                else
                    _messageArray[i].Update(gameTime);
            }

        }
    }
}

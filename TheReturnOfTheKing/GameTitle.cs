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
using System.Xml;

namespace TheReturnOfTheKing
{
    public class GameTitle : Misc
    {
        bool _appeared = false;

        int _delayTime;

        public int DelayTime
        {
            get { return _delayTime; }
            set { _delayTime = value; }
        }

        int _iDelayTime = 0;

        public int IDelayTime
        {
            get { return _iDelayTime; }
            set { _iDelayTime = value; }
        }

        public override float X
        {
            get
            {
                return base.X;
            }
            set
            {
                base.X = value;
                for (int i = 0; i < _nsprite; ++i)
                    _sprite[i].X = value;
            }
        }

        public override float Y
        {
            get
            {
                return base.Y;
            }
            set
            {
                base.Y = value;
                for (int i = 0; i < _nsprite; ++i)
                    _sprite[i].Y = value;
            }
        }

        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();  
            return new GameTitle
            {
                _nsprite = this._nsprite,
                _sprite = _spriteTemp,
                _x = this._x,
                _y = this._y,
                _delayTime = this._delayTime,
                _width = this._width,
                _height = this._height,
                _rect = this._rect
            };
        }

        public override void Update(GameTime gameTime)
        {
            if (_iDelayTime == _delayTime)
            {
                if (!_appeared)
                {
                    _sprite[0].Itexture2D++;
                    if (_sprite[0].Itexture2D == _sprite[0].Ntexture2D - 1)
                        _appeared = true;
                }
                else
                {
                    _sprite[1].Itexture2D = (_sprite[1].Itexture2D + 1) % _sprite[1].Ntexture2D;
                }
            }
            else
                _iDelayTime++;
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (_iDelayTime == _delayTime)
            {
                if (!_appeared)
                    _sprite[0].Draw(gameTime, sb);
                else
                    _sprite[1].Draw(gameTime, sb);     
            }
        }
    }
}

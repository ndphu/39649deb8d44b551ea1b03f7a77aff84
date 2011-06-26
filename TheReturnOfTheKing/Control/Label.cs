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
    public class Label : Dialog
    {
        SpriteFont _sf;

        public SpriteFont Sf
        {
            get { return _sf; }
            set { _sf = value; }
        }

        string _stringInfo;

        public string StringInfo
        {
            get { return _stringInfo; }
            set { _stringInfo = value; }
        }

        Color _stringColor;

        public Color StringColor
        {
            get { return _stringColor; }
            set { _stringColor = value; }
        }

        int _drawX;

        public int DrawX
        {
            get { return _drawX; }
            set { _drawX = value; }
        }

        int _drawY;

        public int DrawY
        {
            get { return _drawY; }
            set { _drawY = value; }
        }

        int _drawOffSetX;

        public int DrawOffSetX
        {
            get { return _drawOffSetX; }
            set { 
                _drawOffSetX = value;
                _drawX = (int)_x + _drawOffSetX;
            }
        }

        int _drawOffSetY;

        public int DrawOffSetY
        {
            get { return _drawOffSetY; }
            set { 
                _drawOffSetY = value;
                _drawY = (int)_y + _drawOffSetY;
            }
        }

        public override float X
        {
            get
            {
                return base.X;
            }
            set
            {
                _x = value;
                for (int i = 0; i < base._nsprite; ++i)
                    _sprite[i].X = value;
                _drawX = (int)_x + _drawOffSetX;
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
                _y = value;
                for (int i = 0; i < base._nsprite; ++i)
                    _sprite[i].Y = value;
                _drawY = (int)_y + _drawOffSetY;
            }
        }

        public override VisibleGameObject Clone()
        {
            Label _new = new Label();
            _new._nsprite = _nsprite;
            _new._sprite = new GameSprite [_new._nsprite];
            for (int i = 0; i < _new._nsprite; i++)
            {
                _new._sprite[i] = _sprite[i];
            }
            _new._sf = _sf;
            _new._stringInfo = _stringInfo;
            _new._stringColor = _stringColor;
            _new._x = _x;
            _new._y = _y;
            _new.OffSetX = OffSetX;
            _new.OffSetY = OffSetY;
            _new._drawX = _drawX;
            _new._drawY = _drawY;
            _new._drawOffSetX = _drawOffSetX;
            _new._drawOffSetY = _drawOffSetY;
            return _new;
        }

        public void UpdateOffset()
        {
            int _iwidth = _sprite[0].Texture2D[0].Width;
            int _iheight = _sprite[0].Texture2D[0].Height;

            Vector2 _temp = _sf.MeasureString(_stringInfo);
            _drawOffSetX = (int)((_iwidth - _temp.X) / 2);
            _drawOffSetY = (int)((_iheight - _temp.Y) / 2);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(_sprite[0].Texture2D[0], new Vector2(_x, _y), Color.White);
            sb.DrawString(_sf, _stringInfo, new Vector2(_drawX, _drawY), _stringColor);
        }
    }
}
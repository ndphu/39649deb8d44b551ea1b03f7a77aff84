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
    public class ProcessBar : Misc
    {
        private Rectangle _recToDraw;

        public Rectangle RecToDraw
        {
            get { return _recToDraw; }
            set { _recToDraw = value; }
        }
        private string _direction;

        public string Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        private int _xStartAnimatePro;

        public int XStartAnimatePro
        {
            get { return _xStartAnimatePro; }
            set { _xStartAnimatePro = value; }
        }
        private int _xEndAnimatePro;

        public int XEndAnimatePro
        {
            get { return _xEndAnimatePro; }
            set { _xEndAnimatePro = value; }
        }

        private Vector2 _pointToDraw;

        public Vector2 PointToDraw
        {
            get { return _pointToDraw; }
            set { _pointToDraw = value; }
        }
//---------------------FUCNTION------------------------------------
        public override float X
        {
            get
            {
                return base.X;
            }
            set
            {
                base.X = value;
                for (int i = 0; i < _nsprite; i++)
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
                for (int i = 0; i < _nsprite; i++)
                    _sprite[i].Y = value;
            }
        }

        public override VisibleGameObject Clone()
        {
            return new ProcessBar
            {
                _nsprite = this._nsprite,
                _sprite = this._sprite,
                _x = this._x,
                _y = this._y,
                _direction = this._direction,
                _rect = this._rect,
                _width = this._width,
                _height = this._height,
                _xEndAnimatePro = this._xEndAnimatePro,
                _xStartAnimatePro = this._xStartAnimatePro
            };

        }

        public void UpdateDrawRect(float _rateToDraw)
        {
            switch (_direction)
            {
                case "Right":
                    {
                        int offSet = (int)((_xEndAnimatePro - _xStartAnimatePro) * _rateToDraw + _xStartAnimatePro);
                        _recToDraw = new Rectangle(0, 0, offSet, (int)Height);
                        _pointToDraw = new Vector2(X, Y);
                        break;
                    }
                case "Left":
                    {
                        int offSet = (int)((_xEndAnimatePro - _xStartAnimatePro) * _rateToDraw + (_width - _xEndAnimatePro));
                        _recToDraw = new Rectangle((int)_width - offSet, 0, offSet, (int)Height);
                        _pointToDraw = new Vector2(X + (_width - offSet), Y);
                        break;
                    }
                case "Up":
                    {
                        break;
                    }
                case "Down":
                    {
                        break;
                    }

            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (_sprite[1] != null)
            {
                sb.Draw(_sprite[0].Texture2D[0], _pointToDraw, _recToDraw, Color.White);
                sb.Draw(_sprite[1].Texture2D[0], new Vector2(X, Y), Color.White);
            }
            else
                sb.Draw(_sprite[1].Texture2D[0], _pointToDraw, Color.White);
        }
    }
}

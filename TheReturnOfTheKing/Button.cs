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
    public class Button : Dialog
    {
        private bool _isClicked = false;//Có được click hay không.

        public bool IsClicked
        {
            get { return _isClicked; }
            set { _isClicked = value; }
        }

        private int _delayTime = 0;

        public int DelayTime
        {
            get { return _delayTime; }
            set { _delayTime = value; }
        }

        private int _ideLayTime = 0;

        public int IdeLayTime
        {
            get { return _ideLayTime; }
            set { _ideLayTime = value; }
        }

        public MotionInfo _motionInfo;//Thông tin chuyển động của button

        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();  
            Button _newButton = new Button
            {                
                _nsprite = this._nsprite,
                _sprite = _spriteTemp,
                X = this.X,
                Y = this.Y,
                IsMouseHover = this.IsMouseHover,
                Width = this.Width,
                Height = this.Height,
                Rect = this.Rect,
                _motionInfo = this._motionInfo,
                _delayTime = this._delayTime,
                _ideLayTime = this._ideLayTime
            };
            _newButton._motionInfo.Owner = _newButton; //Very Important....
            return _newButton;
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
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_ideLayTime == _delayTime)
            {
                //Update sprite cho button.
                if (IsMouseHover)
                    _sprite[1].Itexture2D = (_sprite[1].Itexture2D + 1) % _sprite[1].Ntexture2D;
                else
                    _sprite[0].Itexture2D = (_sprite[0].Itexture2D + 1) % _sprite[0].Ntexture2D;

                //Update vị trí cho button.
                if (_motionInfo != null)
                {
                    if (!_motionInfo.IsStanding)
                    {
                        //Vector2 newPos = _motionInfo.Move(new Vector2(X, Y));
                        _motionInfo.Move(new Vector2(X, Y));
                        //X = newPos.X;
                        //Y = newPos.Y;
                    }
                }

                if (_isClicked)
                {
                    if (_motionInfo != null)
                    {
                        if (!_motionInfo.IsStanding)
                            _motionInfo.Move(new Vector2(X, Y));
                        else
                            OnMouse_Click(this, null);
                    }
                    else
                        OnMouse_Click(this, null);
                }
            }
            else
                _ideLayTime += 1;
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (_ideLayTime == _delayTime)
            {
                if (IsMouseHover)
                    _sprite[1].Draw(gameTime, sb);
                else
                    _sprite[0].Draw(gameTime, sb);
            }
        }

        public delegate void OnMouseClickHandler(object sender, EventArgs e);

        public event OnMouseClickHandler Mouse_Click;

        public void OnMouse_Click(Object sender, EventArgs e)
        {
            if (Mouse_Click != null)
            {
                Mouse_Click(sender, e);
            }
        }
        private MotionInfo SetButtonMotion(MotionInfo _preMotion)
        {
            MotionInfo _newMotion = _preMotion;
            _newMotion.IsStanding = false;
            _newMotion.FirstDection = "Right";
            _newMotion.StandingGround = float.MinValue;
            _newMotion.Vel = new Vector2(10, 0);
            _newMotion.Accel = new Vector2(1, 0);
            return _newMotion;
        }
    }
}

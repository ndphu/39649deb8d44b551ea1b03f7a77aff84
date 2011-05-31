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
    public class GameFrame : Dialog
    {
        List<VisibleGameObject> _child;

        public List<VisibleGameObject> Child
        {
            get { return _child; }
            set { _child = value; }
        }

        int _nChild;

        public int NChild
        {
            get { return _nChild; }
            set { _nChild = value; }
        }

        MotionInfo _motion;

        public MotionInfo Motion
        {
            get { return _motion; }
            set { 
                _motion = value;
                if (_motion != null)
                    _motion.Owner = this;
            }
        }

        int _delayTime = 0;

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

        bool _isVisible = true;

        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }


        public delegate void OnMoveCompletedHandler(object sender, EventArgs e);

        public event OnMoveCompletedHandler Move_Complete;

        public void OnMove_Complete(object sender, EventArgs e)
        {
            if (Move_Complete != null)
            {
                Move_Complete(sender, e);
            }
        }
        
        public GameFrame()
        {
            _child = new List<VisibleGameObject>();
            _motion = null;
            _nChild = 0;
            _delayTime = 0;
            _iDelayTime = 0;
        }

        public void AddChild(VisibleGameObject _object)
        {
            _child.Add(_object);
            _object.X = _x + _object.OffSetX;
            _object.Y = _y + _object.OffSetY;
            _object.Rect = new Rectangle((int)_object.X, (int)_object.Y, (int)_object.Width, (int)_object.Height);
            _nChild++;
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
                    _sprite[i].X = _x;
                for (int i = 0; i < _nChild; i++)
                {
                    _child[i].X = X + _child[i].OffSetX;
                    _child[i].Rect = new Rectangle((int)_child[i].X, (int)_child[i].Y, (int)_child[i].Width, (int)_child[i].Height);
                }
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
                    _sprite[i].Y = _y;
                for (int i = 0; i < _nChild; i++)
                {
                    _child[i].Y = Y + _child[i].OffSetY;
                    _child[i].Rect = new Rectangle((int)_child[i].X, (int)_child[i].Y, (int)_child[i].Width, (int)_child[i].Height);
                }
            }
        }

        public override VisibleGameObject Clone()
        {
            GameFrame _new = new GameFrame();
            _new._nsprite = this._nsprite;
            if (_new._nsprite == 0)
            {
                _new._sprite = null;
            }
            else
            {
                _new._sprite = new GameSprite[_new._nsprite];
                for (int i = 0; i < _new._nsprite; i++)
                {
                    _new._sprite[i] = this._sprite[i];
                }
            }
            _new._iDelayTime = this._iDelayTime;
            _new._delayTime = this._delayTime;
            _new._x = this._x;
            _new._y = this._y;
            _new.OffSetX = this.OffSetX;
            _new.OffSetY = this.OffSetY;
            _new._width = this._width;
            _new._height = this._height;
            _new._rect = this._rect;
            _new._motion = this._motion;
            if (_new._motion != null)
                _new._motion.Owner = _new;
            return _new;
        }

        public override void Update(GameTime gameTime)
        {
            if (_iDelayTime == _delayTime)
            {
                if (_motion != null)
                {
                    if (!_motion.IsStanding)
                    {
                        IsVisible = true;
                        _motion.Move(new Vector2(X, Y));
                        if (_motion.IsStanding)
                        {
                            Rectangle _testVisible = new Rectangle(0, 0, GlobalVariables.ScreenWidth, GlobalVariables.ScreenHeight);
                            Point _point1 = new Point((int)_x, (int)_y);
                            Point _point2 = new Point((int)_x + (int)_width, (int)_y);
                            Point _point3 = new Point((int)_x, (int)_y + (int)_height);
                            Point _point4 = new Point((int)_x + (int)_width, (int)_y + (int)_height);
                            if (_testVisible.Contains(_point1) || _testVisible.Contains(_point2) || _testVisible.Contains(_point3) || _testVisible.Contains(_point4))
                                _isVisible = true;
                            else
                                _isVisible = false;
                            OnMove_Complete(this, null);
                        }
                    }
                }
                for (int i = 0; i < _nChild; i++)
                {
                    _child[i].Update(gameTime);
                }
            }
            else
                _iDelayTime++;
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (_iDelayTime == _delayTime && _isVisible == true)
            {
                for (int i = 0; i < _nChild; i++)
                {
                    _child[i].Draw(gameTime, sb);
                }
                if (_sprite != null)
                {
                    sb.Draw(_sprite[0].Texture2D[0], new Vector2(X, Y), Color.White);
                }
            }
        }
    }
}

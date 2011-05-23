﻿using System;
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
    public class MenuFrame : Dialog
    {
        GameState _stateOwner;

        public GameState StateOwner
        {
            get { return _stateOwner; }
            set { _stateOwner = value; }
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

        /*
        List<Button> _child = new List<Button>();

        public List<Button> Child
        {
            get { return _child; }
            set { _child = value; }
        }
        */

        public MotionInfo _motionInfo;

        private int _delayTime = 0;

        public int DelayTime
        {
            get { return _delayTime; }
            set { _delayTime = value; }
        }

        private int _iDelayTime = 0;

        public int IDelayTime
        {
            get { return _iDelayTime; }
            set { _iDelayTime = value; }
        }

        /*int _menuIndex = 0;

        public int MenuIndex
        {
            get { return _menuIndex; }
            set { _menuIndex = value; }
        }*/

        //Color _color = new Color(160,160,160);
        //int _iSign = 2;

//--------------FUNCTION----------------------------------------------------------
        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (_iDelayTime == _delayTime)
            {
                //sb.Draw(_sprite[0].Texture2D[0], new Vector2(_sprite[0].X, _sprite[0].Y), _color);
                base.Draw(gameTime, sb);
                //for (int i = 0; i < _child.Count; ++i)
                //    _child[i].Draw(gameTime, sb);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_iDelayTime == _delayTime)
            {
                //Update vị trí cho menu.
                //if (!_motionInfo.IsStanding)
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
            }
            else
                _iDelayTime++;
        }

        public override void Init(ContentManager content)
        {   
            
        }

       
        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();  
            MenuFrame _newMenuFrame = new MenuFrame
            {
                _nsprite = this._nsprite,
                _sprite = _spriteTemp,
                Width = this.Width,
                Height = this.Height,
                Rect = this.Rect,
                X = this.X,
                Y = this.Y,            
                _motionInfo = this._motionInfo,
                _delayTime = this._delayTime
            };
            _newMenuFrame._motionInfo.Owner = _newMenuFrame;
            return _newMenuFrame;
        }

        public override void ChildNotify(VisibleGameObject child)
        {
            //_menuIndex = _child.IndexOf((Button)child);
        }

    }
}

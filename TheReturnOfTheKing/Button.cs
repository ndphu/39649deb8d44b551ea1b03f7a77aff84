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

namespace TheReturnOfTheKing
{
    public class Button : Dialog
    {
        //Lớp này chi có 1 con sprite với 2 texture: 0 - Idle; 1 - Clicked
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
                _rect = new Rectangle((int)_x, (int)_y, (int)_width, (int)_height);
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
                _rect = new Rectangle((int)_x, (int)_y, (int)_width, (int)_height);
            }
        }

        bool _mouseValidation = false;

        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();
            Button _new = new Button
            {
                _nsprite = this._nsprite,
                _sprite = _spriteTemp,
                Width = this.Width,
                Height = this.Height,
                Rect = this.Rect,
                X = this.X,
                Y = this.Y,
                OffSetX = this.OffSetX,
                OffSetY = this.OffSetY,
                IsMouseHover = false,
            };
            return _new;
        }

        public void GetNewIdleTexture(Texture2D _idle)
        {
            _sprite[0].Texture2D[0] = _idle;
        }

        public void GetNewClickedTexture(Texture2D _clicked)
        {
            _sprite[0].Texture2D[1] = _clicked;
        }

        public override void Update(GameTime gameTime)
        {
            if (_rect.Contains(GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y))
            {
                if (!IsMouseHover)
                {
                    if (!_rect.Contains(GlobalVariables.PreviousMouseState.X, GlobalVariables.PreviousMouseState.Y) && GlobalVariables.PreviousMouseState.LeftButton == ButtonState.Pressed)
                        _mouseValidation = false;
                    else
                        _mouseValidation = true;
                }
                if (_mouseValidation == false && GlobalVariables.CurrentMouseState.LeftButton == ButtonState.Released)
                {
                    _mouseValidation = true;
                    return;
                }

                IsMouseHover = true;
                OnMouse_Hover(this, null);

                if (_mouseValidation)
                {
                    if (GlobalVariables.CurrentMouseState.LeftButton == ButtonState.Pressed)
                    {
                        OnMouse_Down(this, null);
                    }
                    else if (GlobalVariables.CurrentMouseState.LeftButton == ButtonState.Released && GlobalVariables.PreviousMouseState.LeftButton == ButtonState.Pressed)
                    {
                        OnMouse_Click(this, null);
                    }
                }
            }
            else
            {
                if (IsMouseHover)
                {
                    IsMouseHover = false;
                    OnMouse_Released(this, null);
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(_sprite[0].Texture2D[_sprite[0].Itexture2D], new Vector2(X, Y), Color.White);
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


        public delegate void OnMouseHoverHandler(object sender, EventArgs e);

        public event OnMouseHoverHandler Mouse_Hover;

        public void OnMouse_Hover(Object sender, EventArgs e)
        {
            if (Mouse_Hover != null)
            {
                Mouse_Hover(sender, e);
            }
        }

        public delegate void OnMouseReleasedHandler(object sender, EventArgs e);

        public event OnMouseReleasedHandler Mouse_Released;

        public void OnMouse_Released(Object sender, EventArgs e)
        {
            if (Mouse_Released != null)
            {
                Mouse_Released(sender, e);
            }
        }

        public delegate void OnMouseDownHandler(object sender, EventArgs e);

        public event OnMouseDownHandler Mouse_Down;

        public void OnMouse_Down(Object sender, EventArgs e)
        {
            if (Mouse_Down != null)
            {
                Mouse_Down(sender, e);
            }
        }
    }
}

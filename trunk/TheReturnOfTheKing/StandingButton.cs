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
    public class StandingButton : Dialog
    {
        //Lớp này chi có 1 con sprite với 2 texture: 0 - Idle; 1 - Clicked
        bool _isClicked = false;

        public bool IsClicked
        {
            get { return _isClicked; }
            set { _isClicked = value; }
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

        /*public StandingButton()
        {
            base.Owner = null;
            IsClicked = false;
            base.IsMouseHover = false;
            base.X = 0;
            base.Y = 0;
            base.Width = 0;
            base.Height = 0;
            base.Rect = new Rectangle((int)base.X, (int)base.Y, (int)base.Width, (int)base.Height);
        }

        public StandingButton(StandingButton _startInfo)
        {
            base.Owner = _startInfo.Owner;
            base._nsprite = _startInfo._nsprite;
            base._sprite = _startInfo._sprite;
            IsClicked = _startInfo.IsClicked;
            base.IsMouseHover = _startInfo.IsMouseHover;
            base.X = _startInfo.X + base.Owner.X;
            base.Y = _startInfo.Y + base.Owner.Y;
            base.Width = _startInfo.Width;
            base.Height = _startInfo.Height;
            base.Rect = new Rectangle((int)base.X, (int)base.Y, (int)base.Width, (int)base.Height);
        }*/


        public virtual void Hovered()
        {
 
        }

        public virtual void Clicked()
        {
            _sprite[0].Itexture2D = 0;
        }

        public virtual void Downed()
        {
            _sprite[0].Itexture2D = 1;
        }

        public override void Update(GameTime gameTime)
        {
            if (_rect.Contains(GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y))
            {
                if (GlobalVariables.CurrentMouseState.LeftButton == ButtonState.Pressed)
                {
                    Downed();
                }
                else
                {
                    if (GlobalVariables.PreviousMouseState.LeftButton == ButtonState.Pressed)
                        Clicked();
                }
            }
            else
            {

            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            //sb.Draw(_sprite[0].Texture2D[_sprite[0].Itexture2D], new Vector2(X, Y), Color.White);
        }


        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();
            StandingButton _newStandingButton = new StandingButton
            {
                _nsprite = this._nsprite,
                _sprite = _spriteTemp,
                Width = this.Width,
                Height = this.Height,
                Rect = this.Rect,
                X = this.X,
                Y = this.Y,
                IsMouseHover = false,
                IsClicked = false
            };
            return _newStandingButton;
        }
    }
}
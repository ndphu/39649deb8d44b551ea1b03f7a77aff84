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
    public class Background : Misc
    {
        public override void Init(ContentManager content)
        {
            
        }

        public override VisibleGameObject Clone()
        {
            return new Background
            {
                _nsprite = this._nsprite,
                _sprite = this._sprite,
                _width = this._width,
                _height = this._height,
                _rect = this._rect,
                _x = this._x,
                _y = this._y
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            base.Draw(gameTime, sb);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}

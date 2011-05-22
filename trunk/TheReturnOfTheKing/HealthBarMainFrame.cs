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
    public class HealthBarMainFrame : GameFrame
    {
        public HealthBarMainFrame(GameFrame _gameFrame)
        {
            base.X = _gameFrame.X;
            base.Y = _gameFrame.Y;
            base.Width = _gameFrame.Width;
            base.Height = _gameFrame.Height;
            base._nsprite = _gameFrame._nsprite;
            base._sprite = _gameFrame._sprite;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            //1 Frame chỉ có 1 mình mà thôi
            sb.Draw(_sprite[0].Texture2D[0], new Vector2(X, Y), Color.White);
        }
    }
}

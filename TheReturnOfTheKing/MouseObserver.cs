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
    public class MouseObserver : GameObjectObserver
    {
        public override void Update(GameTime gt)
        {
            if (Observers.Count > 0)
            {
                for (int i = 0; i < Observers.Count; ++i)
                {
                    if (Observers[i].Rect.Contains(new Point(GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y)))
                    {
                        Observers[i].MouseEnter(this);
                        if (GlobalVariables.PreviousMouseState.LeftButton == ButtonState.Pressed && GlobalVariables.CurrentMouseState.LeftButton == ButtonState.Released)
                            Observers[i].MouseClick(this);
                    }
                    else
                        Observers[i].MouseLeave(this);
                }
            }
        }
    }
}

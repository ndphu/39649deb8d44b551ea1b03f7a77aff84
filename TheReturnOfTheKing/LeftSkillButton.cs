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
    public class LeftSkillButton : StandingButton
    {
        public LeftSkillButton(StandingButton _startInfo)
        {
            base.Owner = _startInfo.Owner;
            base._nsprite = _startInfo._nsprite;
            base._sprite = _startInfo._sprite;
            base.IsClicked = _startInfo.IsClicked;
            base.IsMouseHover = _startInfo.IsMouseHover;
            base.X = _startInfo.X + base.Owner.X;
            base.Y = _startInfo.Y + base.Owner.Y;
            base.Width = _startInfo.Width;
            base.Height = _startInfo.Height;
            base.Rect = new Rectangle((int)base.X, (int)base.Y, (int)base.Width, (int)base.Height);
        }
    }
}
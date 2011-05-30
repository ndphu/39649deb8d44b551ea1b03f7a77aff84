using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class ProjectileController
    {
        VisibleGameEntity _owner;

        public VisibleGameEntity Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public virtual UpdatePosition(GameTime gameTime)
        {
        }
    }
}

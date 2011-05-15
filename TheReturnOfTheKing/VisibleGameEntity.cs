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
    public abstract class VisibleGameEntity : VisibleGameObject
    {
        /// <summary>
        /// Hình chữ nhật để xét va chạm
        /// </summary>
        Rectangle _collisionRect;

        public Rectangle CollisionRect
        {
            get { return _collisionRect; }
            set { _collisionRect = value; }
        }

        public bool IsCollisionWith(VisibleGameEntity other)
        {
            if (other == null)
                return false;
            if (Math.Abs(other.X - this.X) < GlobalVariables.MapCollisionDim * 1 && Math.Abs(other.Y - this.Y) < GlobalVariables.MapCollisionDim * 1)
                return true;
            return false;
        }

    }
}

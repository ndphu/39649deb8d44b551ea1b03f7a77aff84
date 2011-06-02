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
    public abstract class GameObjectManager
    {
        protected VisibleGameObject[] _prototype;
        public int _nprototype;
        protected string _xmlInfo; //string luu lai duong dan~ den file XML

        

        public virtual bool InitOne(ContentManager content, int id)
        {
            _nprototype = 0;
            return true;
        }

        public virtual VisibleGameObject CreateObject(int idx)
        {
            if (0 <= idx && idx < _nprototype)
                return _prototype[idx].Clone();
            return null;
        }
    }
}

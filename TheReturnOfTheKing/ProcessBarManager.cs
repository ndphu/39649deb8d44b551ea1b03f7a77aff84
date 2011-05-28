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
    public class ProcessBarManager : GameObjectManager
    {
        public ProcessBarManager(string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);
                _nprototype = _doc.SelectNodes(@"//ProcessBar").Count;
                _prototype = new VisibleGameObject[_nprototype];
            }
            catch
            {
 
            }
        }

        public override bool InitOne(ContentManager content, int id)
        {
            XmlDocument _doc = new XmlDocument();
            _doc.Load(_xmlInfo);
            XmlNode _processbar = _doc.SelectSingleNode(@"//ProcessBar[@id = '" + id.ToString() + "']");

            string _animate = _processbar.SelectSingleNode(@"AnimateProcessBar").InnerText;
            string _stand = _processbar.SelectSingleNode(@"StandingProcessBar").InnerText;

            _prototype[id] = new ProcessBar();
            _prototype[id]._nsprite = 2;
            _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

            Texture2D _animateTex = content.Load<Texture2D>(_animate);
            _prototype[id]._sprite[0] = new GameSprite(_animateTex, 0, 0);

            Texture2D _standTex = content.Load<Texture2D>(_stand);
            _prototype[id]._sprite[1] = new GameSprite(_standTex, 0, 0);

            ((ProcessBar)_prototype[id]).XStartAnimatePro = int.Parse(_processbar.SelectSingleNode(@"StartAnimate").InnerText);
            ((ProcessBar)_prototype[id]).XEndAnimatePro = int.Parse(_processbar.SelectSingleNode(@"EndAnimate").InnerText);
            ((ProcessBar)_prototype[id]).Direction = _processbar.SelectSingleNode(@"Direction").InnerText;
            _prototype[id].X = float.Parse(_processbar.SelectSingleNode(@"X").InnerText);
            _prototype[id].Y = float.Parse(_processbar.SelectSingleNode(@"Y").InnerText);
            _prototype[id].OffSetX = _prototype[id].X;
            _prototype[id].OffSetY = _prototype[id].Y;

            _prototype[id].Width = float.Parse(_processbar.SelectSingleNode(@"Width").InnerText);
            _prototype[id].Height = float.Parse(_processbar.SelectSingleNode(@"Height").InnerText);

            _prototype[id].Rect = new Rectangle((int)_prototype[id].X, (int)_prototype[id].Y, (int)_prototype[id].Width, (int)_prototype[id].Height);

            return true;
        }
    }
}

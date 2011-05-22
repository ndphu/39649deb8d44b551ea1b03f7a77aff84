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
    public class GameFrameManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public GameFrameManager(string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);
                XmlNodeList _listFrame = _doc.DocumentElement.SelectNodes("//Frame");
                _nprototype = _listFrame.Count;
                _prototype = new VisibleGameObject [_nprototype];
            }
            catch
            {
 
            }
        }

        public override bool InitOne(ContentManager content, int id)
        {
            XmlDocument _doc = new XmlDocument();
            _doc.Load(_xmlInfo);
            XmlNode _frame = _doc.SelectSingleNode(@"//Frame[@id = '" + id.ToString() + "']");

            _prototype[id] = new GameFrame();
            _prototype[id]._nsprite = 1;
            _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

            Texture2D _temp = content.Load<Texture2D>(_frame.SelectSingleNode("Path").InnerText);
            _prototype[id]._sprite[0] = new GameSprite(_temp, 0, 0);
            _prototype[id].X = int.Parse(_frame.SelectSingleNode("X").InnerText);
            _prototype[id].Y = int.Parse(_frame.SelectSingleNode("Y").InnerText);
            return true;
        }
    }
}

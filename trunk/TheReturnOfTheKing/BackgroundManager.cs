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
    public class BackgroundManager : GameObjectManager
    {
        public BackgroundManager(string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);
                XmlNodeList _listBackground = _doc.SelectNodes(@"//Background");
                _nprototype = _listBackground.Count;
                _prototype = new VisibleGameObject[_nprototype];
            }
            catch
            {
 
            }
        }

        public override bool InitOne(ContentManager content, int id)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);
                XmlNode _background = _doc.SelectSingleNode(@"//Background[@id = '" + id.ToString() + "']");

                //Hardcode vi theo quy dinh trong game 1 background chi co 1 anh ma thôi
                _prototype[id] = new Background();
                _prototype[id]._nsprite = 1;
                _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

                _prototype[id]._sprite[0] = new GameSprite(content.Load<Texture2D>(_background.SelectSingleNode(@"ContentName").InnerText),
                    int.Parse(_background.SelectSingleNode(@"X").InnerText),
                    int.Parse(_background.SelectSingleNode(@"Y").InnerText));


            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

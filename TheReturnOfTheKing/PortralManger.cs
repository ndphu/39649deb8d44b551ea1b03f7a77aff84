using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
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
    public class PortralManger : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public PortralManger(string xmlInfo)
        {
            try
            {
                _xmlInfo = xmlInfo;
                XmlDocument _doc = new XmlDocument();

                _doc.Load(_xmlInfo);
                XmlNodeList _listPortral = _doc.SelectNodes(@"//Portral");
                _nprototype = _listPortral.Count;
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
            XmlNode _portral = _doc.SelectSingleNode(@"//Portral[@id = '" + id.ToString() + "']");
            _prototype[id] = new Portral();
            _prototype[id]._nsprite = 1;
            _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

            string contentName = _portral.SelectSingleNode(@"ContentName").InnerText;
            int nFrame = int.Parse(_portral.SelectSingleNode(@"NumOfFrame").InnerText);
            
            Texture2D[] _texture = new Texture2D[nFrame];
            for (int i = 0; i < nFrame; ++i)
                _texture[i] = content.Load<Texture2D>(contentName + i.ToString("00"));
            _prototype[id]._sprite[0] = new GameSprite(_texture, 0, 0);
            _prototype[id]._sprite[0].Xoffset = int.Parse(_portral.SelectSingleNode(@"XOffset").InnerText);
            _prototype[id]._sprite[0].Yoffset = int.Parse(_portral.SelectSingleNode(@"YOffset").InnerText);
            _prototype[id]._sprite[0].NDelay = 3;
            
            
            return true;
        }       
    }
}

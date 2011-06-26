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

                XmlNodeList _imageList = _background.SelectNodes("Image");
                _prototype[id] = new Background();
                _prototype[id]._nsprite = _imageList.Count;
                _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

                for (int i = 0; i < _prototype[id]._nsprite; i++)
                {
                    Texture2D _temp = content.Load<Texture2D>(_imageList[i].SelectSingleNode("Path").InnerText);
                    int _xTemp = int.Parse(_imageList[i].SelectSingleNode("X").InnerText) - (int)GlobalVariables.dX;
                    int _yTemp = int.Parse(_imageList[i].SelectSingleNode("Y").InnerText) - (int)GlobalVariables.dY;
                    _prototype[id]._sprite[i] = new GameSprite(_temp, _xTemp, _yTemp);
                    _prototype[id]._sprite[i].Xoffset = 0;
                    _prototype[id]._sprite[i].Yoffset = 0;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

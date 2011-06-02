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
    public class ButtonManger : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public ButtonManger(string xmlInfo)
        {
            try
            {
                _xmlInfo = xmlInfo;
                XmlDocument _doc = new XmlDocument();

                _doc.Load(_xmlInfo);
                XmlNodeList _listButton = _doc.SelectNodes(@"//Button");
                _nprototype = _listButton.Count;
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

            XmlNode _button = _doc.DocumentElement.SelectSingleNode("//Button[@id = '" + id.ToString() + "']");

            XmlNode _image = _button.SelectSingleNode("Image");
            Texture2D[] _temp = new Texture2D[_image.ChildNodes.Count];
            _temp[0] = content.Load<Texture2D>(_image.SelectSingleNode("Idle").InnerText);
            _temp[1] = content.Load<Texture2D>(_image.SelectSingleNode("Clicked").InnerText);

            _prototype[id] = new Button();
            _prototype[id]._nsprite = 1;
            _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];
            _prototype[id]._sprite[0] = new GameSprite(_temp, 0, 0);

            //_prototype[id].OffSetX = float.Parse(_button.SelectSingleNode("OffSetX").InnerText);
            //_prototype[id].OffSetY = float.Parse(_button.SelectSingleNode("OffSetY").InnerText);
            _prototype[id].X = float.Parse(_button.SelectSingleNode("X").InnerText);
            _prototype[id].Y = float.Parse(_button.SelectSingleNode("Y").InnerText);
            _prototype[id].OffSetX = _prototype[id].X;
            _prototype[id].OffSetY = _prototype[id].Y;

            _prototype[id].Width = float.Parse(_button.SelectSingleNode("Width").InnerText);
            _prototype[id].Height = float.Parse(_button.SelectSingleNode("Height").InnerText);
            _prototype[id].Rect = new Rectangle((int)_prototype[id].X,
                (int)_prototype[id].Y,
                (int)_prototype[id].Width,
                (int)_prototype[id].Height);
            return true;
        }
    }
}

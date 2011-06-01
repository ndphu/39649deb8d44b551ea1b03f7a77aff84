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
    public class LabelManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public LabelManager(string xmlInfo)
        {
            try
            {
                _xmlInfo = xmlInfo;
                XmlDocument _doc = new XmlDocument();

                _doc.Load(_xmlInfo);
                XmlNodeList _listLabel = _doc.SelectNodes(@"//Label");
                _nprototype = _listLabel.Count;
                _prototype = new VisibleGameObject[_nprototype];
            }
            catch
            {
                
            }
        }

        public override bool InitOne(Microsoft.Xna.Framework.Content.ContentManager content, int id)
        {
            XmlDocument _doc = new XmlDocument();
            _doc.Load(_xmlInfo);
            XmlNode _label = _doc.SelectSingleNode("//Label[@id = '" + id.ToString() + "']");

            _prototype[id] = new Label();

            _prototype[id]._nsprite = 1;
            _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];
            Texture2D _tempTexture = content.Load<Texture2D>(_label.SelectSingleNode ("BackGround").InnerText);
            _prototype[id]._sprite[0] = new GameSprite(_tempTexture, 0, 0);

            ((Label)_prototype[id]).Sf = content.Load<SpriteFont>(_label.SelectSingleNode("Font").InnerText);
            ((Label)_prototype[id]).StringInfo = _label.SelectSingleNode("StringInfo").InnerText;
            _prototype[id].X = int.Parse(_label.SelectSingleNode("X").InnerText);
            _prototype[id].Y = int.Parse(_label.SelectSingleNode("Y").InnerText);
            _prototype[id].OffSetX = _prototype[id].X;
            _prototype[id].OffSetY = _prototype[id].Y;
            ((Label)_prototype[id]).DrawOffSetX = int.Parse(_label.SelectSingleNode("DrawOffSetX").InnerText);
            ((Label)_prototype[id]).DrawOffSetY = int.Parse(_label.SelectSingleNode("DrawOffSetY").InnerText);

            float _red = float.Parse(_label.SelectSingleNode("Color").SelectSingleNode("R").InnerText);
            float _green = float.Parse(_label.SelectSingleNode("Color").SelectSingleNode("G").InnerText);
            float _blue = float.Parse(_label.SelectSingleNode("Color").SelectSingleNode("B").InnerText);
            ((Label)_prototype[id]).StringColor = new Color(_red, _green, _blue);

            return true;
        }
    }
}

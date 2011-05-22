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
    public class HealthBarManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public HealthBarManager(string xmlInfo)
        {
            try
            {
                _xmlInfo = xmlInfo;
                XmlDocument _doc = new XmlDocument();

                _doc.Load(_xmlInfo);
                XmlNodeList _listButton = _doc.SelectNodes(@"//HealthBar");
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
            XmlNode _healthBar = _doc.DocumentElement.SelectSingleNode("//HealthBar[@id = '" + id.ToString() + "']");

            _prototype[id] = new HealthBar();
            _prototype[id].X = int.Parse(_healthBar.SelectSingleNode("X").InnerText);
            _prototype[id].Y = int.Parse(_healthBar.SelectSingleNode("Y").InnerText);
            _prototype[id].Width = int.Parse(_healthBar.SelectSingleNode("Width").InnerText);
            _prototype[id].Height = int.Parse(_healthBar.SelectSingleNode("Height").InnerText);
            
            return true;
        }
    }
}

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
    public class CharacterManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }
        public CharacterManager(string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_xmlInfo);
                _nprototype = doc.SelectNodes(@"//Character").Count;
                _prototype = new VisibleGameObject[_nprototype];
            }
            catch
            {

            }
        }
        /*public override bool InitPrototypes(ContentManager content, string fileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNodeList nodelist = doc.SelectNodes(@"//Character");
                _nprototype = nodelist.Count;
                _prototype = new VisibleGameObject[_nprototype];
                for (int i = 0; i < nodelist.Count; ++i)
                {
                    _prototype[i] = new Character();
                    _prototype[i]._nsprite = 24;
                    _prototype[i]._sprite = new GameSprite[_prototype[i]._nsprite];
                    XmlNode node = nodelist[i].SelectSingleNode(@"Stand");
                    GameSprite[] temp = LoadSprites(node, content);
                    for (int j = 0; j < 8; ++j)
                        _prototype[i]._sprite[j] = temp[j];
                    node = nodelist[i].SelectSingleNode(@"Move");
                    temp = LoadSprites(node, content);
                    for (int j = 8; j < 16; ++j)
                        _prototype[i]._sprite[j] = temp[j - 8];
                    node = nodelist[i].SelectSingleNode(@"Attack");
                    temp = LoadSprites(node, content);
                    for (int j = 16; j < 24; ++j)
                        _prototype[i]._sprite[j] = temp[j - 16];
                    ((Character)_prototype[i]).CellToMove = new List<Point>();
                    ((Character)_prototype[i]).DestPoint = new Point();
                    ((Character)_prototype[i]).IsMoving = false;
                    ((Character)_prototype[i]).Map = null;
                    ((Character)_prototype[i]).Speed = int.Parse(nodelist[i].SelectSingleNode(@"Speed").InnerText);
                    ((Character)_prototype[i]).X = 0;
                    ((Character)_prototype[i]).Y = 0;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        */
    }
}

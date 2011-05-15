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
    public class GameTitleManager : GameObjectManager
    {
        public GameTitleManager (string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument _doc = new XmlDocument ();
                _doc.Load (_xmlInfo);
                _nprototype = _doc.SelectNodes(@"//GameTitle").Count;
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
                XmlNode _gameTitle = _doc.SelectSingleNode(@"//GameTitle[@id = '" + id.ToString() + "']");

                _prototype[id] = new GameTitle();
                XmlNodeList _listOfTitle = _gameTitle.SelectNodes(@"//Title");
                _prototype[id]._nsprite = _listOfTitle.Count;
                _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

                for (int i = 0; i < _prototype[id]._nsprite; i++)
                {
                    int _numofframe = int.Parse(_listOfTitle[i].SelectSingleNode(@"NumOfFrames").InnerText);
                    string _contentname = _listOfTitle[i].SelectSingleNode(@"ContentName").InnerText;

                    Texture2D[] _textures = new Texture2D[_numofframe];

                    for (int j = 0; j < _numofframe; ++j)
                    {
                        _textures[j] = content.Load<Texture2D>(_contentname + j.ToString("00"));
                    }
                     _prototype[id]._sprite[i] = new GameSprite(_textures, 0, 0);
                }

                _prototype[id].X = float.Parse(_gameTitle.SelectSingleNode(@"X").InnerText);
                _prototype[id].Y = float.Parse(_gameTitle.SelectSingleNode(@"Y").InnerText);
                ((GameTitle)_prototype[id]).DelayTime = int.Parse((_gameTitle.SelectSingleNode(@"DelayTime").InnerText));
            }

            catch
            {
                return false;
            }
            return true;
        }
    }
}

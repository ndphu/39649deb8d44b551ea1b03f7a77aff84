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
    public class ProjectileManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public ProjectileManager(string xmlInfo)
        {
            try
            {
                _xmlInfo = xmlInfo;
                XmlDocument _doc = new XmlDocument();

                _doc.Load(_xmlInfo);
                XmlNodeList _listProjectile = _doc.SelectNodes(@"//Projectile");
                _nprototype = _listProjectile.Count;
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
            XmlNode _projectile = _doc.SelectSingleNode(@"//Projectile[@id = '" + id.ToString() + "']");
            _prototype[id] = new Projectile();
            _prototype[id]._nsprite = 1;
            _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

            string contentName = _projectile.SelectSingleNode(@"ContentName").InnerText;
            int nFrame = int.Parse(_projectile.SelectSingleNode(@"NumOfFrame").InnerText);

            Texture2D[] _texture = new Texture2D[nFrame];
            for (int i = 0; i < nFrame; ++i)
                _texture[i] = content.Load<Texture2D>(contentName + i.ToString("00"));
            _prototype[id]._sprite[0] = new GameSprite(_texture, 0, 0);
            _prototype[id]._sprite[0].Xoffset = int.Parse(_projectile.SelectSingleNode(@"XOffset").InnerText);
            _prototype[id]._sprite[0].Yoffset = int.Parse(_projectile.SelectSingleNode(@"YOffset").InnerText);
            _prototype[id]._sprite[0].NDelay = 3;

            ((Projectile)_prototype[id]).StartObstacleX = int.Parse(_projectile.SelectSingleNode(@"StartObstacleX").InnerText);
            ((Projectile)_prototype[id]).StartObstacleY = int.Parse(_projectile.SelectSingleNode(@"StartObstacleY").InnerText);
            ((Projectile)_prototype[id]).ObstacleWidth = int.Parse(_projectile.SelectSingleNode(@"ObstacleWidth").InnerText);
            ((Projectile)_prototype[id]).ObstacleHeight = int.Parse(_projectile.SelectSingleNode(@"ObstacleHeight").InnerText);
            try
            {
                ((Projectile)_prototype[id])._sprite[0].NDelay = int.Parse(_projectile.SelectSingleNode(@"NDelay").InnerText);
            }
            catch
            {
            }
            ((Projectile)_prototype[id]).HitFrames = new List<int>();
            XmlNodeList _frameList = _projectile.SelectNodes(@"HitFrame");
            for (int i = 0; i < _frameList.Count; ++i)
            {
                ((Projectile)_prototype[id]).HitFrames.Add(int.Parse(_frameList[i].InnerText));
            }
            return true;
        }
    
    }
}

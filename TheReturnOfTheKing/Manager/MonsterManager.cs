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
    public class MonsterManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }
        public MonsterManager(string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_xmlInfo);
                _nprototype = doc.SelectNodes(@"//Monster").Count;
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
            XmlNode _monster = _doc.SelectSingleNode(@"//Monster[@id = '" + id.ToString() + "']");
            _prototype[id] = new Monster();
            _prototype[id]._nsprite = 40;
            _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

            XmlNode node = _monster.SelectSingleNode(@"Stand");
            GameSprite[] temp = Utility.LoadSprites(node, content);
            for (int j = 0; j < 8; ++j)
                _prototype[id]._sprite[j] = temp[j];

            node = _monster.SelectSingleNode(@"Move");
            temp = Utility.LoadSprites(node, content);
            for (int j = 8; j < 16; ++j)
                _prototype[id]._sprite[j] = temp[j - 8];

            node = _monster.SelectSingleNode(@"Attack");
            temp = Utility.LoadSprites(node, content);
            for (int j = 16; j < 24; ++j)
                _prototype[id]._sprite[j] = temp[j - 16];

            node = _monster.SelectSingleNode(@"Dying");
            temp = Utility.LoadSprites(node, content);
            for (int j = 24; j < 32; ++j)
                _prototype[id]._sprite[j] = temp[j - 24];

            node = _monster.SelectSingleNode(@"Dyed");
            temp = Utility.LoadSprites(node, content);
            for (int j = 32; j < 40; ++j)
                _prototype[id]._sprite[j] = temp[j - 32];

            ((Monster)_prototype[id]).CellToMove = new List<Point>();
            ((Monster)_prototype[id]).DestPoint = new Point();
            ((Monster)_prototype[id]).IsMoving = false;
            ((Monster)_prototype[id]).Map = null;
            ((Monster)_prototype[id]).Speed = int.Parse(_monster.SelectSingleNode(@"Speed").InnerText);
            ((Monster)_prototype[id]).Hp = int.Parse(_monster.SelectSingleNode(@"Hp").InnerText);
            ((Monster)_prototype[id]).Mp = int.Parse(_monster.SelectSingleNode(@"Mp").InnerText);
            ((Monster)_prototype[id]).CriticalRate = int.Parse(_monster.SelectSingleNode(@"CriticalRate").InnerText);
            ((Monster)_prototype[id]).MinDamage = int.Parse(_monster.SelectSingleNode(@"MinDamage").InnerText);
            ((Monster)_prototype[id]).MaxDamage = int.Parse(_monster.SelectSingleNode(@"MaxDamage").InnerText);
            ((Monster)_prototype[id]).Defense = int.Parse(_monster.SelectSingleNode(@"Defense").InnerText);
            ((Monster)_prototype[id]).AttackSpeed = int.Parse(_monster.SelectSingleNode(@"AttackSpeed").InnerText);
            ((Monster)_prototype[id]).Range = int.Parse(_monster.SelectSingleNode(@"Range").InnerText);
            ((Monster)_prototype[id]).X = 0;
            ((Monster)_prototype[id]).Y = 0;
            ((Monster)_prototype[id]).HitFrame = int.Parse(_monster.SelectSingleNode(@"HitFrame").InnerText);
            ((Monster)_prototype[id]).Sight = int.Parse(_monster.SelectSingleNode(@"Sight").InnerText);
            ((Monster)_prototype[id]).MaxHp = int.Parse(_monster.SelectSingleNode(@"MaxHp").InnerText);
            ((Monster)_prototype[id]).MaxMp = int.Parse(_monster.SelectSingleNode(@"MaxMp").InnerText);
            ((Monster)_prototype[id]).ChangeToDodge = int.Parse(_monster.SelectSingleNode(@"ChangeToDodge").InnerText);
            ((Monster)_prototype[id]).ExpReward = int.Parse(_monster.SelectSingleNode(@"ExpReward").InnerText);
            return true;
        }
    }
}

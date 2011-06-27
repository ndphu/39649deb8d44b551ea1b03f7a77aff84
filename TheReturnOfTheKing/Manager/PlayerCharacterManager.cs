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
    public class PlayerCharacterManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }
        public PlayerCharacterManager(string xmlInfo)
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

        public override bool InitOne(ContentManager content, int id)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);
                XmlNode _char = _doc.SelectSingleNode(@"//Character[@id = '" + id.ToString() + "']");
                _prototype[id] = new PlayerCharacter();
                _prototype[id]._nsprite = 56;
                _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

                XmlNode node = _char.SelectSingleNode(@"Stand");
                GameSprite[] temp = Utility.LoadSprites(node, content);
                for (int j = 0; j < 8; ++j)
                    _prototype[id]._sprite[j] = temp[j];

                node = _char.SelectSingleNode(@"Move");
                temp = Utility.LoadSprites(node, content);
                for (int j = 8; j < 16; ++j)
                    _prototype[id]._sprite[j] = temp[j - 8];

                node = _char.SelectSingleNode(@"Attack1");
                temp = Utility.LoadSprites(node, content);
                for (int j = 16; j < 24; ++j)
                    _prototype[id]._sprite[j] = temp[j - 16];

                node = _char.SelectSingleNode(@"Attack2");
                temp = Utility.LoadSprites(node, content);
                for (int j = 24; j < 32; ++j)
                    _prototype[id]._sprite[j] = temp[j - 24];

                node = _char.SelectSingleNode(@"Dying");
                temp = Utility.LoadSprites(node, content);
                for (int j = 32; j < 40; ++j)
                    _prototype[id]._sprite[j] = temp[j - 32];

                node = _char.SelectSingleNode(@"Dyed");
                temp = Utility.LoadSprites(node, content);
                for (int j = 40; j < 48; ++j)
                    _prototype[id]._sprite[j] = temp[j - 40];

                node = _char.SelectSingleNode(@"Skill");
                temp = Utility.LoadSprites(node, content);
                for (int j = 48; j < 56; ++j)
                    _prototype[id]._sprite[j] = temp[j - 48];

                ((PlayerCharacter)_prototype[id]).CellToMove = new List<Point>();
                ((PlayerCharacter)_prototype[id]).DestPoint = new Point();
                ((PlayerCharacter)_prototype[id]).IsMoving = false;
                ((PlayerCharacter)_prototype[id]).Map = null;
                ((PlayerCharacter)_prototype[id]).Speed = int.Parse(_char.SelectSingleNode(@"Speed").InnerText);
                ((PlayerCharacter)_prototype[id]).Hp = int.Parse(_char.SelectSingleNode(@"Hp").InnerText);
                ((PlayerCharacter)_prototype[id]).Mp = int.Parse(_char.SelectSingleNode(@"Mp").InnerText);
                ((PlayerCharacter)_prototype[id]).CriticalRate = int.Parse(_char.SelectSingleNode(@"CriticalRate").InnerText);
                ((PlayerCharacter)_prototype[id]).MinDamage = int.Parse(_char.SelectSingleNode(@"MinDamage").InnerText);
                ((PlayerCharacter)_prototype[id]).MaxDamage = int.Parse(_char.SelectSingleNode(@"MaxDamage").InnerText);
                ((PlayerCharacter)_prototype[id]).Defense = int.Parse(_char.SelectSingleNode(@"Defense").InnerText);
                ((PlayerCharacter)_prototype[id]).AttackSpeed = int.Parse(_char.SelectSingleNode(@"AttackSpeed").InnerText);
                ((PlayerCharacter)_prototype[id]).Range = int.Parse(_char.SelectSingleNode(@"Range").InnerText);
                ((PlayerCharacter)_prototype[id]).X = 0;
                ((PlayerCharacter)_prototype[id]).Y = 0;
                ((PlayerCharacter)_prototype[id]).HitFrame = int.Parse(_char.SelectSingleNode(@"HitFrame").InnerText);
                ((PlayerCharacter)_prototype[id]).CastFrame = int.Parse(_char.SelectSingleNode(@"CastFrame").InnerText);
                ((PlayerCharacter)_prototype[id]).MaxHp = int.Parse(_char.SelectSingleNode(@"MaxHp").InnerText);
                ((PlayerCharacter)_prototype[id]).MaxMp = int.Parse(_char.SelectSingleNode(@"MaxMp").InnerText);
                ((PlayerCharacter)_prototype[id]).ChangeToDodge = int.Parse(_char.SelectSingleNode(@"ChangeToDodge").InnerText);
                ((PlayerCharacter)_prototype[id]).Level = 1;
                ((PlayerCharacter)_prototype[id]).CurrentEXP = 0;
                ((PlayerCharacter)_prototype[id]).NextLevelEXP = 6000;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

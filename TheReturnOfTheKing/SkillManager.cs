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
    public class SkillManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public SkillManager(string xmlInfo)
        {
            try
            {
                _xmlInfo = xmlInfo;
                XmlDocument _doc = new XmlDocument();

                _doc.Load(_xmlInfo);
                XmlNodeList _listSkill = _doc.SelectNodes(@"//Skill");
                _nprototype = _listSkill.Count;
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
            XmlNode _skill = _doc.SelectSingleNode(@"//Skill[@id = '" + id.ToString() + "']");
            _prototype[id] = new Skill();
            _prototype[id]._nsprite = 0;

            ((Skill)_prototype[id]).Level = 1;
            ((Skill)_prototype[id]).ListLevel = new List<SkillLevel>();
            XmlNodeList _levelList = _skill.SelectNodes(@"Level");
            for (int i = 0; i < _levelList.Count; ++i)
            {
                SkillLevel _skillInfo = new SkillLevel();
                _skillInfo.ListSkillInfo = new List<SkillInfo>();
                XmlNodeList _projectiles = _levelList[i].SelectNodes(@"Projectile");
                for (int j = 0; j < _projectiles.Count; ++j)
                {
                    _skillInfo.ListSkillInfo.Add(new SkillInfo
                    {
                        Type = int.Parse(_projectiles[j].SelectSingleNode(@"Type").InnerText),
                        X = int.Parse(_projectiles[j].SelectSingleNode(@"X").InnerText),
                        Y = int.Parse(_projectiles[j].SelectSingleNode(@"Y").InnerText),
                    });
                }
                ((Skill)_prototype[id]).ListLevel.Add(_skillInfo);
            }
            return true;
        }
    }
}

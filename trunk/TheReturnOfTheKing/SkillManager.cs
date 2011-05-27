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
            switch (_skill.SelectSingleNode(@"Name").InnerText)
            {
                case "Cleaving Attack":
                    {
                        _prototype[id] = new CleavingAttackSkill();
                        _prototype[id]._nsprite = 0;
                        ((CleavingAttackSkill)_prototype[id]).Name = "Cleaving Attack";
                        ((CleavingAttackSkill)_prototype[id]).Level = 0;
                        ((CleavingAttackSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.PercentDamage = int.Parse(_levelList[i].SelectSingleNode(@"PercentDamage").InnerText);
                            _skillInfo.Type = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((CleavingAttackSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "Critical Attack":
                    {
                        _prototype[id] = new CriticalAttackSkill();
                        _prototype[id]._nsprite = 0;
                        ((CriticalAttackSkill)_prototype[id]).Name = "Critical Attack";
                        ((CriticalAttackSkill)_prototype[id]).Level = 0;
                        ((CriticalAttackSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.PercentDamage = int.Parse(_levelList[i].SelectSingleNode(@"PercentDamage").InnerText);
                            _skillInfo.Type = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((CriticalAttackSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "Curse Attack":
                    {
                        _prototype[id] = new CurseAttackSkill();
                        _prototype[id]._nsprite = 0;
                        ((CurseAttackSkill)_prototype[id]).Name = "Curse Attack";
                        ((CurseAttackSkill)_prototype[id]).Level = 0;
                        ((CurseAttackSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.PercentDamage = int.Parse(_levelList[i].SelectSingleNode(@"PercentDamage").InnerText);
                            _skillInfo.Type = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.AmorReduce = int.Parse(_levelList[i].SelectSingleNode(@"AmorReduce").InnerText);
                            _skillInfo.ChanceToCurse = int.Parse(_levelList[i].SelectSingleNode(@"ChanceToCurse").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((CurseAttackSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "OverSpeed Attack":
                    {
                        _prototype[id] = new OverSpeedAttackSkill();
                        _prototype[id]._nsprite = 0;
                        ((OverSpeedAttackSkill)_prototype[id]).Name = "OverSpeed Attack";
                        ((OverSpeedAttackSkill)_prototype[id]).Level = 0;
                        ((OverSpeedAttackSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.PercentDamage = int.Parse(_levelList[i].SelectSingleNode(@"PercentDamage").InnerText);
                            _skillInfo.Hp = int.Parse(_levelList[i].SelectSingleNode(@"HP").InnerText);
                            _skillInfo.NumOfHit = int.Parse(_levelList[i].SelectSingleNode(@"NumOfHit").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((OverSpeedAttackSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "LifeSteal Attack":
                    {
                        _prototype[id] = new LifeStealAttackSkill();
                        _prototype[id]._nsprite = 0;
                        ((LifeStealAttackSkill)_prototype[id]).Name = "LifeSteal Attack";
                        ((LifeStealAttackSkill)_prototype[id]).Level = 0;
                        ((LifeStealAttackSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.PercentDamage = int.Parse(_levelList[i].SelectSingleNode(@"PercentDamage").InnerText);
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.PercentLifeSteal = int.Parse(_levelList[i].SelectSingleNode(@"PercentLifeSteal").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((LifeStealAttackSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "Bash Attack":
                    {
                        _prototype[id] = new BashAttackSkill();
                        _prototype[id]._nsprite = 0;
                        ((BashAttackSkill)_prototype[id]).Name = "Bash Attack";
                        ((BashAttackSkill)_prototype[id]).Level = 0;
                        ((BashAttackSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.PercentDamage = int.Parse(_levelList[i].SelectSingleNode(@"PercentDamage").InnerText);
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.ChanceToBash = int.Parse(_levelList[i].SelectSingleNode(@"ChanceToBash").InnerText);
                            _skillInfo.BashTime = int.Parse(_levelList[i].SelectSingleNode(@"BashTime").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((BashAttackSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                default:
                    {
                        _prototype[id] = new Skill();
                        _prototype[id]._nsprite = 0;

                        ((Skill)_prototype[id]).Level = 0;
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
                    }
                    break;
            }
            ((Skill)_prototype[id]).LargeIcon = content.Load<Texture2D>(_skill.SelectSingleNode(@"Large").InnerText);
            ((Skill)_prototype[id]).ClickedIcon = content.Load<Texture2D>(_skill.SelectSingleNode(@"Clicked").InnerText);
            ((Skill)_prototype[id]).IdleIcon = content.Load<Texture2D>(_skill.SelectSingleNode(@"Idle").InnerText);
            return true;
        }
    }
}

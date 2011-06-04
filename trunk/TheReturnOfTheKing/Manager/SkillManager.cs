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
                case "Normal Attack":
                    {
                        _prototype[id] = new NormalAttackSkill();
                        _prototype[id]._nsprite = 0;
                        ((NormalAttackSkill)_prototype[id]).Name = "Normal Attack";
                        ((NormalAttackSkill)_prototype[id]).Level = 0;
                        ((NormalAttackSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.PercentDamage = int.Parse(_levelList[i].SelectSingleNode(@"PercentDamage").InnerText);
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((NormalAttackSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
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
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
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
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
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
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
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
                case "Deadly Bee":
                    {
                        _prototype[id] = new DeadlyBeeSkill();
                        _prototype[id]._nsprite = 0;
                        ((DeadlyBeeSkill)_prototype[id]).Name = "Deadly Bee";
                        ((DeadlyBeeSkill)_prototype[id]).Level = 0;
                        ((DeadlyBeeSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.MaxDamage = int.Parse(_levelList[i].SelectSingleNode(@"MaxDamage").InnerText);
                            _skillInfo.MinDamage = int.Parse(_levelList[i].SelectSingleNode(@"MinDamage").InnerText);
                            _skillInfo.NumOfBee = int.Parse(_levelList[i].SelectSingleNode(@"NumberOfBee").InnerText);
                            _skillInfo.BeeLifeTime = int.Parse(_levelList[i].SelectSingleNode(@"BeeLifeTime").InnerText) * 60;
                            _skillInfo.CoolDown = int.Parse(_levelList[i].SelectSingleNode(@"CoolDown").InnerText) * 60;
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((DeadlyBeeSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "Souls Release":
                    {
                        _prototype[id] = new SoulsReleaseSkill();
                        _prototype[id]._nsprite = 0;
                        ((SoulsReleaseSkill)_prototype[id]).Name = "Souls Release";
                        ((SoulsReleaseSkill)_prototype[id]).Level = 0;
                        ((SoulsReleaseSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel(); 
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.MaxDamage = int.Parse(_levelList[i].SelectSingleNode(@"MaxDamage").InnerText);
                            _skillInfo.MinDamage = int.Parse(_levelList[i].SelectSingleNode(@"MinDamage").InnerText);                            
                            _skillInfo.CoolDown = int.Parse(_levelList[i].SelectSingleNode(@"CoolDown").InnerText) * 60;
                            _skillInfo.NumOfSoul = int.Parse(_levelList[i].SelectSingleNode(@"NumberOfSoul").InnerText);
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((SoulsReleaseSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "Earth Shake":
                    {
                        _prototype[id] = new EarthShakeSkill();
                        _prototype[id]._nsprite = 0;
                        ((EarthShakeSkill)_prototype[id]).Name = "Earth Shake";
                        ((EarthShakeSkill)_prototype[id]).Level = 0;
                        ((EarthShakeSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.MaxDamage = int.Parse(_levelList[i].SelectSingleNode(@"MaxDamage").InnerText);
                            _skillInfo.MinDamage = int.Parse(_levelList[i].SelectSingleNode(@"MinDamage").InnerText);
                            _skillInfo.CoolDown = int.Parse(_levelList[i].SelectSingleNode(@"CoolDown").InnerText) * 60;
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillInfo.BashTime = int.Parse(_levelList[i].SelectSingleNode(@"BashTime").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((EarthShakeSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "Wave Form":
                    {
                        _prototype[id] = new WaveFormSkill();
                        _prototype[id]._nsprite = 0;
                        ((WaveFormSkill)_prototype[id]).Name = "Wave Form";
                        ((WaveFormSkill)_prototype[id]).Level = 0;
                        ((WaveFormSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        ((WaveFormSkill)_prototype[id]).ReleaseProjectileDelay = int.Parse(_skill.SelectSingleNode(@"Delay").InnerText);
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.MaxDamage = int.Parse(_levelList[i].SelectSingleNode(@"MaxDamage").InnerText);
                            _skillInfo.MinDamage = int.Parse(_levelList[i].SelectSingleNode(@"MinDamage").InnerText);
                            _skillInfo.CoolDown = int.Parse(_levelList[i].SelectSingleNode(@"CoolDown").InnerText) * 60;
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillInfo.CastRange = int.Parse(_levelList[i].SelectSingleNode(@"CastRange").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((WaveFormSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "Lightning Field":
                    {
                        _prototype[id] = new LightningFieldSkill();
                        _prototype[id]._nsprite = 0;
                        ((LightningFieldSkill)_prototype[id]).Name = "Lightning Field";
                        ((LightningFieldSkill)_prototype[id]).Level = 0;
                        ((LightningFieldSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.MaxDamage = int.Parse(_levelList[i].SelectSingleNode(@"MaxDamage").InnerText);
                            _skillInfo.MinDamage = int.Parse(_levelList[i].SelectSingleNode(@"MinDamage").InnerText);
                            _skillInfo.CoolDown = int.Parse(_levelList[i].SelectSingleNode(@"CoolDown").InnerText) * 60;
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillInfo.NumberOfStar = int.Parse(_levelList[i].SelectSingleNode(@"NumberOfStar").InnerText);
                            _skillInfo.Duration = int.Parse(_levelList[i].SelectSingleNode(@"Duration").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((LightningFieldSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                case "Invisible Poison":
                    {
                        _prototype[id] = new InvisiblePoisonSkill();
                        _prototype[id]._nsprite = 0;
                        ((InvisiblePoisonSkill)_prototype[id]).Name = "Invisible Poison";
                        ((InvisiblePoisonSkill)_prototype[id]).Level = 0;
                        ((InvisiblePoisonSkill)_prototype[id]).ListLevel = new List<SkillLevel>();
                        XmlNodeList _levelList = _skill.SelectNodes(@"Level");
                        for (int i = 0; i < _levelList.Count; ++i)
                        {
                            SkillLevel _skillLevel = new SkillLevel();
                            _skillLevel.ListSkillInfo = new List<SkillInfo>();
                            SkillInfo _skillInfo = new SkillInfo();
                            _skillInfo.MaxDamage = int.Parse(_levelList[i].SelectSingleNode(@"MaxDamage").InnerText);
                            _skillInfo.MinDamage = int.Parse(_levelList[i].SelectSingleNode(@"MinDamage").InnerText);
                            _skillInfo.Mp = int.Parse(_levelList[i].SelectSingleNode(@"MP").InnerText);
                            _skillInfo.Hp = int.Parse(_levelList[i].SelectSingleNode(@"HP").InnerText);
                            _skillInfo.ProjectileType = int.Parse(_levelList[i].SelectSingleNode(@"ProjectileType").InnerText);
                            _skillLevel.ListSkillInfo.Add(_skillInfo);
                            ((InvisiblePoisonSkill)_prototype[id]).ListLevel.Add(_skillLevel);
                        }
                    }
                    break;
                default:
                    {
                        
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

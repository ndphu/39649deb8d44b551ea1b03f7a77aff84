using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class InvisiblePoisonSkill : Skill
    {
        public override VisibleGameObject Clone()
        {
            return new InvisiblePoisonSkill
            {
                X = this.X,
                Y = this.Y,
                Level = this.Level,
                ListLevel = this.ListLevel,
                IdleIcon = this.IdleIcon,
                LargeIcon = this.LargeIcon,
                ClickedIcon = this.ClickedIcon,
                SoundName = this.SoundName,
            };
        }
        Projectile prjt;
        int _tick = 60;
        List<Monster> _listMonster = new List<Monster>();
        public override void Active()
        {
            base.Active();
            if (!PlayerOwner.StateOwner._listProjectile.Contains(prjt))
            {
                prjt = (Projectile)PlayerOwner.StateOwner._objectManagerArray[6].CreateObject(ListLevel[Level].ListSkillInfo[0].ProjectileType);
                prjt.ProjectileController = new PoisonWormController();
                prjt.ProjectileController.Owner = prjt;
                prjt.SkillOwner = this;
                prjt.DelayTime = 0;
                prjt.LifeTime = int.MaxValue;
                prjt.IsRemoveAfterEffect = false;
                PlayerOwner.StateOwner._listProjectile.Add(prjt);
            }
        }
        public override void Deactive()
        {
            base.Deactive();
            if (prjt != null && PlayerOwner.StateOwner._listProjectile.Contains(prjt))
                PlayerOwner.StateOwner._listProjectile.Remove(prjt);
        }

        public override void DoEffect(VisibleGameEntity _object)
        {
            base.DoEffect(_object);
        }

        public override void DoAdditionalEffect(VisibleGameEntity target)
        {
            base.DoAdditionalEffect(target);
            
                if (target != null)
                {
                    if (!_listMonster.Contains((Monster)target))
                        _listMonster.Add((Monster)target);
                }
            
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (_tick == 0)
            {
                if (IsActivated && Level != 0)
                {
                    PlayerOwner.Hp += ListLevel[Level].ListSkillInfo[0].Hp;
                    PlayerOwner.Mp += ListLevel[Level].ListSkillInfo[0].Mp;
                    
                }
                _tick = 30;
            }
            else
                _tick -= 1;
            if (IsActivated && Level != 0)
            {
                for (int i = 0; i < _listMonster.Count; ++i)
                {
                    _listMonster[i].ListPoisonDamage.Add(new PoisonDamage
                    {
                        DamageValue = -GlobalVariables.GlobalRandom.Next(ListLevel[Level].ListSkillInfo[0].MinDamage, ListLevel[Level].ListSkillInfo[0].MaxDamage),
                        Duration = ListLevel[Level].ListSkillInfo[0].Duration,
                        EffectMoment = 30,
                    });
                }
                _listMonster.Clear();
            }
            //_listMonster.Clear();
        }
    }
}

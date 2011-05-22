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

namespace TheReturnOfTheKing
{
    public class PlayerCharacter : Character
    {

        Skill _leftHandSkill;

        public Skill LeftHandSkill
        {
            get { return _leftHandSkill; }
            set { _leftHandSkill = value; }
        }

        Skill _rightHandSkill;

        public Skill RightHandSkill
        {
            get { return _rightHandSkill; }
            set { _rightHandSkill = value; }
        }

        /// <summary>
        /// Điểm kinh nghiệm
        /// </summary>
        int _xp;

        public int Xp
        {
            get { return _xp; }
            set { _xp = value; }
        }
        /// <summary>
        /// Đẳng cấp của nhân vật
        /// </summary>
        int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public override bool IsCasting
        {
            get
            {
                return base.IsCasting;
            }
            set
            {
                base.IsCasting = value;
                if (value == true)
                    State = 48;
            }
        }

        public override bool IsAttacking
        {
            get
            {
                return base.IsAttacking;
            }
            set
            {
                base.IsAttacking = value;
                
                if (value == true)
                {
                    //_isCasting = false;
                    State = 24;
                }
            }
        }

        public override bool IsDyed
        {
            get
            {
                return base.IsDyed;
            }
            set
            {
                base.IsDyed = value;

                if (value == true)
                {
                    //_isCasting = false;
                    State = 40;
                }
            }
        }

        public override bool IsDying
        {
            get
            {
                return base.IsDying;
            }
            set
            {
                base.IsDying = value;

                if (value == true)
                {
                    //_isCasting = false;
                    State = 32;
                }
            }
        }

        public override bool IsMoving
        {
            get
            {
                return base.IsMoving;
            }
            set
            {
                base.IsMoving = value;

                if (value == true)
                {
                    //_isCasting = false;
                    State = 8;
                }
            }
        }

        public override bool IsStanding
        {
            get
            {
                return base.IsStanding;
            }
            set
            {
                base.IsStanding = value;

                if (value == true)
                {
                    //_isCasting = false;
                    State = 0;
                }
            }
        }

        public override void SetMap(Map map)
        {
            base.SetMap(map);
            X = map.StartPointX * map.CollisionDim;
            Y = map.StartPointY * map.CollisionDim;
            GlobalVariables.dX = Math.Min(-X + GlobalVariables.ScreenWidth / 2, 0);
            GlobalVariables.dY = Math.Min(-Y + GlobalVariables.ScreenHeight / 2, 0);
            DestPoint = new Point((int)X, (int)Y);   
        }

        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();
            return new PlayerCharacter
            {
                _nsprite = this._nsprite,
                _sprite = _spriteTemp,
                MinDamage = this.MinDamage,
                MaxDamage = this.MaxDamage,
                AttackSpeed = this.AttackSpeed,
                CellToMove = this.CellToMove,
                CollisionRect = this.CollisionRect,
                CriticalRate = this.CriticalRate,
                Defense = this.Defense,
                DestPoint = this.DestPoint,
                Dir = this.Dir,
                Height = this.Height,
                Hp = this.Hp,
                IsAttacking = this.IsAttacking,
                IsMouseHover = this.IsMouseHover,
                IsMoving = this.IsMoving,
                Map = this.Map,
                Mp = this.Mp,
                Range = this.Range,
                Rect = this.Rect,
                Speed = this.Speed,
                Width = this.Width,
                X = this.X,
                Xp = this.Xp,
                Y = this.Y,
                HitFrame = this.HitFrame,
                CastFrame = this.CastFrame,
                MaxHp = this.MaxHp,
                MaxMp = this.MaxMp,
                
            };
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            base.Draw(gameTime, sb);
            if (LeftHandSkill != null)
                LeftHandSkill.Draw(gameTime, sb);
            if (RightHandSkill != null)
                RightHandSkill.Draw(gameTime, sb);
        }

        float targetSkillX = 0;

        public float TargetSkillX
        {
            get { return targetSkillX; }
            set { targetSkillX = value; }
        }

        float targetSkillY = 0;

        public float TargetSkillY
        {
            get { return targetSkillY; }
            set { targetSkillY = value; }
        }

        bool waitToCast = false;

        public override void Update(GameTime gameTime)
        {
           
            base.Update(gameTime);

            if (RightHandSkill != null)
                RightHandSkill.IsEffected = false;
            if (LeftHandSkill != null)
                LeftHandSkill.IsEffected = false;

            if (IsAttacking)
            {
                if (_sprite[Dir].Itexture2D == HitFrame && _sprite[Dir].Check == 0)
                    this.Hit();
                if (_sprite[Dir].Itexture2D == 0)
                {
                    Random r = new Random();
                    int rate = r.Next(0, 100);
                    if (rate < this.CriticalRate || LeftHandSkill != null)
                        State = 16;
                    else
                        State = 24;
                    UpdateDirection(this.X, this.Y);
                }
            }
            if (IsMoving)
            {   
                if (this.Y == DestPoint.Y && this.X < DestPoint.X)
                {
                    if (this.X > GlobalVariables.ScreenWidth / 2 && GlobalVariables.dX > GlobalVariables.ScreenWidth - Map.Width)
                        GlobalVariables.dX -= Speed;
                }
                else
                    if (this.Y > DestPoint.Y && this.X < DestPoint.X)
                    {
                        if (this.X > GlobalVariables.ScreenWidth / 2 && GlobalVariables.dX > GlobalVariables.ScreenWidth - Map.Width)
                            GlobalVariables.dX -= (float)(Speed / Math.Sqrt(2));
                        if (GlobalVariables.dY < 0 && this.Y < Map.Height - GlobalVariables.ScreenHeight / 2)
                            GlobalVariables.dY += (float)(Speed / Math.Sqrt(2));
                    }
                    else
                        if (this.Y > DestPoint.Y && this.X == DestPoint.X)
                        {
                            if (GlobalVariables.dY < 0 && this.Y < Map.Height - GlobalVariables.ScreenHeight / 2)
                                GlobalVariables.dY += Speed;
                        }
                        else
                            if (this.Y > DestPoint.Y && this.X > DestPoint.X)
                            {
                                if (GlobalVariables.dX < 0 && this.X < Map.Width - GlobalVariables.ScreenWidth / 2)
                                    GlobalVariables.dX += (float)(Speed / Math.Sqrt(2));
                                if (GlobalVariables.dY < 0 && this.Y < Map.Height - GlobalVariables.ScreenHeight / 2)
                                    GlobalVariables.dY += (float)(Speed / Math.Sqrt(2));
                            }
                            else
                                if (this.Y == DestPoint.Y && this.X > DestPoint.X)
                                {
                                    if (GlobalVariables.dX < 0 && this.X < Map.Width - GlobalVariables.ScreenWidth / 2)
                                        GlobalVariables.dX += Speed;
                                }
                                else
                                    if (this.Y < DestPoint.Y && this.X > DestPoint.X)
                                    {
                                        if (GlobalVariables.dX < 0 && this.X < Map.Width - GlobalVariables.ScreenWidth / 2)
                                            GlobalVariables.dX += (float)(Speed / Math.Sqrt(2));
                                        if (this.Y > GlobalVariables.ScreenHeight / 2 && GlobalVariables.dY > GlobalVariables.ScreenHeight - Map.Height)
                                            GlobalVariables.dY -= (float)(Speed / Math.Sqrt(2));
                                    }
                                    else
                                        if (this.Y < DestPoint.Y && this.X == DestPoint.X)
                                        {
                                            if (this.Y > GlobalVariables.ScreenHeight / 2 && GlobalVariables.dY > GlobalVariables.ScreenHeight - Map.Height)
                                                GlobalVariables.dY -= Speed;
                                        }
                                        else
                                            if (this.Y < DestPoint.Y && this.X < DestPoint.X)
                                            {
                                                if (this.X > GlobalVariables.ScreenWidth / 2 && GlobalVariables.dX > GlobalVariables.ScreenWidth - Map.Width)
                                                    GlobalVariables.dX -= (float)(Speed / Math.Sqrt(2));
                                                if (this.Y > GlobalVariables.ScreenHeight / 2 && GlobalVariables.dY > GlobalVariables.ScreenHeight - Map.Height)
                                                    GlobalVariables.dY -= (float)(Speed / Math.Sqrt(2));
                                            }
            }
            
           
            if (GlobalVariables.CurrentMouseState.RightButton == ButtonState.Pressed && GlobalVariables.CurrentMouseState.LeftButton == ButtonState.Released && !IsCasting)
            {
                IsCasting = true;
                waitToCast = true;
                Target = null;
                CellToMove = new List<Point>();
                DestPoint = new Point((int)this.X, (int)this.Y);
                UpdateCastingDirection(GlobalVariables.GameCursor.X, GlobalVariables.GameCursor.Y);
                targetSkillX = GlobalVariables.GameCursor.X;
                targetSkillY = GlobalVariables.GameCursor.Y;
            }
            
            if (48 <= Dir && Dir <= 55)
            {
                if (_sprite[Dir].Itexture2D == CastFrame)
                    CastSkill();
                if (_sprite[Dir].Itexture2D == _sprite[Dir].Ntexture2D - 1)
                {
                    _sprite[Dir].Itexture2D = 0;
                    IsStanding = true;
                }
            }
            
            if (Target != null && (Target.IsDying || Target.IsDyed) && !IsCasting)
            {
                Target = null;
                CellToMove = new List<Point>();
                DestPoint = new Point((int)this.X,(int)this.Y);
                _sprite[Dir].Itexture2D = 0;
                IsStanding = true;
            }

            if (GlobalVariables.CurrentMouseState.LeftButton == ButtonState.Pressed && !GlobalVariables.AlreadyUseLeftMouse)
            {
                if (GlobalVariables.CurrentMouseState.X < GlobalVariables.ScreenWidth && GlobalVariables.CurrentMouseState.Y < GlobalVariables.ScreenHeight && GlobalVariables.CurrentMouseState.X >= 0 && GlobalVariables.CurrentMouseState.Y >= 0)
                {
                    if (this.Target != null)
                    {
                        this.Target = null;
                        this.IsAttacking = false;
                        this.DestPoint = new Point((int)this.X, (int)this.Y);
                        this.CellToMove = new List<Point>();
                    }
                    Point newCell = Owner._map.PointToCell(new Point((int)GlobalVariables.GameCursor.X, (int)GlobalVariables.GameCursor.Y));
                    if (Owner._map.Matrix[newCell.Y][newCell.X] == true)
                        Owner._char.CellToMove = Utility.FindPath(Owner._map.Matrix, Owner._map.PointToCell(new Point((int)this.X, (int)this.Y)), newCell);
                    IsMoving = true;
                    GlobalVariables.AlreadyUseLeftMouse = true;
                }
            }

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Q))
                RightHandSkill = null;
            if (ks.IsKeyDown(Keys.W))
            {
                RightHandSkill = new CleavingAttackSkill();
                RightHandSkill.PlayerOwner = this;
            }
            if (ks.IsKeyDown(Keys.A))
                LeftHandSkill = null;
            if (ks.IsKeyDown(Keys.S))
            {
                LeftHandSkill = (CleavingAttackSkill)(((SkillManager)Owner._objectManagerArray[7]).CreateObject(0));
                LeftHandSkill.Level = 1;
                LeftHandSkill.PlayerOwner = this;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                LeftHandSkill = (CriticalAttackSkill)(((SkillManager)Owner._objectManagerArray[7]).CreateObject(1));
                LeftHandSkill.Level = 1;
                LeftHandSkill.PlayerOwner = this;
            }
        }

        public void UpdateCastingDirection(float x, float y)
        {
            float tX = X + GlobalVariables.MapCollisionDim / 2;
            float tY = Y + GlobalVariables.MapCollisionDim / 2;
            Vector2 _v1, _v2, _v3;
            _v1 = new Vector2(x - tX, y - tY);
            _v2 = new Vector2(1, 0);
            _v3 = _v1 * _v2;
            float _angle = MathHelper.ToDegrees((float)Math.Acos(_v3.Length() / (_v1.Length() * _v2.Length())));

            if (0 <= _angle && _angle < 22.5)
                if (x < tX)
                    Dir = 4;
                else
                    Dir = 0;
            if (22.5 <= _angle && _angle < 67.5)
            {
                if (x > tX && y < tY)
                    Dir = 1;
                if (x < tX && y < tY)
                    Dir = 3;
                if (x < tX && y > tY)
                    Dir = 5;
                if (x > tX && y > tY)
                    Dir = 7;
            }
            if (67.5 < _angle && _angle <= 90)
                if (y < tY)
                    Dir = 2;
                else
                    Dir = 6;
            Dir = Dir % 8;
            Dir += State;
        }

        private void CastSkill()
        {
            if (waitToCast && IsCasting)
            {
                if (RightHandSkill != null)
                {   
                    RightHandSkill.DoEffect(Target);

                    //SkillLevel skillLevel = RightHandSkill.ListLevel[RightHandSkill.Level];
                    //for (int i = 0; i < skillLevel.ListSkillInfo.Count; ++i)
                    //{
                    //    SkillInfo skillInfo = skillLevel.ListSkillInfo[i];
                    //    Projectile prjt = (Projectile)Owner._objectManagerArray[6].CreateObject(skillInfo.Type);
                    //    prjt.X = targetSkillX + skillInfo.X;
                    //    prjt.Y = targetSkillY + skillInfo.Y;
                    //    Owner._listProjectile.Add(prjt);
                    //    ProjectileInfo projectileInfo = prjt.ListLevel[prjt.Level];
                    //    this.Hp += projectileInfo.Hp;
                    //    this.Mp += projectileInfo.Mp;
                    //}
                }
                waitToCast = false;
            }
        }

        public override void Hit()
        {
            Random r = new Random();
            int Damage = r.Next(MinDamage, MaxDamage);
            if (State == 16)
            {
                if (LeftHandSkill != null)
                    LeftHandSkill.DoEffect(Target);
                else
                    Target.BeHit(Damage * 2);
            }
            else
                Target.BeHit(Damage);
        }
        
    }
}

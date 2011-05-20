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
        /// Đang dùng skill
        /// </summary>
        bool _isCasting;

        public virtual bool IsCasting
        {
            get { return _isCasting; }
            set 
            { 
                _isCasting = value;
                IsAttacking = false;
                IsMoving = false;
                IsStanding = false;
                IsDyed = false;
                IsDying = false;                
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
                State = 24;
                if (value == true)
                    _isCasting = false;
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
                State = 40;
                if (value == true)
                    _isCasting = false;
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
                State = 32;
                if (value == true)
                    _isCasting = false;
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
                State = 8;
                if (value == true)
                    _isCasting = false;
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
                State = 0;
                if (value == true)
                    _isCasting = false;
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
                Attack = this.Attack,
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
            if (IsAttacking)
            {
                if (_sprite[Dir].Itexture2D == HitFrame && _sprite[Dir].Check == 0)
                    this.Hit();
            }
            
            
        }
        float targetSkillX = 0;
        float targetSkillY = 0;
        bool throwProjectile = false;
        public override void Update(GameTime gameTime)
        {
           
            base.Update(gameTime);
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
            MouseState ms = Mouse.GetState();
           
            if (ms.RightButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released && !IsCasting)
            {
                IsCasting = true;
                throwProjectile = true;
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
                    ThrowProjectile();
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

            if (ms.LeftButton == ButtonState.Pressed && !GlobalVariables.AlreadyUseLeftMouse)
            {
                if (ms.X < GlobalVariables.ScreenWidth && ms.Y < GlobalVariables.ScreenHeight && ms.X >= 0 && ms.Y >= 0)
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
                    //GlobalVariables.AlreadyUseLeftMouse = true;
                }
            }
        }

        private void UpdateCastingDirection(float mX, float mY)
        {
            Vector2 _v1, _v2, _v3;
            _v1 = new Vector2(mX - X, mY - Y    );
            _v2 = new Vector2(1,0);
            _v3 = _v1 * _v2;
            float _angle = MathHelper.ToDegrees((float)Math.Acos(_v3.Length() / (_v1.Length() * _v2.Length())));

            if (0 <= _angle && _angle < 22.5)
                if (mX < X)
                    Dir = 4;
                else
                    Dir = 0;
            if (22.5 <= _angle && _angle < 67.5)
            {
                if (mX > X && mY < Y)
                    Dir = 1;
                if (mX < X && mY < Y)
                    Dir = 3;
                if (mX < X && mY > Y)
                    Dir = 5;
                if (mX > X && mY > Y)
                    Dir = 7;
            }

            if (67.5 < _angle && _angle <= 90)
                if (mY < Y)
                    Dir = 2;
                else
                    Dir = 6;

            Dir += State;
        }

        private void ThrowProjectile()
        {
            if (throwProjectile && IsCasting)
            {
                Projectile prjt = (Projectile)Owner._objectManagerArray[6].CreateObject(0);
                prjt.X = targetSkillX;
                prjt.Y = targetSkillY;
                Owner._listProjectile.Add(prjt);
                throwProjectile = false;
                
            }
        }
        
    }
}

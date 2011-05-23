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
    public class Monster : Character
    {   
        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();            
            return new Monster
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
                Y = this.Y,                
                HitFrame = this.HitFrame,
                Sight = this.Sight,
                MaxHp = this.MaxHp,
                MaxMp = this.MaxMp,
                ChangeToDodge = this.ChangeToDodge,
            };
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
                    State = 16;
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
                    State = 32;    
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
                    State = 24; 
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
                    State = 8;
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
                    State = 0;
            }
        }
        /// <summary>
        /// Danh sach cac skill da tac dung len quai vat, de tranh truong hop quai vat bi danh boi nhieu projectile cua cung 1 skill
        /// </summary>
        List<Skill> _effectedSkill = new List<Skill>();

        public List<Skill> EffectedSkill
        {
            get { return _effectedSkill; }
            set { _effectedSkill = value; }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsDying || IsDyed)
                return;

            if (Target != null && Math.Sqrt(Math.Pow(this.X - Target.X, 2) - Math.Pow(this.Y - Target.Y, 2)) > this.Sight)
                Target = null;

            if (Target != null && IsCollisionWith(Target))
            {
                CellToMove = new List<Point>();
                DestPoint = new Point((int)X, (int)Y);
                UpdateDirection(Target.X, Target.Y);
            }

            if (Target == null && CellToMove.Count == 0 && this.X == DestPoint.X && this.Y == DestPoint.Y)
            {
                Random r = new Random((int)DateTime.Now.Ticks);
                if (true)
                {
                    Point curentPosition = Map.PointToCell(new Point((int)X, (int)Y));
                    r = new Random((int)DateTime.Now.Ticks);
                    int nX = (int)r.Next((int)curentPosition.X - 3, (int)curentPosition.X + 3);
                    r = new Random((int)DateTime.Now.Ticks);
                    int nY = (int)r.Next((int)curentPosition.Y - 3, (int)curentPosition.Y + 3);
                    Point newPosition = new Point(nX, nY);
                    CellToMove = Utility.FindPath(Map.Matrix, curentPosition, newPosition);
                    IsMoving = true;
                }           
            }
            

            if (IsAttacking && Target != null)
            {
                if (_sprite[Dir].Itexture2D == HitFrame && _sprite[Dir].Check == 0)
                    this.Hit();
            }

            if (FocusRect.Contains((int)GlobalVariables.GameCursor.X, (int)GlobalVariables.GameCursor.Y))
            {   
                GlobalVariables.GameCursor.IsAttack = true;
                if (GlobalVariables.CurrentMouseState.LeftButton == ButtonState.Pressed && !GlobalVariables.AlreadyUseLeftMouse)
                {
                    Owner._char.Target = this;
                    GlobalVariables.AlreadyUseLeftMouse = true;
                }
            }
            
            for (int i = 0; i < Owner._listProjectile.Count; ++i)
            {
                if (Owner._listProjectile[i].IsCollisionWith(this) && Owner._listProjectile[i].HitFrames.Contains(Owner._listProjectile[i]._sprite[0].Itexture2D) && Owner._listProjectile[i]._sprite[0].Check == 0 && !this.EffectedSkill.Contains(Owner._listProjectile[i].SkillOwner))
                {
                    Random r = new Random((int)DateTime.Now.Ticks);
                    this.BeHit(r.Next(Owner._listProjectile[i].MinDamage, Owner._listProjectile[i].MaxDamage));
                    if (Owner._listProjectile[i].SkillOwner != null)
                        Owner._listProjectile[i].SkillOwner.DoAdditionalEffect(this);
                    this.EffectedSkill.Add(Owner._listProjectile[i].SkillOwner);
                }
                else
                    if (Owner._listProjectile[i]._sprite[0].Itexture2D == Owner._listProjectile[i]._sprite[0].Ntexture2D - 2)
                        this.EffectedSkill.Remove(Owner._listProjectile[i].SkillOwner);
            }

            if (Owner._char != null && Math.Sqrt(Math.Pow(this.X - Owner._char.X, 2) - Math.Pow(this.Y - Owner._char.Y, 2)) < this.Sight)
                this.Target = Owner._char;
            else
                this.Target = null;

            if (this.IsCollisionWith(Owner._char))
            {
                this.Target = Owner._char;
                this.CellToMove = new List<Point>();
                this.DestPoint = new Point((int)this.X, (int)this.Y);
                this.IsAttacking = true;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            base.Draw(gameTime, sb);
            
        }

    }
}

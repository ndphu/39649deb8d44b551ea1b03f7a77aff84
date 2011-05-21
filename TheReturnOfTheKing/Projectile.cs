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
    public class Projectile : VisibleGameEntity
    {
        /// <summary>
        /// Skill ma projectile nay thuoc ve
        /// </summary>
        Skill _skillOwner;

        public Skill SkillOwner
        {
            get { return _skillOwner; }
            set { _skillOwner = value; }
        }



        /// <summary>
        /// Cap do hien tai cua projectile, se duoc cap nhat khi skill tang len
        /// </summary>
        int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        
        /// <summary>
        /// Frame hinh gay sat thuong
        /// </summary>
        List<int> _hitFrames;

        public List<int> HitFrames
        {
            get { return _hitFrames; }
            set { _hitFrames = value; }
        }
        /// <summary>
        /// Mang de luu thong tin tung level cua skill
        /// </summary>
        List<ProjectileInfo> _listLevel;

        public List<ProjectileInfo> ListLevel
        {
            get { return _listLevel; }
            set { _listLevel = value; }
        }
                
        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();

            return new Projectile
            {
                _nsprite = this._nsprite,
                _sprite = _spriteTemp,
                Height = this.Height,
                IsMouseHover = this.IsMouseHover,
                Rect = this.Rect,
                Width = this.Width,
                X = this.X,
                Y = this.Y,
                StartObstacleX = this.StartObstacleX,
                StartObstacleY = this.StartObstacleY,
                ObstacleWidth = this.ObstacleWidth,
                ObstacleHeight = this.ObstacleHeight,
                Level = this.Level,
                ListLevel = this.ListLevel,
                HitFrames = this.HitFrames,
            };
        }

        public override float X
        {
            get
            {
                return base.X;
            }
            set
            {
                base.X = value;
                for (int i = 0; i < _nsprite; ++i)
                    _sprite[i].X = value;
                CollisionRect = new Rectangle((int)X + (int)GlobalVariables.MapCollisionDim * StartObstacleX, (int)Y - (int)GlobalVariables.MapCollisionDim * StartObstacleY, (int)GlobalVariables.MapCollisionDim * ObstacleWidth, (int)GlobalVariables.MapCollisionDim * ObstacleHeight);
            }
        }

        public override float Y
        {
            get
            {
                return base.Y;
            }
            set
            {
                base.Y = value;
                for (int i = 0; i < _nsprite; ++i)
                    _sprite[i].Y = value;
                CollisionRect = new Rectangle((int)X, (int)Y, (int)GlobalVariables.MapCollisionDim, (int)GlobalVariables.MapCollisionDim);
            }
        }

        public virtual void DoEffect(VisibleGameEntity _object)
        {
            _skillOwner.DoEffect(_object);
        }
    }
}

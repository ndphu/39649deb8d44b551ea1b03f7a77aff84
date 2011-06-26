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
        Character _characterOwner;

        public Character CharacterOwner
        {
            get { return _characterOwner; }
            set { _characterOwner = value; }
        }
        /// <summary>
        /// Skill ma projectile nay thuoc ve
        /// </summary>
        Skill _skillOwner;

        public Skill SkillOwner
        {
            get { return _skillOwner; }
            set { _skillOwner = value; }
        }
        int _minDamage;

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }

        int _maxDamage;

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        int _delayTime;

        public int DelayTime
        {
            get { return _delayTime; }
            set { _delayTime = value; }
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

        bool _isRemoveAfterEffect = true;

        public bool IsRemoveAfterEffect
        {
            get { return _isRemoveAfterEffect; }
            set { _isRemoveAfterEffect = value; }
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
                CollisionRect = new Rectangle((int)X + (int)GlobalVariables.MapCollisionDim * StartObstacleX, (int)Y + (int)GlobalVariables.MapCollisionDim * StartObstacleY, (int)GlobalVariables.MapCollisionDim * ObstacleWidth, (int)GlobalVariables.MapCollisionDim * ObstacleHeight);
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
                CollisionRect = new Rectangle((int)X + (int)GlobalVariables.MapCollisionDim * StartObstacleX, (int)Y + (int)GlobalVariables.MapCollisionDim * StartObstacleY, (int)GlobalVariables.MapCollisionDim * ObstacleWidth, (int)GlobalVariables.MapCollisionDim * ObstacleHeight);
            }
        }

        ProjectileController _projectileController;

        public ProjectileController ProjectileController
        {
            get { return _projectileController; }
            set { _projectileController = value; }
        }

        int _lifeTime;

        public int LifeTime
        {
            get { return _lifeTime; }
            set { _lifeTime = value; }
        }

        public virtual void DoEffect(VisibleGameEntity _object)
        {
            if (DelayTime == 0)
                _skillOwner.DoEffect(_object);
        }

        public override void Update(GameTime gameTime)
        {
            if (DelayTime > 0)
            {
                --DelayTime;
                return;
            }
            base.Update(gameTime);
            LifeTime -= 1;
            if (ProjectileController != null)
                ProjectileController.UpdatePosition(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (DelayTime == 0)
                base.Draw(gameTime, sb);
        }
    }
}

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
        int _dPL;

        public int DPL
        {
            get { return _dPL; }
            set { _dPL = value; }
        }

        int _dPS;

        public int DPS
        {
            get { return _dPS; }
            set { _dPS = value; }
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
                DPS = this.DPS,
                DPL = this.DPL,
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
    }
}

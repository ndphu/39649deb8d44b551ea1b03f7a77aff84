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
    public class MapObstacle : VisibleGameEntity
    {
        
        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();
            return new MapObstacle
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
                CollisionRect = new Rectangle((int)X, (int)Y, (int)GlobalVariables.MapCollisionDim, (int)GlobalVariables.MapCollisionDim);
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
        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            base.Draw(gameTime, sb);
        }
    }
}

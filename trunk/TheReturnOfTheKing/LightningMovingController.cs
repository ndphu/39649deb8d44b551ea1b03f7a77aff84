using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class LightningMovingController : ProjectileController
    {
        float _rad;

        public float Rad
        {
            get { return _rad; }
            set { _rad = value; }
        }

        float _a;

        public float A
        {
            get { return _a; }
            set { _a = value; }
        }

        float _b;

        public float B
        {
            get { return _b; }
            set { _b = value; }
        }

        float _maxA;

        public float MaxA
        {
            get { return _maxA; }
            set 
            { 
                _maxA = value;
                DA = MaxA / 100;
            }
        }

        float _maxB;

        public float MaxB
        {
            get { return _maxB; }
            set 
            { 
                _maxB = value;
                DB = MaxB / 100;
            }
        }
        float _dA = 1;

        public float DA
        {
            get { return _dA; }
            set { _dA = value; }
        }

        float _dB = 1;

        public float DB
        {
            get { return _dB; }
            set { _dB = value; }
        }

        

        public override void UpdatePosition(GameTime gameTime)
        {
            base.UpdatePosition(gameTime);
            if (Owner != null)
            {
                float x = A * (float)Math.Cos(Rad);
                float y = B * (float)Math.Sin(Rad);
                Owner.X = ((Projectile)Owner).SkillOwner.PlayerOwner.X + x;
                Owner.Y = ((Projectile)Owner).SkillOwner.PlayerOwner.Y + y;
                
                A += DA;
                B += DB;

                if (A >= MaxA)
                    DA = -DA;
                
                if (B >= MaxB)
                    DB = -DB;

                if (A == 0 || B == 0)
                    ((Projectile)Owner).LifeTime = 0;
            }
        }
    }
}

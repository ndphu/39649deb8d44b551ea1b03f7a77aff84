using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class InsectFlyingController : ProjectileController
    {
        float _dRad = 0.02f;

        public float DRad
        {
            get { return _dRad; }
            set { _dRad = value; }
        }

        float _rad = 0;

        public float Rad
        {
            get { return _rad; }
            set { _rad = value; }
        }

        int _a = 0;

        public int A
        {
            get { return _a; }
            set { _a = value; }
        }

        int _b = 0;

        public int B
        {
            get { return _b; }
            set { _b = value; }
        }

        int _rotateDirection = 1;

        public int RotateDirection
        {
            get { return _rotateDirection; }
            set { _rotateDirection = value; }
        }

        int _distanceDirection = 1;

        public int DistanceDirection
        {
            get { return _distanceDirection; }
            set { _distanceDirection = value; }
        }

        bool _rotatting = true;

        public bool Rotatting
        {
            get { return _rotatting; }
            set { _rotatting = value; }
        }

        bool _movingA;

        public bool MovingA
        {
            get { return _movingA; }
            set { _movingA = value; }
        }

        bool _movingB;

        public bool MovingB
        {
            get { return _movingB; }
            set { _movingB = value; }
        }

        int _dA = 1;

        public int DA
        {
            get { return _dA; }
            set { _dA = value; }
        }
        int _dB = 1;

        public int DB
        {
            get { return _dB; }
            set { _dB = value; }
        }

        int _maxA;

        public int MaxA
        {
            get { return _maxA; }
            set { _maxA = value; }
        }

        int _maxB;

        public int MaxB
        {
            get { return _maxB; }
            set { _maxB = value; }
        }

        float _centerX;

        public float CenterX
        {
            get { return _centerX; }
            set { _centerX = value; }
        }

        float _centerY;

        public float CenterY
        {
            get { return _centerY; }
            set { _centerY = value; }
        }

        public override void UpdatePosition(GameTime gameTime)
        {
            base.UpdatePosition(gameTime);
            if (Owner != null)
            {
                
                float x = A * (float)Math.Cos(Rad);
                float y = B * (float)Math.Sin(Rad);
                //Owner.X = ((Projectile)Owner).SkillOwner.PlayerOwner.X + x;
                //Owner.Y = ((Projectile)Owner).SkillOwner.PlayerOwner.Y + y;
                //Thread.Sleep(1);
                Owner.X = CenterX + x;
                Owner.Y = CenterY + y;
                if (GlobalVariables.GlobalRandom.Next(0, 10000) % 1530 == 0)
                    RotateDirection *= -1;
                //if (GlobalVariables.GlobalRandom.Next(0, 10000) % 1354 == 0)
                //    Rotatting = !Rotatting;
                if (Rotatting)
                {
                    Rad += RotateDirection * DRad;
                    if (Rad > 2 * MathHelper.Pi)
                        Rad = 0;
                    if (Rad < 0)
                        Rad = 2 * MathHelper.Pi;
                }
                if (GlobalVariables.GlobalRandom.Next(0, 10000) % 142 == 0)
                    MovingA = !MovingA;
                if (GlobalVariables.GlobalRandom.Next(0, 10000) % 132 == 0)
                    MovingB = !MovingB;
                if (GlobalVariables.GlobalRandom.Next(0, 10000) % 442 == 0)
                    DA = -DA;
                if (GlobalVariables.GlobalRandom.Next(0, 10000) % 423 == 0)
                    DB = -DB;    
                if (MovingA)
                {
                    if (A + DA < MaxA && A + DA >= 0)
                        A += DA;
                }
                if (MovingB)
                {
                    if (B + DB < MaxB && B + DB >= 0)
                        B += DB;
                }
                
            }
        }
    }
}

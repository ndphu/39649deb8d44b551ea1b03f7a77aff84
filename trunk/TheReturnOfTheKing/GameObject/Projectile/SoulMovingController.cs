using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheReturnOfTheKing
{
    public class SoulMovingController : ProjectileController
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
                //DA = MaxA / 100;
            }
        }

        float _maxB;

        public float MaxB
        {
            get { return _maxB; }
            set 
            { 
                _maxB = value;
                //DB = MaxB / 100;
            }
        }
        float _dA = 15f;

        public float DA
        {
            get { return _dA; }
            set { _dA = value; }
        }

        float _dB = 10f;

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

                A += _dA;
                B += _dB;
                DA -= 0.1875f;
                DB -= 0.125f;
                if (GlobalVariables.GlobalRandom.Next(0, 100) < 15)
                {
                    Projectile prjt = ((Projectile)((Projectile)Owner).SkillOwner.PlayerOwner.Owner._objectManagerArray[6].CreateObject(((Projectile)Owner).SkillOwner.ListLevel[((Projectile)Owner).SkillOwner.Level].ListSkillInfo[0].ProjectileType));
                    prjt.X = Owner.X;
                    prjt.Y = Owner.Y;
                    prjt.SkillOwner = ((Projectile)Owner).SkillOwner;
                    prjt.MaxDamage = ((Projectile)Owner).MaxDamage;
                    prjt.MinDamage = ((Projectile)Owner).MinDamage;
                    ((Projectile)Owner).SkillOwner.PlayerOwner.Owner._listProjectile.Add(prjt);
                }
                if (A >= MaxA)
                    A = MaxA;
                if (B >= MaxB)
                    B = MaxB;

                if (A <= 0 || B <= 0)
                    ((Projectile)Owner).LifeTime = 0;
            }
        }
    }
}

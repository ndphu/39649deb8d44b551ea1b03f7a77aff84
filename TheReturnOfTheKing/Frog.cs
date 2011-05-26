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
    public class Frog : Misc
    {
        SpriteFont sf;

        PlayerCharacter _character;

        public PlayerCharacter Character
        {
            get { return _character; }
            set { _character = value; }
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
            }
        }


        Texture2D _normalAttackLeft;
        Texture2D _normalAttackRight;
        public override void Init(ContentManager content)
        {
            /*_nsprite = 1;
            _sprite = new GameSprite[_nsprite];
            _sprite[0] = new GameSprite(content.Load<Texture2D>("img/misc/frog/frog"), 0, 0);
            _normalAttackLeft = content.Load<Texture2D>("img/skillicon/medium/normal_attack");
            _normalAttackRight = content.Load<Texture2D>("img/skillicon/medium/normal_attack");
            sf = content.Load<SpriteFont>("sf");
            GlobalVariables.Sf = sf;*/
        }

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
        }

        public override void Update(GameTime gameTime)
        {
            //base.Update(gameTime);
            //X = _character.X - GlobalVariables.ScreenWidth;
            //Y = _character.Y - GlobalVariables.ScreenHeight;
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            //base.Draw(gameTime, sb);
            //sb.Draw(_sprite[0].Texture2D[0], new Vector2(X + GlobalVariables.dX, Y + GlobalVariables.dY), Color.White);
            
            /*sb.DrawString(sf, "HP: " + _character.Hp.ToString(), new Vector2(0, 20), Color.Red);
            sb.DrawString(sf, "MP: " + _character.Mp.ToString(), new Vector2(0, 45), Color.Blue);
            sb.DrawString(sf, "XP: " + _character.Xp.ToString(), new Vector2(0, 70), Color.White);
            if (_character.LeftHandSkill != null && _character.LeftHandSkill.SkillIconM != null)
                sb.Draw(_character.LeftHandSkill.SkillIconM, new Vector2(116, GlobalVariables.ScreenHeight - 105 + 58), Color.White);
            else
                sb.Draw(_normalAttackLeft, new Vector2(116, GlobalVariables.ScreenHeight - 105 + 58), Color.White);
            if (_character.RightHandSkill != null && _character.RightHandSkill.SkillIconM != null)
                sb.Draw(_character.RightHandSkill.SkillIconM, new Vector2(638, GlobalVariables.ScreenHeight - 105 + 58), Color.White);
            else
                sb.Draw(_normalAttackRight, new Vector2(638, GlobalVariables.ScreenHeight - 105 + 58), Color.White);
            if (_character.Target != null)
            {
                sb.DrawString(sf, "HP: " + _character.Target.Hp.ToString(), new Vector2(700, 20), Color.Red);
                sb.DrawString(sf, "MP: " + _character.Target.Mp.ToString(), new Vector2(700, 45), Color.Blue);
                //sb.DrawString(sf, "XP: " + _character.Target.Xp.ToString(), new Vector2(750, 70), Color.White);
            }*/
        }
    }
}

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
    public class HealthBar : Dialog
    {
        PlayerCharacter _character;

        public PlayerCharacter Character
        {
            get { return _character; }
            set { _character = value; }
        }

        GameFrame _healbarFrame;

        public GameFrame HealbarFrame
        {
            get { return _healbarFrame; }
            set { _healbarFrame = value; }
        }

        ProcessBar _bloodPro;

        public ProcessBar BloodPro
        {
            get { return _bloodPro; }
            set { _bloodPro = value; }
        }

        ProcessBar _manaPro;

        public ProcessBar ManaPro
        {
            get { return _manaPro; }
            set { _manaPro = value; }
        }

        SkillBoard _skillBoard;

        public SkillBoard SkillBoard
        {
            get { return _skillBoard; }
            set { _skillBoard = value; }
        }

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
        }

        public void GetResources (List<GameObjectManager> _resouces)
        {
            HealbarFrame = (GameFrame)_resouces[0].CreateObject(0);
            BloodPro = (ProcessBar)_resouces[1].CreateObject(0);
            ManaPro = (ProcessBar)_resouces[1].CreateObject(1);

            Button _leftCommand = (Button)_resouces[2].CreateObject(0);
            _leftCommand.Mouse_Click += new Button.OnMouseClickHandler(LeftCommandButon_Clicked);
            HealbarFrame.AddChild(_leftCommand);

            Button _rightCommand = (Button)_resouces[2].CreateObject(1);
            _rightCommand.Mouse_Click += new Button.OnMouseClickHandler(RightCommandButon_Clicked);
            HealbarFrame.AddChild(_rightCommand);

            _rect = new Rectangle((int)_healbarFrame.X, (int)_healbarFrame.Y, (int)_healbarFrame.Width, (int)_healbarFrame.Height);
        }

        public override void Update(GameTime gameTime)
        {
            _healbarFrame.Update(gameTime);
            float _bloodRate = (float)_character.Hp / (float)_character.MaxHp;
            _bloodPro.UpdateDrawRect(_bloodRate);
            float _manaRate = (float)_character.Mp / (float)_character.MaxMp;
            _manaPro.UpdateDrawRect(_manaRate);

            _rect = new Rectangle((int)_healbarFrame.X, (int)_healbarFrame.Y, (int)_healbarFrame.Width, (int)_healbarFrame.Height);
            if (_rect.Contains (GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y))
            {
                GlobalVariables.AlreadyUseLeftMouse = true;
                //GlobalVariables.AlreadyUseRightMouse = true;
            }

            //Update chỗ này chỉ để chặn con chuột -> khá dỡ.
            _bloodPro.Update(gameTime);
            _manaPro.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _healbarFrame.Draw(gameTime, sb);
            _bloodPro.Draw(gameTime, sb);
            _manaPro.Draw(gameTime, sb);
        }

//---Su kien cho Left Command Button---
        public void LeftCommandButon_Clicked(object sender, EventArgs e)
        {
            if (_skillBoard.BoardFrame.IsVisible)
            {
                _skillBoard.CreateMotion_GoOut();
                _skillBoard.BoardFrame.Motion = _skillBoard.MotionGoOut;
                _skillBoard.BoardFrame.Motion.IsStanding = false;
            }
            else
            {
                _skillBoard.CreateMotion_GoIn();
                _skillBoard.BoardFrame.Motion = _skillBoard.MotionGoIn;
                _skillBoard.BoardFrame.Motion.IsStanding = false;
            }
        }
//---Su kien cho Right Command Button---
        public void RightCommandButon_Clicked(object sender, EventArgs e)
        {
            
        }     
    }
}

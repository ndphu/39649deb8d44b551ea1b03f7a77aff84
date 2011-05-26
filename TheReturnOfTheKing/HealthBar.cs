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
            _leftCommand.Mouse_Down += new Button.OnMouseDownHandler(LeftCommandButon_Down);
            _leftCommand.Mouse_Released += new Button.OnMouseReleasedHandler(LeftCommandButon_Released);
            HealbarFrame.AddChild(_leftCommand);

            Button _rightCommand = (Button)_resouces[2].CreateObject(1);
            _rightCommand.Mouse_Click += new Button.OnMouseClickHandler(RightCommandButon_Clicked);
            _rightCommand.Mouse_Down += new Button.OnMouseDownHandler(RightCommandButon_Down);
            _rightCommand.Mouse_Released += new Button.OnMouseReleasedHandler(RightCommandButon_Released);
            HealbarFrame.AddChild(_rightCommand);
        }

        public override void Update(GameTime gameTime)
        {
            _healbarFrame.Update(gameTime);
            float _bloodRate = (float)_character.Hp / (float)_character.MaxHp;
            _bloodPro.UpdateDrawRect(_bloodRate);
            float _manaRate = (float)_character.Mp / (float)_character.MaxMp;
            _manaPro.UpdateDrawRect(_manaRate);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _healbarFrame.Draw(gameTime, sb);
            _bloodPro.Draw(gameTime, sb);
            _manaPro.Draw(gameTime, sb);
        }

//---Su kien cho Left Command Button---
        public void LeftCommandButon_Down (object sender, EventArgs e)
        {
            Button_MouseDownEffect((Button)sender);
        }

        public void LeftCommandButon_Clicked(object sender, EventArgs e)
        {
            Button_MouseClickedEffect((Button)sender);
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

        public void LeftCommandButon_Released(object sender, EventArgs e)
        {
            Button_MouseReleasedEffect((Button)sender);
        }
//---Su kien cho Right Command Button---
        public void RightCommandButon_Down(object sender, EventArgs e)
        {
            Button_MouseDownEffect((Button)sender);
        }

        public void RightCommandButon_Clicked(object sender, EventArgs e)
        {
            Button_MouseClickedEffect((Button)sender);
        }

        public void RightCommandButon_Released(object sender, EventArgs e)
        {
            Button_MouseReleasedEffect((Button)sender);
        }

//---Hàm dùng chung---
        void Button_MouseDownEffect(Button _button)
        {
            _button._sprite[0].Itexture2D = 1;
        }

        void Button_MouseClickedEffect(Button _button)
        {
            _button._sprite[0].Itexture2D = 0;
        }

        void Button_MouseReleasedEffect(Button _button)
        {
            _button._sprite[0].Itexture2D = 0;
        }
    }
}

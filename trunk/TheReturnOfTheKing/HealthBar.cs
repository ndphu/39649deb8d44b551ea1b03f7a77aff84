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

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
            _char.Healthbar = this;
        }

        public void GetResources(List<GameObjectManager> _resouces)
        {
            HealbarFrame = (GameFrame)_resouces[0].CreateObject(0);
            BloodPro = (ProcessBar)_resouces[1].CreateObject(0);
            ManaPro = (ProcessBar)_resouces[1].CreateObject(1);

            Button _btLeftCommand = (Button)_resouces[2].CreateObject(0);
            _btLeftCommand.Mouse_Click += new Button.OnMouseClickHandler(LeftCommandButon_Clicked);
            HealbarFrame.AddChild(_btLeftCommand);

            Button _btRightCommand = (Button)_resouces[2].CreateObject(1);
            _btRightCommand.Mouse_Click += new Button.OnMouseClickHandler(RightCommandButon_Clicked);
            HealbarFrame.AddChild(_btRightCommand);

            Button _btLefthandSkill = (Button)_resouces[2].CreateObject(14);
            _btLefthandSkill.Owner = _character.ListLeftHandSkill[0];
            _btLefthandSkill.GetNewIdleTexture(_character.ListLeftHandSkill[0].IdleIcon);
            _btLefthandSkill.GetNewClickedTexture(_character.ListLeftHandSkill[0].ClickedIcon);
            _btLefthandSkill.Mouse_Click += new Button.OnMouseClickHandler(LeftSkillButon_Clicked);
            _btLefthandSkill.Mouse_Hover += new Button.OnMouseHoverHandler(LeftSkillButon_Hover);
            _btLefthandSkill.Mouse_Released += new Button.OnMouseReleasedHandler(LeftSkillButon_Release);
            HealbarFrame.AddChild(_btLefthandSkill);

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
            if (_rect.Contains(GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y))
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

            switch (_character.Skillboard.ICurrentBoard)
            {
                case 0:
                    {
                        ((Skill)_character.Skillboard.BtSkillCleaving.Owner).Draw(gameTime, sb);
                        ((Skill)_character.Skillboard.BtSkillCritical.Owner).Draw(gameTime, sb);
                        ((Skill)_character.Skillboard.BtSkillCurse.Owner).Draw(gameTime, sb);
                        ((Skill)_character.Skillboard.BtSkillOverSpeed.Owner).Draw(gameTime, sb);
                        ((Skill)_character.Skillboard.BtSkillLifeSteal.Owner).Draw(gameTime, sb);
                        ((Skill)_character.Skillboard.BtSkillBash.Owner).Draw(gameTime, sb);
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        break;
                    }
            }
            //((Skill)((Button)_healbarFrame.Child[2]).Owner).Draw(gameTime, sb);
        }

//---Su kien cho Left Command Button---
        public void LeftCommandButon_Clicked(object sender, EventArgs e)
        {

        }
//---Su kien cho Right Command Button---
        public void RightCommandButon_Clicked(object sender, EventArgs e)
        {
            if (_character.Skillboard.BoardFrame.IsVisible)
            {
                _character.Skillboard.CreateMotion_GoOut();
                _character.Skillboard.BoardFrame.Motion = _character.Skillboard.MotionGoOut;
                _character.Skillboard.BoardFrame.Motion.IsStanding = false;
            }
            else
            {
                _character.Skillboard.CreateMotion_GoIn();
                _character.Skillboard.BoardFrame.Motion = _character.Skillboard.MotionGoIn;
                _character.Skillboard.BoardFrame.Motion.IsStanding = false;
            }
        }
//---Su kien cho Left Button Skill---
        public void LeftSkillButon_Clicked(object sender, EventArgs e)
        {
            if (_character.LhSkillSelectionFrame.MainFrame.IsVisible)
            {

            }
            else
            {
                _character.LhSkillSelectionFrame.CreateMotion_GoIn();
                _character.LhSkillSelectionFrame.MainFrame.Motion = _character.LhSkillSelectionFrame.MotionGoIn;
                _character.LhSkillSelectionFrame.MainFrame.Motion.IsStanding = false;
            }
        }

        public void LeftSkillButon_Hover(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void LeftSkillButon_Release(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }
//----Hàm dùng chung--------------
        public Vector2 GetSkillDetailLocation(Button _button, int _picWid, int _picHei)
        {
            Vector2 _result = new Vector2(_button.X + _button.Width, _button.Y - _picHei - 2);
            return _result;
        }

        public void ShowDetailSkill(Button _button)
        {
            ((Skill)_button.Owner).ToShowDetails = true;
            Vector2 _location = GetSkillDetailLocation(_button, ((Skill)_button.Owner).LargeIcon.Width, ((Skill)_button.Owner).LargeIcon.Height);
            ((Skill)_button.Owner).X = _location.X;
            ((Skill)_button.Owner).Y = _location.Y;
        }

        public void HideDetailSkill(Button _button)
        {
            ((Skill)_button.Owner).ToShowDetails = false;
        }
    }
}
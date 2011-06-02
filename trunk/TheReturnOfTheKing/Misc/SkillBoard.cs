﻿using System;
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
    public class SkillBoard : Dialog
    {
        PlayerCharacter _character;

        public PlayerCharacter Character
        {
            get { return _character; }
            set { _character = value; }
        }

        GameFrame _boardFrame;

        public GameFrame BoardFrame
        {
            get { return _boardFrame; }
            set { _boardFrame = value; }
        }

        GameFrame _currentBoard;

        public GameFrame CurrentBoard
        {
            get { return _currentBoard; }
            set { _currentBoard = value; }
        }

        int _iCurrentBoard;

        public int ICurrentBoard
        {
            get { return _iCurrentBoard; }
            set { _iCurrentBoard = value; }
        }

        MotionInfo _motionGoOut;

        public MotionInfo MotionGoOut
        {
            get { return _motionGoOut; }
            set { _motionGoOut = value; }
        }

        MotionInfo _motionGoIn;

        public MotionInfo MotionGoIn
        {
            get { return _motionGoIn; }
            set { _motionGoIn = value; }
        }

//Các control trên tab......
        #region Các button dùng chung trên tab control
        Button _btLeftSkillControl;
        public Button BtLeftSkillControl
        {
            get { return _btLeftSkillControl; }
            set { _btLeftSkillControl = value; }
        }

        Button _btRightSkillControl;
        public Button BtRightSkillControl
        {
            get { return _btRightSkillControl; }
            set { _btRightSkillControl = value; }
        }

        Button _btPassiveSkillControl;
        public Button BtPassiveSkillControl
        {
            get { return _btPassiveSkillControl; }
            set { _btPassiveSkillControl = value; }
        }
        #endregion
   //Left
        Button _btLefthandExit;
        public Button BtLefthandExit
        {
            get { return _btLefthandExit; }
            set { _btLefthandExit = value; }
        }

        Button _btSkillCleaving;
        public Button BtSkillCleaving
        {
            get { return _btSkillCleaving; }
            set { _btSkillCleaving = value; }
        }

        Button _btSkillCritical;
        public Button BtSkillCritical
        {
            get { return _btSkillCritical; }
            set { _btSkillCritical = value; }
        }

        Button _btSkillCurse;
        public Button BtSkillCurse
        {
            get { return _btSkillCurse; }
            set { _btSkillCurse = value; }
        }

        Button _btSkillOverSpeed;
        public Button BtSkillOverSpeed
        {
            get { return _btSkillOverSpeed; }
            set { _btSkillOverSpeed = value; }
        }

        Button _btSkillLifeSteal;
        public Button BtSkillLifeSteal
        {
            get { return _btSkillLifeSteal; }
            set { _btSkillLifeSteal = value; }
        }

        Button _btSkillBash;
        public Button BtSkillBash
        {
            get { return _btSkillBash; }
            set { _btSkillBash = value; }
        }

        Label _lbSkillCleaving;
        public Label LbSkillCleaving
        {
            get { return _lbSkillCleaving; }
            set { _lbSkillCleaving = value; }
        }

        Label _lbSkillCritical;
        public Label LbSkillCritical
        {
            get { return _lbSkillCritical; }
            set { _lbSkillCritical = value; }
        }

        Label _lbSkillCurse;
        public Label LbSkillCurse
        {
            get { return _lbSkillCurse; }
            set { _lbSkillCurse = value; }
        }

        Label _lbSkillOverspeed;
        public Label LbSkillOverspeed
        {
            get { return _lbSkillOverspeed; }
            set { _lbSkillOverspeed = value; }
        }

        Label _lbSkillLifeSteal;
        public Label LbSkillLifeSteal
        {
            get { return _lbSkillLifeSteal; }
            set { _lbSkillLifeSteal = value; }
        }

        Label _lbSkillBash;
        public Label LbSkillBash
        {
            get { return _lbSkillBash; }
            set { _lbSkillBash = value; }
        }

        GameFrame _lefthandFrame;
        public GameFrame LefthandFrame
        {
            get { return _lefthandFrame; }
            set { _lefthandFrame = value; }
        }
   //Right
        Button _btRighthandExit;
        public Button BtRighthandExit
        {
            get { return _btRighthandExit; }
            set { _btRighthandExit = value; }
        }

        GameFrame _rightthandFrame;
        public GameFrame RightthandFrame
        {
            get { return _rightthandFrame; }
            set { _rightthandFrame = value; }
        }
   //Passive
        Button _btPassiveExit;
        public Button BtPassiveExit
        {
            get { return _btPassiveExit; }
            set { _btPassiveExit = value; }
        }

        GameFrame _passiveFrame;
        public GameFrame PassiveFrame
        {
            get { return _passiveFrame; }
            set { _passiveFrame = value; }
        }

//---------------------------------------------------------------------------------------------------
        public void GetResources(List<GameObjectManager> _resources)
        {
            _boardFrame = (GameFrame)_resources[0].CreateObject(1);
            _boardFrame.IsVisible = false;

            //Press Button sử dụng chung trên 3 tab.
            _btLeftSkillControl = (Button)_resources[1].CreateObject(2);
            _btLeftSkillControl._sprite[0].Itexture2D = 1; //Được click trước tiên
            _btLeftSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_LeftButtonControl);
            _btLeftSkillControl.IsPressButton = true;

            _btRightSkillControl = (Button)_resources[1].CreateObject(3);
            _btRightSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_RightButtonControl);
            _btRightSkillControl.IsPressButton = true;

            _btPassiveSkillControl = (Button)_resources[1].CreateObject(4);
            _btPassiveSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_PassiveButtonControl);
            _btPassiveSkillControl.IsPressButton = true;

 //LeftHand tab
            _btLefthandExit = (Button)_resources[1].CreateObject(11);
            _btLefthandExit.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_LeftExit);
            //Cleaving
            _btSkillCleaving = (Button)_resources[1].CreateObject(5);
            _btSkillCleaving.Owner = _character.ListLeftHandSkill[1];
            _btSkillCleaving.GetNewIdleTexture(_character.ListLeftHandSkill[1].IdleIcon);
            _btSkillCleaving.GetNewClickedTexture(_character.ListLeftHandSkill[1].ClickedIcon);
            _btSkillCleaving.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_CleavingAttack);
            _btSkillCleaving.Mouse_Hover += new Button.OnMouseHoverHandler(SkillBoard_MouseHover_CleavingAttack);
            _btSkillCleaving.Mouse_Released += new Button.OnMouseReleasedHandler(SkillBoard_MouseRelease_CleavingAttack);
            
            _lbSkillCleaving = (Label)_resources[2].CreateObject(0);
            _lbSkillCleaving.Owner = _character.ListLeftHandSkill[1];
            //Critical
            _btSkillCritical = (Button)_resources[1].CreateObject(6);
            _btSkillCritical.Owner = _character.ListLeftHandSkill[2];
            _btSkillCritical.GetNewIdleTexture(_character.ListLeftHandSkill[2].IdleIcon);
            _btSkillCritical.GetNewClickedTexture(_character.ListLeftHandSkill[2].ClickedIcon);
            _btSkillCritical.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_CriticalAttack);
            _btSkillCritical.Mouse_Hover += new Button.OnMouseHoverHandler(SkillBoard_MouseHover_CriticalAttack);
            _btSkillCritical.Mouse_Released += new Button.OnMouseReleasedHandler(SkillBoard_MouseRelease_CriticalAttack);

            _lbSkillCritical = (Label)_resources[2].CreateObject(1);
            _lbSkillCritical.Owner = _character.ListLeftHandSkill[2];
            //Curse
            _btSkillCurse = (Button)_resources[1].CreateObject(7);
            _btSkillCurse.Owner = _character.ListLeftHandSkill[3];
            _btSkillCurse.GetNewIdleTexture(_character.ListLeftHandSkill[3].IdleIcon);
            _btSkillCurse.GetNewClickedTexture(_character.ListLeftHandSkill[3].ClickedIcon);
            _btSkillCurse.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_CurseAttack);
            _btSkillCurse.Mouse_Hover += new Button.OnMouseHoverHandler(SkillBoard_MouseHover_CurseAttack);
            _btSkillCurse.Mouse_Released += new Button.OnMouseReleasedHandler(SkillBoard_MouseRelease_CurseAttack);

            _lbSkillCurse = (Label)_resources[2].CreateObject(2);
            _lbSkillCurse.Owner = _character.ListLeftHandSkill[3];
            //Overspeed
            _btSkillOverSpeed = (Button)_resources[1].CreateObject(8);
            _btSkillOverSpeed.Owner = _character.ListLeftHandSkill[4];
            _btSkillOverSpeed.GetNewIdleTexture(_character.ListLeftHandSkill[4].IdleIcon);
            _btSkillOverSpeed.GetNewClickedTexture(_character.ListLeftHandSkill[4].ClickedIcon);
            _btSkillOverSpeed.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_OverSpeedAttack);
            _btSkillOverSpeed.Mouse_Hover += new Button.OnMouseHoverHandler(SkillBoard_MouseHover_OverSpeedAttack);
            _btSkillOverSpeed.Mouse_Released += new Button.OnMouseReleasedHandler(SkillBoard_MouseRelease_OverSpeedAttack);

            _lbSkillOverspeed = (Label)_resources[2].CreateObject(3);
            _lbSkillOverspeed.Owner = _character.ListLeftHandSkill[4];
            //Lifesteal
            _btSkillLifeSteal = (Button)_resources[1].CreateObject(9);
            _btSkillLifeSteal.Owner = _character.ListLeftHandSkill[5];
            _btSkillLifeSteal.GetNewIdleTexture(_character.ListLeftHandSkill[5].IdleIcon);
            _btSkillLifeSteal.GetNewClickedTexture(_character.ListLeftHandSkill[5].ClickedIcon);
            _btSkillLifeSteal.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_LifeStealAttack);
            _btSkillLifeSteal.Mouse_Hover += new Button.OnMouseHoverHandler(SkillBoard_MouseHover_LifeStealAttack);
            _btSkillLifeSteal.Mouse_Released += new Button.OnMouseReleasedHandler(SkillBoard_MouseRelease_LifeStealAttack);

            _lbSkillLifeSteal = (Label)_resources[2].CreateObject(4);
            _lbSkillLifeSteal.Owner = _character.ListLeftHandSkill[5];
            //Bash
            _btSkillBash = (Button)_resources[1].CreateObject(10);
            _btSkillBash.Owner = _character.ListLeftHandSkill[6];
            _btSkillBash.GetNewIdleTexture(_character.ListLeftHandSkill[6].IdleIcon);
            _btSkillBash.GetNewClickedTexture(_character.ListLeftHandSkill[6].ClickedIcon);
            _btSkillBash.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_BashAttack);
            _btSkillBash.Mouse_Hover += new Button.OnMouseHoverHandler(SkillBoard_MouseHover_BashAttack);
            _btSkillBash.Mouse_Released += new Button.OnMouseReleasedHandler(SkillBoard_MouseRelease_BashAttack);

            _lbSkillBash = (Label)_resources[2].CreateObject(5);
            _lbSkillBash.Owner = _character.ListLeftHandSkill[6];

            _lefthandFrame = (GameFrame)_resources[0].CreateObject(2);

            //4 vị trí đầu là các control trên tab
            _lefthandFrame.AddChild(_btLeftSkillControl);
            _lefthandFrame.AddChild(_btRightSkillControl);
            _lefthandFrame.AddChild(_btPassiveSkillControl);
            _lefthandFrame.AddChild(_btLefthandExit);
            //Các vị trí còn lại là các button Skill
            _lefthandFrame.AddChild(_btSkillCleaving);
            _lefthandFrame.AddChild(_lbSkillCleaving);

            _lefthandFrame.AddChild(_btSkillCritical);
            _lefthandFrame.AddChild(_lbSkillCritical);

            _lefthandFrame.AddChild(_btSkillCurse);
            _lefthandFrame.AddChild(_lbSkillCurse);

            _lefthandFrame.AddChild(_btSkillOverSpeed);
            _lefthandFrame.AddChild(_lbSkillOverspeed);

            _lefthandFrame.AddChild(_btSkillLifeSteal);
            _lefthandFrame.AddChild(_lbSkillLifeSteal);

            _lefthandFrame.AddChild(_btSkillBash);
            _lefthandFrame.AddChild(_lbSkillBash);

            //Add vào tab control (Frame mẹ)
            _boardFrame.AddChild(_lefthandFrame);

//RightHand tab
            _btRighthandExit = (Button)_resources[1].CreateObject(12);
            _btRighthandExit.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_RightExit);

            _rightthandFrame = (GameFrame)_resources[0].CreateObject(3);
            _rightthandFrame.AddChild(_btLeftSkillControl);
            _rightthandFrame.AddChild(_btRightSkillControl);
            _rightthandFrame.AddChild(_btPassiveSkillControl);
            _rightthandFrame.AddChild(_btRighthandExit);
            _boardFrame.AddChild(_rightthandFrame);

            //Passive tab
            _btPassiveExit = (Button)_resources[1].CreateObject(13);
            _btPassiveExit.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_PassiveExit);

            _passiveFrame = (GameFrame)_resources[0].CreateObject(4);
            _passiveFrame.AddChild(_btLeftSkillControl);
            _passiveFrame.AddChild(_btRightSkillControl);
            _passiveFrame.AddChild(_btPassiveSkillControl);
            _passiveFrame.AddChild(_btPassiveExit);
            _boardFrame.AddChild(_passiveFrame);

            _iCurrentBoard = 0;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
            _rect = new Rectangle((int)_boardFrame.X, (int)_boardFrame.Y, (int)_boardFrame.Width, (int)_boardFrame.Height);
        }

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
            _char.Skillboard = this;
        }

        public override void Update(GameTime gameTime)
        {
            if (_boardFrame.Motion != null)
            {
                if (!_boardFrame.Motion.IsStanding)
                {
                    _boardFrame.IsVisible = true;
                    _boardFrame.Motion.Move(new Vector2(_boardFrame.X, _boardFrame.Y));
                    if (_boardFrame.Motion.IsStanding)
                    {
                        Rectangle _testVisible = new Rectangle(0, 0, GlobalVariables.ScreenWidth, GlobalVariables.ScreenHeight);
                        Point _point1 = new Point((int)_boardFrame.X, (int)_boardFrame.Y);
                        Point _point2 = new Point((int)_boardFrame.X + (int)_boardFrame.Width, (int)_boardFrame.Y);
                        Point _point3 = new Point((int)_boardFrame.X, (int)_boardFrame.Y + (int)_boardFrame.Height);
                        Point _point4 = new Point((int)_boardFrame.X + (int)_boardFrame.Width, (int)_boardFrame.Y + (int)_boardFrame.Height);
                        if (_testVisible.Contains(_point1) || _testVisible.Contains(_point2) || _testVisible.Contains(_point3) || _testVisible.Contains(_point4))
                            _boardFrame.IsVisible = true;
                        else
                            _boardFrame.IsVisible = false;
                        _boardFrame.OnMove_Complete(this, null);
                    }
                }
            }

            _currentBoard.Update(gameTime);

            //Update thong tin cac label
            switch (_iCurrentBoard)
            {
                case 0:
                    {
                        GetSkillLevel(_lbSkillCleaving);
                        GetSkillLevel(_lbSkillCritical);
                        GetSkillLevel(_lbSkillCurse);
                        GetSkillLevel(_lbSkillOverspeed);
                        GetSkillLevel(_lbSkillLifeSteal);
                        GetSkillLevel(_lbSkillBash);
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

            _rect = new Rectangle((int)_boardFrame.X, (int)_boardFrame.Y, (int)_boardFrame.Width, (int)_boardFrame.Height);
            if (_rect.Contains(GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y))
            {
                GlobalVariables.AlreadyUseLeftMouse = true;
                GlobalVariables.AlreadyUseRightMouse = true;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (_boardFrame.IsVisible)
            {
                _currentBoard.Draw(gameTime, sb);
                sb.Draw(_boardFrame._sprite[0].Texture2D[0], new Vector2(_boardFrame.X, _boardFrame.Y), Color.White);
            }
        }

        public void CreateMotion_GoIn()
        {
            _motionGoIn = new MotionInfo();
            _motionGoIn.FirstDection = "Left";
            _motionGoIn.IsStanding = true;
            _motionGoIn.StandingGround = 400;
            _motionGoIn.Vel = new Vector2(31, 0);
            _motionGoIn.Accel = new Vector2(1.055f, 0);
            _motionGoIn.DecelerationRate = 0.6f;
        }

        public void CreateMotion_GoOut()
        {
            _motionGoOut = new MotionInfo();
            _motionGoOut.FirstDection = "Left";
            _motionGoOut.IsStanding = true;
            _motionGoOut.StandingGround = float.MinValue;
            _motionGoOut.Vel = new Vector2(0, 0);
            _motionGoOut.Accel = new Vector2(1.8f, 0);
            _motionGoOut.DecelerationRate = 0.6f;
        }

//--------------Su kien cho Button trên tab Lefthand----------------------------------------------------------------------------
        #region Su kien cho Button trên tab Lefthand
        public void SkillBoard_MouseDown_LeftButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 0)
                return;
            _btRightSkillControl._sprite[0].Itexture2D = 0;
            _btPassiveSkillControl._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 0;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }

        public void SkillBoard_MouseClick_LeftExit(object sender, EventArgs e)
        {
            CreateMotion_GoOut();
            BoardFrame.Motion = MotionGoOut;
            BoardFrame.Motion.IsStanding = false;
        }

        #region CleavingAttack Skill
        public void SkillBoard_MouseClick_CleavingAttack(object sender, EventArgs e)
        {
            LevelUp((Button)sender);
        }

        public void SkillBoard_MouseHover_CleavingAttack(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillBoard_MouseRelease_CleavingAttack(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }
        #endregion

        #region CriticalAttack Skill
        public void SkillBoard_MouseClick_CriticalAttack(object sender, EventArgs e)
        {
            LevelUp((Button)sender);
        }

        public void SkillBoard_MouseHover_CriticalAttack(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillBoard_MouseRelease_CriticalAttack(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }
        #endregion

        #region CurseAttack Skill
        public void SkillBoard_MouseClick_CurseAttack(object sender, EventArgs e)
        {
            LevelUp((Button)sender);
        }

        public void SkillBoard_MouseHover_CurseAttack(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillBoard_MouseRelease_CurseAttack(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }
        #endregion

        #region OverSpeedAttack Skill
        public void SkillBoard_MouseClick_OverSpeedAttack(object sender, EventArgs e)
        {
            LevelUp((Button)sender);
        }

        public void SkillBoard_MouseHover_OverSpeedAttack(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillBoard_MouseRelease_OverSpeedAttack(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }
        #endregion

        #region LifeStealAttack Skill
        public void SkillBoard_MouseClick_LifeStealAttack(object sender, EventArgs e)
        {
            LevelUp((Button)sender);
        }

        public void SkillBoard_MouseHover_LifeStealAttack(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillBoard_MouseRelease_LifeStealAttack(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }
        #endregion

        #region BashAttack Skill
        public void SkillBoard_MouseClick_BashAttack(object sender, EventArgs e)
        {
            LevelUp((Button)sender);
        }

        public void SkillBoard_MouseHover_BashAttack(object sender, EventArgs e)
        {
            ShowDetailSkill((Button)sender);
        }

        public void SkillBoard_MouseRelease_BashAttack(object sender, EventArgs e)
        {
            HideDetailSkill((Button)sender);
        }
        #endregion
        #endregion

//----------------Su kien cho Button trên tab Rightthand--------------------------------------------------------------------------------

        #region Su kien cho Button trên tab Rightthand
        public void SkillBoard_MouseDown_RightButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 1)
                return;
            _btLeftSkillControl._sprite[0].Itexture2D = 0;
            _btPassiveSkillControl._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 1;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }

        public void SkillBoard_MouseClick_RightExit(object sender, EventArgs e)
        {
            CreateMotion_GoOut();
            BoardFrame.Motion = MotionGoOut;
            BoardFrame.Motion.IsStanding = false;
        }
        #endregion

//-----------------Su kien cho Button trên tab Passive------------------------------------------------------------------------------

        #region Su kien cho Button trên tab Passive
        public void SkillBoard_MouseDown_PassiveButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 2)
                return;
            _btLeftSkillControl._sprite[0].Itexture2D = 0;
            _btRightSkillControl._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 2;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }

        public void SkillBoard_MouseClick_PassiveExit(object sender, EventArgs e)
        {
            CreateMotion_GoOut();
            BoardFrame.Motion = MotionGoOut;
            BoardFrame.Motion.IsStanding = false;
        }
        #endregion

//Hàm dùng chung-----------------------------------------------------

        public Vector2 GetSkillDetailLocation(Button _button, int _picWid, int _picHei)
        {
            Vector2 _result = new Vector2(_button.X + _button.Width, _button.Y + _button.Height);
            if (_result.X + _picWid > GlobalVariables.ScreenWidth)
            {
                int temp = (int)(_result.X + _picWid - GlobalVariables.ScreenWidth) + 5;
                _result.X -= temp;
            }
            if (_result.Y + _picHei > GlobalVariables.ScreenHeight)
            {
                int temp = (int)(_result.Y + _picHei - GlobalVariables.ScreenHeight) + 5;
                _result.Y -= temp;
            }
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

        public void LevelUp(Button _button)
        {
            if (((Skill)_button.Owner).Level < ((Skill)_button.Owner).ListLevel.Count - 1)
            {
                ((Skill)_button.Owner).Level++;
                if (((Skill)_button.Owner).Level == ((Skill)_button.Owner).ListLevel.Count - 1)
                    _button.Endalbe = false;
            }
        }

        public void GetSkillLevel (Label _label)
        {
            _label.StringInfo = ((Skill)_label.Owner).Level.ToString();
            if (((Skill)_label.Owner).Level == ((Skill)_label.Owner).ListLevel.Count - 1)
            {
                _label.StringColor = Color.Red;
            }
        }
    }
}
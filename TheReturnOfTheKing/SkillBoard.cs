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

        public void GetResources(List<GameObjectManager> _resources)
        {
            _boardFrame = (GameFrame)_resources[0].CreateObject(1);
            _boardFrame.IsVisible = false;

            //Press Button sử dụng chung trên 3 tab.
            Button _leftSkillControl = (Button)_resources[1].CreateObject(2);
            _leftSkillControl._sprite[0].Itexture2D = 1; //Được click trước tiên
            _leftSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_LeftButtonControl);
            _leftSkillControl.IsPressButton = true;

            Button _rightSkillControl = (Button)_resources[1].CreateObject(3);
            _rightSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_RightButtonControl);
            _rightSkillControl.IsPressButton = true;

            Button _passiveSkillControl = (Button)_resources[1].CreateObject(4);
            _passiveSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_PassiveButtonControl);
            _passiveSkillControl.IsPressButton = true;

            //LeftHand tab
            Button _btSkillCleaving = (Button)_resources[1].CreateObject(5);
            _btSkillCleaving.Owner = _character.ListLeftHandSkill[1];
            _btSkillCleaving.GetNewIdleTexture(_character.ListLeftHandSkill[1].IdleIcon);
            _btSkillCleaving.GetNewClickedTexture(_character.ListLeftHandSkill[1].ClickedIcon);
            _btSkillCleaving.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_CleavingAttack);

            Button _btSkillCritical = (Button)_resources[1].CreateObject(6);
            _btSkillCritical.Owner = _character.ListLeftHandSkill[2];
            _btSkillCritical.GetNewIdleTexture(_character.ListLeftHandSkill[2].IdleIcon);
            _btSkillCritical.GetNewClickedTexture(_character.ListLeftHandSkill[2].ClickedIcon);
            _btSkillCritical.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_CriticalAttack);

            Button _btSkillCurse = (Button)_resources[1].CreateObject(7);
            _btSkillCurse.Owner = _character.ListLeftHandSkill[3];
            _btSkillCurse.GetNewIdleTexture(_character.ListLeftHandSkill[3].IdleIcon);
            _btSkillCurse.GetNewClickedTexture(_character.ListLeftHandSkill[3].ClickedIcon);
            _btSkillCurse.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_CurseAttack);

            Button _btSkillOverSpeed = (Button)_resources[1].CreateObject(8);
            _btSkillOverSpeed.Owner = _character.ListLeftHandSkill[4];
            _btSkillOverSpeed.GetNewIdleTexture(_character.ListLeftHandSkill[4].IdleIcon);
            _btSkillOverSpeed.GetNewClickedTexture(_character.ListLeftHandSkill[4].ClickedIcon);
            _btSkillOverSpeed.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_OverSpeedAttack);

            Button _btSkillLifeSteal = (Button)_resources[1].CreateObject(9);
            _btSkillLifeSteal.Owner = _character.ListLeftHandSkill[5];
            _btSkillLifeSteal.GetNewIdleTexture(_character.ListLeftHandSkill[5].IdleIcon);
            _btSkillLifeSteal.GetNewClickedTexture(_character.ListLeftHandSkill[5].ClickedIcon);
            _btSkillLifeSteal.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_LifeStealAttack);

            Button _btSkillBash = (Button)_resources[1].CreateObject(10);
            _btSkillBash.Owner = _character.ListLeftHandSkill[6];
            _btSkillBash.GetNewIdleTexture(_character.ListLeftHandSkill[6].IdleIcon);
            _btSkillBash.GetNewClickedTexture(_character.ListLeftHandSkill[6].ClickedIcon);
            _btSkillBash.Mouse_Click += new Button.OnMouseClickHandler(SkillBoard_MouseClick_BashAttack);

            GameFrame _lefthandFrame = (GameFrame)_resources[0].CreateObject(2);
            _lefthandFrame.AddChild(_leftSkillControl);
            _lefthandFrame.AddChild(_rightSkillControl);
            _lefthandFrame.AddChild(_passiveSkillControl);
            _lefthandFrame.AddChild(_btSkillCleaving);
            _lefthandFrame.AddChild(_btSkillCritical);
            _lefthandFrame.AddChild(_btSkillCurse);
            _lefthandFrame.AddChild(_btSkillOverSpeed);
            _lefthandFrame.AddChild(_btSkillLifeSteal);
            _lefthandFrame.AddChild(_btSkillBash);
            _boardFrame.AddChild(_lefthandFrame);

            //RightHand tab
            GameFrame _rightthandFrame = (GameFrame)_resources[0].CreateObject(3);
            _rightthandFrame.AddChild(_leftSkillControl);
            _rightthandFrame.AddChild(_rightSkillControl);
            _rightthandFrame.AddChild(_passiveSkillControl);
            _boardFrame.AddChild(_rightthandFrame);

            //Passive tab
            GameFrame _passiveFrame = (GameFrame)_resources[0].CreateObject(4);
            _passiveFrame.AddChild(_leftSkillControl);
            _passiveFrame.AddChild(_rightSkillControl);
            _passiveFrame.AddChild(_passiveSkillControl);
            _boardFrame.AddChild(_passiveFrame);

            
            _iCurrentBoard = 0;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
            _rect = new Rectangle((int)_boardFrame.X, (int)_boardFrame.Y, (int)_boardFrame.Width, (int)_boardFrame.Height);
        }

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
        }

        public override void Update(GameTime gameTime)
        {
            //_boardFrame.Update(gameTime);
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

            _rect = new Rectangle((int)_boardFrame.X, (int)_boardFrame.Y, (int)_boardFrame.Width, (int)_boardFrame.Height);
            if (_rect.Contains(GlobalVariables.CurrentMouseState.X, GlobalVariables.CurrentMouseState.Y))
            {
                GlobalVariables.AlreadyUseLeftMouse = true;
                //GlobalVariables.AlreadyUseRightMouse = true;
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
            _motionGoIn.FirstDection = "Right";
            _motionGoIn.IsStanding = true;
            _motionGoIn.StandingGround = -10;
            _motionGoIn.Vel = new Vector2(30, 0);
            _motionGoIn.Accel = new Vector2(1.02f,0);
            _motionGoIn.DecelerationRate = 0.6f;
        }

        public void CreateMotion_GoOut()
        {
            _motionGoOut = new MotionInfo();
            _motionGoOut.FirstDection = "Right";
            _motionGoOut.IsStanding = true;
            _motionGoOut.StandingGround = float.MinValue;
            _motionGoOut.Vel = new Vector2(2, 0);
            _motionGoOut.Accel = new Vector2(1.8f, 0);
            _motionGoOut.DecelerationRate = 0.6f;
        }

//------------------------------------------------------------------------------------------
        #region Su kien cho Button trên tab Lefthand
        public void SkillBoard_MouseDown_LeftButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 0)
                return;
            ((GameFrame)_boardFrame.Child[0]).Child[1]._sprite[0].Itexture2D = 0;
            ((GameFrame)_boardFrame.Child[0]).Child[2]._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 0;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }

        //CleavingAttack
        public void SkillBoard_MouseClick_CleavingAttack(object sender, EventArgs e)
        {
            
        }
        //CriticalAttack
        public void SkillBoard_MouseClick_CriticalAttack(object sender, EventArgs e)
        {
            
        }
        //CurseAttack
        public void SkillBoard_MouseClick_CurseAttack(object sender, EventArgs e)
        {
            
        }
        //OverSpeedAttack
        public void SkillBoard_MouseClick_OverSpeedAttack(object sender, EventArgs e)
        {
            
        }
        //LifeStealAttack
        public void SkillBoard_MouseClick_LifeStealAttack(object sender, EventArgs e)
        {
            
        }
        //BashAttack
        public void SkillBoard_MouseClick_BashAttack(object sender, EventArgs e)
        {
            
        }
        #endregion

//------------------------------------------------------------------------------------------------

        #region Su kien cho Button trên tab Rightthand
        public void SkillBoard_MouseDown_RightButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 1)
                return;
            ((GameFrame)_boardFrame.Child[1]).Child[0]._sprite[0].Itexture2D = 0;
            ((GameFrame)_boardFrame.Child[1]).Child[2]._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 1;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }
        #endregion

//-----------------------------------------------------------------------------------------------

        #region Su kien cho Button trên tab Passive
        public void SkillBoard_MouseDown_PassiveButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 2)
                return;
            ((GameFrame)_boardFrame.Child[2]).Child[0]._sprite[0].Itexture2D = 0;
            ((GameFrame)_boardFrame.Child[2]).Child[1]._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 2;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }
        #endregion
    }
}
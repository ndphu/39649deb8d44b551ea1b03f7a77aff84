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

            Button _leftSkillControl = (Button)_resources[1].CreateObject(2);
            _leftSkillControl._sprite[0].Itexture2D = 1; //Được click trước tiên
            _leftSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_LeftButtonControl);

            Button _rightSkillControl = (Button)_resources[1].CreateObject(3);
            _rightSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_RightButtonControl);

            Button _passiveSkillControl = (Button)_resources[1].CreateObject(4);
            _passiveSkillControl.Mouse_Down += new Button.OnMouseDownHandler(SkillBoard_MouseDown_PassiveButtonControl);

            GameFrame _lefthandFrame = (GameFrame)_resources[0].CreateObject(2);
            _lefthandFrame.OffSetX = _lefthandFrame.X;
            _lefthandFrame.OffSetY = _lefthandFrame.Y;
            _lefthandFrame.AddChild(_leftSkillControl);
            _lefthandFrame.AddChild(_rightSkillControl);
            _lefthandFrame.AddChild(_passiveSkillControl);
            _boardFrame.AddChild(_lefthandFrame);

            GameFrame _rightthandFrame = (GameFrame)_resources[0].CreateObject(3);
            _rightthandFrame.OffSetX = _rightthandFrame.X;
            _rightthandFrame.OffSetY = _rightthandFrame.Y;
            _rightthandFrame.AddChild(_leftSkillControl);
            _rightthandFrame.AddChild(_rightSkillControl);
            _rightthandFrame.AddChild(_passiveSkillControl);
            _boardFrame.AddChild(_rightthandFrame);

            GameFrame _passiveFrame = (GameFrame)_resources[0].CreateObject(4);
            _passiveFrame.OffSetX = _passiveFrame.X;
            _passiveFrame.OffSetY = _passiveFrame.Y;
            _passiveFrame.AddChild(_leftSkillControl);
            _passiveFrame.AddChild(_rightSkillControl);
            _passiveFrame.AddChild(_passiveSkillControl);
            _boardFrame.AddChild(_passiveFrame);

            _iCurrentBoard = 0;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }

        public void SetCharacter(PlayerCharacter _char)
        {
            _character = _char;
        }

        public override void Update(GameTime gameTime)
        {
            _boardFrame.Update(gameTime);
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

        //---Su kien cho Button skill board
        public void SkillBoard_MouseDown_LeftButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 0)
                return;
            ((GameFrame)_boardFrame.Child[0]).Child[0]._sprite[0].Itexture2D = 1;
            ((GameFrame)_boardFrame.Child[0]).Child[1]._sprite[0].Itexture2D = 0;
            ((GameFrame)_boardFrame.Child[0]).Child[2]._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 0;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }

        public void SkillBoard_MouseDown_RightButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 1)
                return;
            ((GameFrame)_boardFrame.Child[1]).Child[0]._sprite[0].Itexture2D = 0;
            ((GameFrame)_boardFrame.Child[1]).Child[1]._sprite[0].Itexture2D = 1;
            ((GameFrame)_boardFrame.Child[1]).Child[2]._sprite[0].Itexture2D = 0;
            //((GameFrame)_boardFrame.Child[_iCurrentBoard]).Child[0]._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 1;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }

        public void SkillBoard_MouseDown_PassiveButtonControl(object sender, EventArgs e)
        {
            if (_iCurrentBoard == 2)
                return;
            ((GameFrame)_boardFrame.Child[2]).Child[0]._sprite[0].Itexture2D = 0;
            ((GameFrame)_boardFrame.Child[2]).Child[1]._sprite[0].Itexture2D = 0;
            ((GameFrame)_boardFrame.Child[2]).Child[2]._sprite[0].Itexture2D = 1;
            //((GameFrame)_boardFrame.Child[_iCurrentBoard]).Child[0]._sprite[0].Itexture2D = 0;
            _iCurrentBoard = 2;
            _currentBoard = (GameFrame)_boardFrame.Child[_iCurrentBoard];
        }
    }
}
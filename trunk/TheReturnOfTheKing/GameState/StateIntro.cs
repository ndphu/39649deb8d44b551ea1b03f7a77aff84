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
    public class StateIntro : GameState
    {
        GameFrame _selectMode;
        MotionInfo _selectMotion;
        int _selectDelayTime;

        //GameFrame _introFrame;
        //MotionInfo _introMotion;
        //int _introDelayTime;

        GameFrame _introFrames;
        MotionInfo _introFrameMotion;
        int _introFrameDelayTime;

        GameFrame _introGameFrame;
        GameFrame _dacPhuFrame;
        GameFrame _minhQuanFrame;

        int _currentIntroFrame;

        Button _exitButton;
        GameFrame _exitButtonFrame;
        MotionInfo _exitMotion;
        int _exitDelayTime;

        Button _aboutGameButton;
        GameFrame _aboutGameButtonFrame;
        MotionInfo _aboutMotion;
        int _aboutDelayTime;

        Button _programer1Button;
        GameFrame _programer1ButtonFrame;
        MotionInfo _programer1Motion;
        int _programer1DelayTime;

        Button _programer2Button;
        GameFrame _programer2ButtonFrame;
        MotionInfo _programer2Motion;
        int _programer2DelayTime;

        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            base.InitState(objectManagerArray, owner);

            //_introFrame = (GameFrame)objectManagerArray[1].CreateObject(7);
            //_introMotion = _introFrame.Motion.Clone();
            //_introDelayTime = _introFrame.DelayTime;
            _introFrames = (GameFrame)objectManagerArray[1].CreateObject(7);
            _introFrameMotion = _introFrames.Motion.Clone();
            _introFrameDelayTime = _introFrames.DelayTime;

            _dacPhuFrame = (GameFrame)objectManagerArray[1].CreateObject(13);
            _minhQuanFrame = (GameFrame)objectManagerArray[1].CreateObject(14);
            _introGameFrame = (GameFrame)objectManagerArray[1].CreateObject(15);
            _introFrames.AddChild(_introGameFrame);
            _introFrames.AddChild(_dacPhuFrame);
            _introFrames.AddChild(_minhQuanFrame);
            _currentIntroFrame = 0;

            _selectMode = (GameFrame)objectManagerArray[1].CreateObject(8);
            _selectMode.Move_Complete += new GameFrame.OnMoveCompletedHandler(Move_Complete_SelectFrame);
            _selectMotion = _selectMode.Motion.Clone();
            _selectDelayTime = _selectMode.DelayTime;

            _aboutGameButtonFrame = (GameFrame)objectManagerArray[1].CreateObject(9);
            _aboutGameButton = (Button)objectManagerArray[2].CreateObject(6);
            _aboutGameButton.IsPressButton = true;
            _aboutGameButtonFrame.AddChild(_aboutGameButton);
            _aboutGameButton.Mouse_Down += new Button.OnMouseDownHandler(AboutGame_Down);
            _aboutGameButton.Mouse_Hover += new Button.OnMouseHoverHandler(AboutGame_Hover);
            _aboutMotion = _aboutGameButtonFrame.Motion.Clone();
            _aboutDelayTime = _aboutGameButtonFrame.DelayTime;
            //Set Button này được Click trước
            _aboutGameButton._sprite[0].Itexture2D = 1;

            _programer1ButtonFrame = (GameFrame)objectManagerArray[1].CreateObject(10);
            _programer1Button = (Button)objectManagerArray[2].CreateObject(7);
            _programer1Button.IsPressButton = true;
            _programer1ButtonFrame.AddChild(_programer1Button);
            _programer1Button.Mouse_Down += new Button.OnMouseDownHandler(Programer1_Down);
            _programer1Button.Mouse_Hover += new Button.OnMouseHoverHandler(Programer1_Hover);
            _programer1Motion = _programer1ButtonFrame.Motion.Clone();
            _programer1DelayTime = _programer1ButtonFrame.DelayTime;

            _programer2ButtonFrame = (GameFrame)objectManagerArray[1].CreateObject(11);
            _programer2Button = (Button)objectManagerArray[2].CreateObject(8);
            _programer2Button.IsPressButton = true;
            _programer2ButtonFrame.AddChild(_programer2Button);
            _programer2Button.Mouse_Down += new Button.OnMouseDownHandler(Programer2_Down);
            _programer2Button.Mouse_Hover += new Button.OnMouseHoverHandler(Programer2_Hover);
            _programer2Motion = _programer2ButtonFrame.Motion.Clone();
            _programer2DelayTime = _programer2ButtonFrame.DelayTime;

            _exitButtonFrame = (GameFrame)objectManagerArray[1].CreateObject(12);
            _exitButtonFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(Move_Complete_ExitFrame);
            _exitButton = (Button)objectManagerArray[2].CreateObject(5);
            _exitButtonFrame.AddChild(_exitButton);
            _exitButton.Mouse_Click += new Button.OnMouseClickHandler(Exit_Clicked);
            _exitButton.Mouse_Hover += new Button.OnMouseHoverHandler(Exit_Hover);
            _exitMotion = _exitButtonFrame.Motion.Clone();
            _exitDelayTime = _exitButtonFrame.DelayTime;
        }

        public override void EnterState()
        {

        }

        public override void UpdateState(GameTime gameTime)
        {
            //_introFrame.Update(gameTime);
            _introFrames.Update(gameTime);
            _selectMode.Update(gameTime);

            _aboutGameButtonFrame.Update(gameTime);
            _programer1ButtonFrame.Update(gameTime);
            _programer2ButtonFrame.Update(gameTime);
            _exitButtonFrame.Update(gameTime);

            //_introFrame.Update(gameTime); //Thang nay update cuối cùng vì neu co exit state thì no bảo đảm tất cả
            //các frame đều đã được update..
        }

        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            //_introFrame.Draw(gameTime, sb);
            _introFrames.Child[_currentIntroFrame].Draw(gameTime, sb);
            _selectMode.Draw(gameTime, sb);

            _aboutGameButtonFrame.Draw(gameTime, sb);
            _programer1ButtonFrame.Draw(gameTime, sb);
            _programer2ButtonFrame.Draw(gameTime, sb);
            _exitButtonFrame.Draw(gameTime, sb);
        }

        public override void ExitState()
        {
            GoOut();
        }
        #region Sự kiện cho button
//Button about
        void AboutGame_Down(object sender, EventArgs e)
        {
            _programer1Button._sprite[0].Itexture2D = 0;
            _programer2Button._sprite[0].Itexture2D = 0;
            _currentIntroFrame = 0;
        }

        void AboutGame_Hover(object sender, EventArgs e)
        {
            GlobalVariables.GameCursor.IsHover = true;
        }
//Button programer 1
        void Programer1_Down(object sender, EventArgs e)
        {
            _aboutGameButton._sprite[0].Itexture2D = 0;
            _programer2Button._sprite[0].Itexture2D = 0;
            _currentIntroFrame = 1;
        }
        void Programer1_Hover(object sender, EventArgs e)
        {
            GlobalVariables.GameCursor.IsHover = true;
        }
//BUtton programer 2
        void Programer2_Down(object sender, EventArgs e)
        {
            _aboutGameButton._sprite[0].Itexture2D = 0;
            _programer1Button._sprite[0].Itexture2D = 0;
            _currentIntroFrame = 2;
        }
        void Programer2_Hover(object sender, EventArgs e)
        {
            GlobalVariables.GameCursor.IsHover = true;
        }
//Button exit
        void Exit_Clicked(object sender, EventArgs e)
        {
            SetGameFrameGoOut(_exitButtonFrame, 0);
        }

        void Exit_Hover(object sender, EventArgs e)
        {
            _exitButton._sprite[0].Itexture2D = 1;
            GlobalVariables.GameCursor.IsHover = true;
        }
        #endregion

        #region Sự kiện cho các frame
        public void Move_Complete_SelectFrame(object sender, EventArgs e)
        {
            if (!_aboutGameButtonFrame.IsVisible)
            {
                ((StateMenuManager)GameStateOwner).CurrentState = 0;
                ((StateMenuManager)GameStateOwner).ListOfGameState[0].GoIn();
            }
        }

        public void Move_Complete_ExitFrame(object sender, EventArgs e)
        {
            if (!_exitButtonFrame.IsVisible)
            {
                ExitState();
            }
        }
        #endregion

        #region Hàm dùng chung
        void SetGameFrameGoOut(GameFrame _gameFrame, int _delayTime)
        {
            _gameFrame.IDelayTime = 0;
            _gameFrame.DelayTime = _delayTime;
            _gameFrame.Motion.IsStanding = false;
            _gameFrame.Motion.FirstDection = "Right";
            _gameFrame.Motion.StandingGround = float.MinValue;
            _gameFrame.Motion.Vel = new Vector2(20, 0);
            _gameFrame.Motion.Accel = new Vector2(4, 0);
        }

        public override void GoOut()
        {
            int _delayTime = 15;
            int _delayTimeOffset = 8;

            SetGameFrameGoOut(_aboutGameButtonFrame, _delayTime);
            _delayTime += _delayTimeOffset;
            SetGameFrameGoOut(_programer1ButtonFrame, _delayTime);
            _delayTime += _delayTimeOffset;
            SetGameFrameGoOut(_programer2ButtonFrame, _delayTime);
            _delayTime += _delayTimeOffset;

            /*_introFrame.IDelayTime = 0;
            _introFrame.DelayTime = _delayTime;
            _introFrame.Motion.FirstDection = "Down";
            _introFrame.Motion.IsStanding = false;
            _introFrame.Motion.StandingGround = float.MinValue;
            _introFrame.Motion.Vel = new Vector2(0, 10);*/

            _introFrames.IDelayTime = 0;
            _introFrames.DelayTime = _delayTime;
            _introFrames.Motion.FirstDection = "Down";
            _introFrames.Motion.IsStanding = false;
            _introFrames.Motion.StandingGround = float.MinValue;
            _introFrames.Motion.Vel = new Vector2(0, 10);

            _selectMode.IDelayTime = 0;
            _selectMode.DelayTime = _delayTime;
            _selectMode.Motion.FirstDection = "Down";
            _selectMode.Motion.IsStanding = false;
            _selectMode.Motion.StandingGround = float.MinValue;
            _selectMode.Motion.Vel = new Vector2(0, 10);
        }

        public override void GoIn()
        {
            _selectMode.Motion = _selectMotion.Clone();
            _selectMode.IDelayTime = 0;
            _selectMode.DelayTime = _selectDelayTime;

            /*_introFrame.Motion = _introMotion.Clone();
            _introFrame.IDelayTime = 0;
            _introFrame.DelayTime = _introDelayTime;*/

            _introFrames.Motion = _introFrameMotion.Clone();
            _introFrames.IDelayTime = 0;
            _introFrames.DelayTime = _introFrameDelayTime;

            _aboutGameButtonFrame.Motion = _aboutMotion.Clone();
            _aboutGameButtonFrame.IDelayTime = 0;
            _aboutGameButtonFrame.DelayTime = _aboutDelayTime;

            _programer1ButtonFrame.Motion = _programer1Motion.Clone();
            _programer1ButtonFrame.IDelayTime = 0;
            _programer1ButtonFrame.DelayTime = _programer1DelayTime;

            _programer2ButtonFrame.Motion = _programer2Motion.Clone();
            _programer2ButtonFrame.IDelayTime = 0;
            _programer2ButtonFrame.DelayTime = _programer2DelayTime;

            _exitButtonFrame.Motion = _exitMotion.Clone();
            _exitButtonFrame.IDelayTime = 0;
            _exitButtonFrame.DelayTime = _exitDelayTime;
        }
        #endregion
    }
}

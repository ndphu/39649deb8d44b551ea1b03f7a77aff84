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
    
    public class StateMenu : GameState
    {
        int _indexOfNextState = -1;

        GameFrame _newgameFrame;
        MotionInfo _newgameFrameMotion;
        int _newgameDelayTimeGoIn;
        Button _newgameButton;

        GameFrame _loadgameFrame;
        MotionInfo _loadgameFrameMotion;
        int _loadgameDelayTimeGoIn;
        Button _loadgameButton;

        GameFrame _optionFrame;
        MotionInfo _optionFrameMotion;
        int _optionDelayTimeGoIn;
        Button _optionButton;

        GameFrame _helpFrame;
        MotionInfo _helpFrameMotion;
        int _helpDelayTimeGoIn;
        Button _helpButton;

        GameFrame _aboutFrame;
        MotionInfo _aboutFrameMotion;
        int _aboutDelayTimeGoIn;
        Button _aboutButton;

        GameFrame _quitFrame;
        MotionInfo _quitFrameMotion;
        int _quitDelayTimeGoIn;
        Button _quitButton;

        GameFrame _menuFrame;
        MotionInfo _menuFrameMotion;
        int _menuFrameDelayTimeGoIn;

        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            //Trong innit tao
            base.InitState(objectManagerArray, owner);

            _newgameFrame = (GameFrame)objectManagerArray[1].CreateObject(0);
            _newgameFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_NewGame);
            _newgameButton = (Button)objectManagerArray[2].CreateObject(0);
            _newgameFrame.AddChild(_newgameButton);
            _newgameButton.Owner = _newgameFrame;
            _newgameButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_NewGame);
            _newgameButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_NewGame);
            _newgameFrameMotion = _newgameFrame.Motion.Clone();
            _newgameDelayTimeGoIn = _newgameFrame.DelayTime;

            _loadgameFrame = (GameFrame)objectManagerArray[1].CreateObject(1);
            _loadgameFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_Load);
            _loadgameButton = (Button)objectManagerArray[2].CreateObject(1);
            _loadgameFrame.AddChild(_loadgameButton);
            _loadgameButton.Owner = _loadgameFrame;
            _loadgameButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Load);
            _loadgameButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_Load);
            _loadgameFrameMotion = _loadgameFrame.Motion.Clone();
            _loadgameDelayTimeGoIn = _loadgameFrame.DelayTime;

            _optionFrame = (GameFrame)objectManagerArray[1].CreateObject(2);
            _optionFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_Option);
            _optionButton = (Button)objectManagerArray[2].CreateObject(2);
            _optionFrame.AddChild(_optionButton);
            _optionButton.Owner = _optionFrame;
            _optionButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Option);
            _optionButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_Option);
            _optionFrameMotion = _optionFrame.Motion.Clone();
            _optionDelayTimeGoIn = _optionFrame.DelayTime;

            _helpFrame = (GameFrame)objectManagerArray[1].CreateObject(3);
            _helpFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_Help);
            _helpButton = (Button)objectManagerArray[2].CreateObject(3);
            _helpFrame.AddChild(_helpButton);
            _helpButton.Owner = _helpFrame;
            _helpButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Help);
            _helpButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_Help);
            _helpFrameMotion = _helpFrame.Motion.Clone();
            _helpDelayTimeGoIn = _helpFrame.DelayTime;

            _aboutFrame = (GameFrame)objectManagerArray[1].CreateObject(4);
            _aboutFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_About);
            _aboutButton = (Button)objectManagerArray[2].CreateObject(4);
            _aboutFrame.AddChild(_aboutButton);
            _aboutButton.Owner = _aboutFrame;
            _aboutButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_About);
            _aboutButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_About);
            _aboutFrameMotion = _aboutFrame.Motion.Clone();
            _aboutDelayTimeGoIn = _aboutFrame.DelayTime;

            _quitFrame = (GameFrame)objectManagerArray[1].CreateObject(5);
            _quitFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_Quit);
            _quitButton = (Button)objectManagerArray[2].CreateObject(5);
            _quitFrame.AddChild(_quitButton);
            _quitButton.Owner = _quitFrame;
            _quitButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Quit);
            _quitButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_Quit);
            _quitFrameMotion = _quitFrame.Motion.Clone();
            _quitDelayTimeGoIn = _quitFrame.DelayTime;

            _menuFrame = (GameFrame)objectManagerArray[1].CreateObject(6);
            _menuFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_MenuFrame);
            _menuFrameMotion = _menuFrame.Motion.Clone();
            _menuFrameDelayTimeGoIn = _menuFrame.DelayTime;
        }

        public override void EnterState()
        {

        }

        public override void UpdateState(GameTime gameTime)
        {
            _menuFrame.Update(gameTime);
            _newgameFrame.Update(gameTime);
            _loadgameFrame.Update(gameTime);
            _optionFrame.Update(gameTime);
            _helpFrame.Update(gameTime);
            _aboutFrame.Update(gameTime);
            _quitFrame.Update(gameTime);
        }

        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            _menuFrame.Draw(gameTime, sb);
            _newgameFrame.Draw(gameTime, sb);
            _loadgameFrame.Draw(gameTime, sb);
            _optionFrame.Draw(gameTime, sb);
            _helpFrame.Draw(gameTime, sb);
            _aboutFrame.Draw(gameTime, sb);
            _quitFrame.Draw(gameTime, sb);
        }

        public override void ExitState()
        {
            GoOut();
        }

        #region Cá sự kiện Button
//------------------Su kien Button NewGame------------------
        void StateMenu_Mouse_Click_NewGame(object sender, EventArgs e)
        {
            if (!((GameFrame)((Button)sender).Owner).Motion.IsStanding)
                return;
            if (_indexOfNextState != -1)
                return;
            _indexOfNextState = 0;
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_NewGame(object sender, EventArgs e)
        {
            if (_indexOfNextState != -1)
                return;
            ButtonHoverEffect((Button)sender);
        }
//--------------------Su kien Button Load------------------
        void StateMenu_Mouse_Click_Load(object sender, EventArgs e)
        {
            if (!((GameFrame)((Button)sender).Owner).Motion.IsStanding)
                return;
            if (_indexOfNextState != -1)
                return;
            _indexOfNextState = 1;
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_Load(object sender, EventArgs e)
        {
            if (_indexOfNextState != -1)
                return;
            ButtonHoverEffect((Button)sender);
        }
//------------------Su kien Button Option------------------
        void StateMenu_Mouse_Click_Option(object sender, EventArgs e)
        {
            if (!((GameFrame)((Button)sender).Owner).Motion.IsStanding)
                return;
            if (_indexOfNextState != -1)
                return;
            _indexOfNextState = 2;
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_Option(object sender, EventArgs e)
        {
            if (_indexOfNextState != -1)
                return;
            ButtonHoverEffect((Button)sender);
        }
//-------------------Su kien Button Help------------------
        void StateMenu_Mouse_Click_Help(object sender, EventArgs e)
        {
            if (!((GameFrame)((Button)sender).Owner).Motion.IsStanding)
                return;
            if (_indexOfNextState != -1)
                return;
            _indexOfNextState = 3;
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_Help(object sender, EventArgs e)
        {
            if (_indexOfNextState != -1)
                return;
            ButtonHoverEffect((Button)sender);
        }
//-------------------Su kien Button About------------------
        void StateMenu_Mouse_Click_About(object sender, EventArgs e)
        {
            if (!((GameFrame)((Button)sender).Owner).Motion.IsStanding)
                return;
            if (_indexOfNextState != -1)
                return;
            _indexOfNextState = 4;
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_About(object sender, EventArgs e)
        {
            if (_indexOfNextState != -1)
                return;
            ButtonHoverEffect((Button)sender);
        }
//------------------Su kien Button Quit------------------
        void StateMenu_Mouse_Click_Quit(object sender, EventArgs e)
        {
            if (!((GameFrame)((Button)sender).Owner).Motion.IsStanding)
                return;
            if (_indexOfNextState != -1)
                return;
            _indexOfNextState = 5;
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_Quit(object sender, EventArgs e)
        {
            if (_indexOfNextState != -1)
                return;
            ButtonHoverEffect((Button)sender);
        }
        #endregion

        #region Các sự kiện Frame
//--------------------Su kien New Game frame------------------
        void StateMenu_Move_Complete_NewGame(object sender, EventArgs e)
        {
            if (_indexOfNextState != 0)
                return;
            GameFrame _frame = (GameFrame)sender;
            if (_frame.IsVisible == false)
            {
                int nObjectManager = 8;
                GameObjectManager[] objectManagerArray = new GameObjectManager[nObjectManager];

                objectManagerArray[1] = new MapManager(@"Data\Map\map.xml");
                objectManagerArray[0] = new PlayerCharacterManager(@"Data\character\character.xml");
                objectManagerArray[2] = new MonsterManager(@"Data\monster\monster.xml");
                objectManagerArray[3] = new ProcessBarManager(@"Data\XML\loadingprocessbar.xml");
                objectManagerArray[4] = new PortralManager(@"Data\Portral\Portral.xml");
                objectManagerArray[5] = new MapObstacleManager(@"Data\MapObstacle\MapObstacle.xml");
                objectManagerArray[6] = new ProjectileManager(@"Data\Projectile\Projectile.xml");
                objectManagerArray[7] = new SkillManager(@"Data\Skill\Skill.xml");


                Owner.GameState = new StateLoading();
                Owner.GameState.InitState(null, Owner);
                ((StateLoading)Owner.GameState).GetDataLoading(Owner.Content, @"./Data/XML/loadingtomenu.xml", objectManagerArray, typeof(StateMainGame));
                Owner.GameState.EnterState();
            }
        }

//--------------------Su kien Load frame------------------
        void StateMenu_Move_Complete_Load(object sender, EventArgs e)
        {
            if (_indexOfNextState != 1)
                return;
            if (!_loadgameFrame.IsVisible)
                ExitState();
        }

//--------------------Su kien Option frame------------------
        void StateMenu_Move_Complete_Option(object sender, EventArgs e)
        {
            if (_indexOfNextState != 2)
                return;
            if (!_optionFrame.IsVisible)
                ExitState();
        }

//--------------------Su kien Help frame------------------
        void StateMenu_Move_Complete_Help(object sender, EventArgs e)
        {
            if (_indexOfNextState != 3)
                return;
            if (!_helpFrame.IsVisible)
                ExitState();
        }

//--------------------Su kien About frame------------------
        void StateMenu_Move_Complete_About(object sender, EventArgs e)
        {
            if (_indexOfNextState != 4)
                return;
            if (!_aboutFrame.IsVisible)
                ExitState();
        }
//--------------------Su kien Quit frame------------------
        void StateMenu_Move_Complete_Quit(object sender, EventArgs e)
        {
            if (_indexOfNextState != 5)
                return;
            GameFrame _frame = (GameFrame)sender;
            if (!_frame.IsVisible)
                Owner.Exit();
        }
//---------------------Su kien Menu Frame-----------------
        void StateMenu_Move_Complete_MenuFrame(object sender, EventArgs e)
        {
            if (!_menuFrame.IsVisible)
            {
                ((StateMenuManager)GameStateOwner).CurrentState = _indexOfNextState;
                ((StateMenuManager)GameStateOwner).ListOfGameState[_indexOfNextState].GoIn();
            }
        }

        #endregion

//----------------------Ham dùng chung---------------------------------
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

        void ButtonClickEffect(Button _button)
        {
            //if (((GameFrame)_button.Owner).Motion.IsStanding)
            SetGameFrameGoOut((GameFrame)_button.Owner, 0);
        }

        void ButtonHoverEffect(Button _button)
        {
            _button._sprite[0].Itexture2D = 1;
            GlobalVariables.GameCursor.IsHover = true;
        }
//-----------Menu go back-----------------------------------------------------
        public override void GoOut()
        {
            int _delayTime = 15;
            int _delayTimeOffset = 8;

            SetGameFrameGoOut(_newgameFrame, _delayTime);
            _delayTime += _delayTimeOffset;
            if (_indexOfNextState != 1)
            {
                SetGameFrameGoOut(_loadgameFrame, _delayTime);
                _delayTime += _delayTimeOffset;
            }
            if (_indexOfNextState != 2)
            {
                SetGameFrameGoOut(_optionFrame, _delayTime);
                _delayTime += _delayTimeOffset;
            }
            if (_indexOfNextState != 3)
            {
                SetGameFrameGoOut(_helpFrame, _delayTime);
                _delayTime += _delayTimeOffset;
            }
            if (_indexOfNextState != 4)
            {
                SetGameFrameGoOut(_aboutFrame, _delayTime);
                _delayTime += _delayTimeOffset;
            }

            SetGameFrameGoOut(_quitFrame, _delayTime);
            _delayTime += _delayTimeOffset;

            _menuFrame.IDelayTime = 0;
            _menuFrame.DelayTime = _delayTime;
            _menuFrame.Motion.FirstDection = "Down";
            _menuFrame.Motion.IsStanding = false;
            _menuFrame.Motion.StandingGround = float.MinValue;
            _menuFrame.Motion.Vel = new Vector2(0, 10);
        }

        public override void  GoIn()
        {
            //Sau khi vào lại state phải set lại cái biến này.
            _indexOfNextState = -1;

            _menuFrame.Motion = _menuFrameMotion.Clone();
            _menuFrame.IDelayTime = 0;
            _menuFrame.DelayTime = _menuFrameDelayTimeGoIn;

            _newgameFrame.Motion = _newgameFrameMotion.Clone();
            _newgameFrame.IDelayTime = 0;
            _newgameFrame.DelayTime = _newgameDelayTimeGoIn;

            _loadgameFrame.Motion = _loadgameFrameMotion.Clone();
            _loadgameFrame.IDelayTime = 0;
            _loadgameFrame.DelayTime = _loadgameDelayTimeGoIn;

            _optionFrame.Motion = _optionFrameMotion.Clone();
            _optionFrame.IDelayTime = 0;
            _optionFrame.DelayTime = _optionDelayTimeGoIn;

            _helpFrame.Motion = _helpFrameMotion.Clone();
            _helpFrame.IDelayTime = 0;
            _helpFrame.DelayTime = _helpDelayTimeGoIn;

            _aboutFrame.Motion = _aboutFrameMotion.Clone();
            _aboutFrame.IDelayTime = 0;
            _aboutFrame.DelayTime = _aboutDelayTimeGoIn;

            _quitFrame.Motion = _quitFrameMotion.Clone();
            _quitFrame.IDelayTime = 0;
            _quitFrame.DelayTime = _quitDelayTimeGoIn;
        }
    }
}

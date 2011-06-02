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

        Background _menubg;

        GameFrame _newgameFrame;
        Button _newgameButton;

        GameFrame _loadgameFrame;
        Button _loadgameButton;

        GameFrame _optionFrame;
        Button _optionButton;

        GameFrame _helpFrame;
        Button _helpButton;

        GameFrame _aboutFrame;
        Button _aboutButton;

        GameFrame _quitFrame;
        Button _quitButton;

        GameFrame _menuFrame;
       
        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            //Trong innit tao
            base.InitState(objectManagerArray, owner);

            _menubg = (Background)objectManagerArray[0].CreateObject(0);

            _newgameFrame = (GameFrame)objectManagerArray[1].CreateObject(0);
            _newgameFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_NewGame);
            _newgameButton = (Button)objectManagerArray[2].CreateObject(0);
            _newgameFrame.AddChild(_newgameButton);
            _newgameButton.Owner = _newgameFrame;
            _newgameButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_NewGame);
            _newgameButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_NewGame);

            _loadgameFrame = (GameFrame)objectManagerArray[1].CreateObject(1);
            _loadgameFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_Load);
            _loadgameButton = (Button)objectManagerArray[2].CreateObject(1);
            _loadgameFrame.AddChild(_loadgameButton);
            _loadgameButton.Owner = _loadgameFrame;
            _loadgameButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Load);
            _loadgameButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_Load);

            _optionFrame = (GameFrame)objectManagerArray[1].CreateObject(2);
            _optionFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_Option);
            _optionButton = (Button)objectManagerArray[2].CreateObject(2);
            _optionFrame.AddChild(_optionButton);
            _optionButton.Owner = _optionFrame;
            _optionButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Option);
            _optionButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_Option);

            _helpFrame = (GameFrame)objectManagerArray[1].CreateObject(3);
            _helpFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_Help);
            _helpButton = (Button)objectManagerArray[2].CreateObject(3);
            _helpFrame.AddChild(_helpButton);
            _helpButton.Owner = _helpFrame;
            _helpButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Help);
            _helpButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_Help);

            _aboutFrame = (GameFrame)objectManagerArray[1].CreateObject(4);
            _aboutFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_About);
            _aboutButton = (Button)objectManagerArray[2].CreateObject(4);
            _aboutFrame.AddChild(_aboutButton);
            _aboutButton.Owner = _aboutFrame;
            _aboutButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_About);
            _aboutButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_About);

            _quitFrame = (GameFrame)objectManagerArray[1].CreateObject(5);
            _quitFrame.Move_Complete += new GameFrame.OnMoveCompletedHandler(StateMenu_Move_Complete_Quit);
            _quitButton = (Button)objectManagerArray[2].CreateObject(5);
            _quitFrame.AddChild(_quitButton);
            _quitButton.Owner = _quitFrame;
            _quitButton.Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Quit);
            _quitButton.Mouse_Hover += new Button.OnMouseHoverHandler(StateMenu_Mouse_Hover_Quit);

            _menuFrame = (GameFrame)objectManagerArray[1].CreateObject(6);
        }

        public override void EnterState()
        {

        }

        public override void UpdateState(GameTime gameTime)
        {
            _menubg.Update(gameTime);
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
            _menubg.Draw(gameTime, sb);
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

        }

 //------------------Su kien Button NewGame------------------
        void StateMenu_Mouse_Click_NewGame(object sender, EventArgs e)
        {
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_NewGame(object sender, EventArgs e)
        {
            ButtonHoverEffect((Button)sender);
        }
//------------------Su kien Button Quit------------------
        void StateMenu_Mouse_Click_Quit(object sender, EventArgs e)
        {
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_Quit(object sender, EventArgs e)
        {
            ButtonHoverEffect((Button)sender);
        }
//------------------Su kien Button Option------------------
        void StateMenu_Mouse_Click_Option(object sender, EventArgs e)
        {
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_Option(object sender, EventArgs e)
        {
            ButtonHoverEffect((Button)sender);
        }
//-------------------Su kien Button Help------------------
        void StateMenu_Mouse_Click_Help(object sender, EventArgs e)
        {
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_Help(object sender, EventArgs e)
        {
            ButtonHoverEffect((Button)sender);
        }
//-------------------Su kien Button About------------------
        void StateMenu_Mouse_Click_About(object sender, EventArgs e)
        {
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_About(object sender, EventArgs e)
        {
            ButtonHoverEffect((Button)sender);
        }
//--------------------Su kien Button Load------------------
        void StateMenu_Mouse_Click_Load(object sender, EventArgs e)
        {
            ButtonClickEffect((Button)sender);
        }

        void StateMenu_Mouse_Hover_Load(object sender, EventArgs e)
        {
            ButtonHoverEffect((Button)sender);
        }
//--------------------Su kien New Game frame------------------
        void StateMenu_Move_Complete_NewGame(object sender, EventArgs e)
        {
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
            
        }

//--------------------Su kien Option frame------------------
        void StateMenu_Move_Complete_Option(object sender, EventArgs e)
        {
            
        }

//--------------------Su kien Help frame------------------
        void StateMenu_Move_Complete_Help(object sender, EventArgs e)
        {
            
        }

//--------------------Su kien About frame------------------
        void StateMenu_Move_Complete_About(object sender, EventArgs e)
        {

        }

//--------------------Su kien Quit frame------------------
        void StateMenu_Move_Complete_Quit(object sender, EventArgs e)
        {
            GameFrame _frame = (GameFrame)sender;
            if (_frame.IsVisible == false)
                Owner.Exit();
        }

//----------------------Ham dùng chung---------------------------------
        void SetGameFrameGoOut(GameFrame _gameFrame)
        {
            _gameFrame.Motion.IsStanding = false;
            _gameFrame.Motion.FirstDection = "Right";
            _gameFrame.Motion.StandingGround = float.MinValue;
            _gameFrame.Motion.Vel = new Vector2(20, 0);
            _gameFrame.Motion.Accel = new Vector2(4, 0);
        }

        void ButtonClickEffect(Button _button)
        {
            if (((GameFrame)_button.Owner).Motion.IsStanding)
                SetGameFrameGoOut((GameFrame)_button.Owner);
        }

        void ButtonHoverEffect(Button _button)
        {
            _button._sprite[0].Itexture2D = 1;
            GlobalVariables.GameCursor.IsHover = true;
        }
    }
}

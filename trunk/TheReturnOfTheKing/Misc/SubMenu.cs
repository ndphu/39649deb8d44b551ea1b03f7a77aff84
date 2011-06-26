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
using System.Xml;

namespace TheReturnOfTheKing
{
    public class SubMenu : Misc
    {
        GameFrame _backGround;

        int _currentChild;

        GameFrame _mainFrame;

        Button _btOnButton;

        Button _btOffButton;

        Button _btHelp;

        Button _btQuit;

        Button _btResume;

        GameFrame _messageBox;

        Button _btOK;

        Button _btCancel;
        StateMainGame _stateOwner;

        public void GetResources(List<GameObjectManager> _resources)
        {
            _mainFrame = (GameFrame)_resources[0].CreateObject(7);
            _backGround = (GameFrame)_resources[0].CreateObject(8);
            _currentChild = 0;

            _btOnButton = (Button)_resources[1].CreateObject(40);
            _btOnButton.IsPressButton = true;
            _btOnButton.Mouse_Down += new Button.OnMouseDownHandler(OnButton_Down);

            _btOffButton = (Button)_resources[1].CreateObject(41);
            _btOffButton.IsPressButton = true;
            _btOffButton.Mouse_Down += new Button.OnMouseDownHandler(OffButton_Down);

            _btHelp = (Button)_resources[1].CreateObject(42);
            _btHelp.Mouse_Click += new Button.OnMouseClickHandler(HelpButton_Click);
            _btHelp.Mouse_Hover += new Button.OnMouseHoverHandler(HelpButton_Hover);
            _btHelp.Mouse_Released += new Button.OnMouseReleasedHandler(HelpButton_Release);

            _btQuit = (Button)_resources[1].CreateObject(43);
            _btQuit.Mouse_Click += new Button.OnMouseClickHandler(QuitButton_Click);
            _btQuit.Mouse_Hover += new Button.OnMouseHoverHandler(QuitButton_Hover);
            _btQuit.Mouse_Released += new Button.OnMouseReleasedHandler(QuitButton_Release);

            _btResume = (Button)_resources[1].CreateObject(44);
            _btResume.Mouse_Click += new Button.OnMouseClickHandler(ResumeButton_Click);
            _btResume.Mouse_Hover += new Button.OnMouseHoverHandler(ResumeButton_Hover);
            _btResume.Mouse_Released += new Button.OnMouseReleasedHandler(ResumeButton_Release);

            _mainFrame.AddChild(_btOnButton);
            _mainFrame.AddChild(_btOffButton);
            _mainFrame.AddChild(_btHelp);
            _mainFrame.AddChild(_btQuit);
            _mainFrame.AddChild(_btResume);

            _backGround.AddChild(_mainFrame);

            _btOK = (Button)_resources[1].CreateObject(45);
            _btOK.Mouse_Click += new Button.OnMouseClickHandler(OKButton_Click);
            _btOK.Mouse_Hover += new Button.OnMouseHoverHandler(OKButton_Hover);
            _btOK.Mouse_Released += new Button.OnMouseReleasedHandler(OKButton_Release);

            _btCancel = (Button)_resources[1].CreateObject(46);
            _btCancel.Mouse_Click += new Button.OnMouseClickHandler(CancelButton_Click);
            _btCancel.Mouse_Hover += new Button.OnMouseHoverHandler(CancelButton_Hover);
            _btCancel.Mouse_Released += new Button.OnMouseReleasedHandler(CancelButton_Release);

            _messageBox = (GameFrame)_resources[0].CreateObject(9);
            _messageBox.AddChild(_btOK);
            _messageBox.AddChild(_btCancel);

            _backGround.AddChild(_messageBox);
        }

        public void GetStateOwner (StateMainGame _state)
        {
            _stateOwner = _state;
        }

        public override void Update(GameTime gameTime)
        {
            _backGround.Child[_currentChild].Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(_backGround._sprite[0].Texture2D[0], new Vector2(_backGround.X, _backGround.Y), Color.White);

            sb.Draw(_backGround.Child[_currentChild]._sprite[0].Texture2D[0], new Vector2(_backGround.Child[_currentChild].X, _backGround.Child[_currentChild].Y), Color.White);
            for (int i = 0; i < ((GameFrame)_backGround.Child[_currentChild]).Child.Count; i++)
            {
                ((GameFrame)_backGround.Child[_currentChild]).Child[i].Draw(gameTime, sb);
            }
        }
        

        //su kien button On effect
        public void OnButton_Down(object sender, EventArgs e)
        {
            _btOffButton._sprite[0].Itexture2D = 0;
        }

        //su kien button off effect
        public void OffButton_Down(object sender, EventArgs e)
        {
            _btOnButton._sprite[0].Itexture2D = 0;
        }

        //su kien button help
        public void HelpButton_Click(object sender, EventArgs e)
        {

        }

        public void HelpButton_Hover(object sender, EventArgs e)
        {
            HoverEffect((Button)sender);
        }

        public void HelpButton_Release(object sender, EventArgs e)
        {
            ReleaseEffect((Button)sender);
        }

        //su kien button quit
        public void QuitButton_Click(object sender, EventArgs e)
        {
            _currentChild = 1;
        }

        public void QuitButton_Hover(object sender, EventArgs e)
        {
            HoverEffect((Button)sender);
        }

        public void QuitButton_Release(object sender, EventArgs e)
        {
            ReleaseEffect((Button)sender);
        }

        //su kien button resume
        public void ResumeButton_Click(object sender, EventArgs e)
        {
            GlobalVariables.IsPauseGame = false;
        }

        public void ResumeButton_Hover(object sender, EventArgs e)
        {
            HoverEffect((Button)sender);
        }

        public void ResumeButton_Release(object sender, EventArgs e)
        {
            ReleaseEffect((Button)sender);
        }

        //Su kien button OK
        public void OKButton_Click(object sender, EventArgs e)
        {
            int nObjectManager = 3;
            GameObjectManager[] objectManagerArray = new GameObjectManager[nObjectManager];
            objectManagerArray[0] = new BackgroundManager(@"./Data/XML/menubg.xml");
            objectManagerArray[1] = new GameFrameManager(@"./Data/XML/gameframe-statemenu.xml");
            objectManagerArray[2] = new ButtonManger(@"./Data/XML/buttonmanager-statemenu.xml");

            _stateOwner.Owner.GameState = new StateLoading();
            _stateOwner.Owner.GameState.InitState(null, _stateOwner.Owner);
            ((StateLoading)_stateOwner.Owner.GameState).GetDataLoading(_stateOwner.Owner.Content, @"./Data/XML/loadingtomenu.xml", objectManagerArray, typeof(StateMenuManager));
            _stateOwner.Owner.GameState.EnterState();
        }

        public void OKButton_Hover(object sender, EventArgs e)
        {
            HoverEffect((Button)sender);
        }

        public void OKButton_Release(object sender, EventArgs e)
        {
            ReleaseEffect((Button)sender);
        }

        //Su kien button Cancel
        public void CancelButton_Click(object sender, EventArgs e)
        {
            _currentChild = 0;
        }

        public void CancelButton_Hover(object sender, EventArgs e)
        {
            HoverEffect((Button)sender);
        }

        public void CancelButton_Release(object sender, EventArgs e)
        {
            ReleaseEffect((Button)sender);
        }

        //Ham dung chung
        public void HoverEffect(Button _button)
        {
            _button._sprite[0].Itexture2D = 1;
            GlobalVariables.GameCursor.IsHover = true;
        }

        public void ReleaseEffect(Button _button)
        {
            _button._sprite[0].Itexture2D = 0;
            GlobalVariables.GameCursor.IsIdle = true;
        }
    }
}

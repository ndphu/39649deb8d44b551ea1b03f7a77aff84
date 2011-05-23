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
        MenuFrame _menuFrame;
        Button[] _buttonArray;
        GameTitle _gameTitle;
       

        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            //Trong innit tao
            base.InitState(objectManagerArray, owner);
            //Innit MenuBackground
            _menubg = (Background)objectManagerArray[1].CreateObject(0);
            _menuFrame = (MenuFrame)objectManagerArray[2].CreateObject(0);

            //Innit Button array
            _buttonArray = new Button[6];
            //New game
            _buttonArray[0] = (Button)objectManagerArray[0].CreateObject(0);
            _buttonArray[0].Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_NewGame);
            //Load game
            _buttonArray[1] = (Button)objectManagerArray[0].CreateObject(1);
            _buttonArray[1].Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Load);
            //Options
            _buttonArray[2] = (Button)objectManagerArray[0].CreateObject(2);
            _buttonArray[2].Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Option);
            //Help
            _buttonArray[3] = (Button)objectManagerArray[0].CreateObject(3);
            _buttonArray[3].Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Help);
            //About
            _buttonArray[4] = (Button)objectManagerArray[0].CreateObject(4);
            _buttonArray[4].Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_About);
            //Quit
            _buttonArray[5] = (Button)objectManagerArray[0].CreateObject(5);
            _buttonArray[5].Mouse_Click += new Button.OnMouseClickHandler(StateMenu_Mouse_Click_Quit);

            //Innit gameTitle
            _gameTitle = (GameTitle)objectManagerArray[3].CreateObject(0);
        }

        /// <summary>
        /// Hàm xử lý cho sự kiện click lên nút NewGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StateMenu_Mouse_Click_NewGame(object sender, EventArgs e)
        {
            Button _sender = (Button)sender;
            //BUtton dừng lại rồi, mới được click
            if (!_sender._motionInfo.IsStanding)
                return;



            int nObjectManager = 6;
            GameObjectManager[] objectManagerArray = new GameObjectManager[nObjectManager];

            objectManagerArray[1] = new MapManager(@"Data\Map\map.xml");
            objectManagerArray[0] = new PlayerCharacterManager(@"Data\character\character.xml");
            objectManagerArray[2] = new MonsterManager(@"Data\monster\monster.xml");
            objectManagerArray[3] = new ProcessBarManager(@"Data\XML\loadingprocessbar.xml");
            objectManagerArray[4] = new PortralManager(@"Data\Portral\Portral.xml");
            objectManagerArray[5] = new MapObstacleManager(@"Data\MapObstacle\MapObstacle.xml");

            Owner.GameState.ExitState();
            Owner.GameState = new StateLoading();
            Owner.GameState.InitState(objectManagerArray, Owner);
            ((StateLoading)Owner.GameState).GetDataLoading(Owner.Content, @"./Data/XML/loadingtomenu.xml", objectManagerArray, typeof(StateMainGame));
            Owner.GameState.EnterState();            
        }

        /// <summary>
        /// Hàm xử lý cho sự kiện click lên nút Quit
        /// Dự kiến xử lý: Tắt game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StateMenu_Mouse_Click_Quit(object sender, EventArgs e)
        {
            Owner.Exit();
        }
        /// <summary>
        /// Hàm xử lý cho sự kiện click lên nút option
        /// Dự kiến xử lý: chuyển sang StateOption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StateMenu_Mouse_Click_Option(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Hàm xử lý cho sự kiện click lên nút Help
        /// Dự kiến xử lý: Chuyển sang trạng thái HelpState
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StateMenu_Mouse_Click_Help(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Hàm xử lý cho sự kiện click lên nút About
        /// Dự kiến xử lý: chuyển sang trạng thái AboutState: giới thiệu nhóm, email, support này nọ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StateMenu_Mouse_Click_About(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        ///  Hàm xử lý cho sự kiện lick lên nút Load
        ///  Dự kiến xử lý: chuyển sang trạng thái LoadState (khác loadingstate nhá)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StateMenu_Mouse_Click_Load(object sender, EventArgs e)
        {
            
        }
        
        public override void EnterState()
        {
           
        }

        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            _menubg.Draw(gameTime, sb);
            //_gametitle.Draw(gameTime, sb);
            _menuFrame.Draw(gameTime, sb);
            for (int i = 0; i < _buttonArray.Length; i++)
            {
                _buttonArray[i].Draw(gameTime, sb);
            }
            _gameTitle.Draw(gameTime, sb);
        }

        public override void UpdateState(GameTime gameTime)
        {
            _menubg.Update(gameTime);
            //_gametitle.Update(gameTime);  
            _menuFrame.Update(gameTime);
            for (int i = 0; i < _buttonArray.Length; i++)
            {
                _buttonArray[i].Update(gameTime);
            }
            _gameTitle.Update(gameTime);
        }

        public override void ExitState()
        {
            
        }
    }
}

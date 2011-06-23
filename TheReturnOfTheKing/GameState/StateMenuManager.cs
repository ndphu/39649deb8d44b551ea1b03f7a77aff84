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
    public class StateMenuManager : GameState
    {
        Background _menubg;

        List<GameState> _listOfGameState;
        public List<GameState> ListOfGameState
        {
            get { return _listOfGameState; }
            set { _listOfGameState = value; }
        }

        int _currentState = 0;
        public int CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }



        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            base.InitState(objectManagerArray, owner);
            _listOfGameState = new List<GameState>();

            _menubg = (Background)objectManagerArray[0].CreateObject(0);

            //Index = 0;
            StateMenu _stateMenu = new StateMenu();
            _stateMenu.InitState(objectManagerArray, owner);
            _stateMenu.GameStateOwner = this;

            //Index = 1
            StateLoadGame _stateLoadGame = new StateLoadGame();
            _stateLoadGame.InitState(objectManagerArray, owner);
            _stateLoadGame.GameStateOwner = this;

            //Index = 2
            StateOptions _stateOptions = new StateOptions();
            _stateOptions.InitState(objectManagerArray, owner);
            _stateOptions.GameStateOwner = this;

            //Index = 3
            StateHelps _stateHelps = new StateHelps();
            _stateHelps.InitState(objectManagerArray, owner);
            _stateHelps.GameStateOwner = this;

            //Index = 4
            StateIntro _stateIntro = new StateIntro();
            _stateIntro.InitState(objectManagerArray, owner);
            _stateIntro.GameStateOwner = this;

            _listOfGameState.Add(_stateMenu);
            _listOfGameState.Add(_stateLoadGame);
            _listOfGameState.Add(_stateOptions);
            _listOfGameState.Add(_stateHelps);
            _listOfGameState.Add(_stateIntro);
        }

        public override void EnterState()
        {
            
        }

        public override void UpdateState(GameTime gameTime)
        {
            _menubg.Update(gameTime);
            _listOfGameState[_currentState].UpdateState(gameTime);
        }

        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            _menubg.Draw(gameTime, sb);
            _listOfGameState[_currentState].DrawState(gameTime, sb);
        }

        public override void ExitState()
        {
            
        }
    }
}

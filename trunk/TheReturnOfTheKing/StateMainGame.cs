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
    public class StateMainGame : GameState
    {
        Map _map;   
        List<Monster> _listMonsters = new List<Monster>();
        List<MapObstacle> _listObstacle = new List<MapObstacle>();
        List<Portral> _listPortral = new List<Portral>();
        PlayerCharacter _char;
        Frog _frog;       
        
        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            base.InitState(objectManagerArray, owner);
            _map = (Map)objectManagerArray[1].CreateObject(0);
            GlobalVariables.MapCollisionDim = _map.CollisionDim;
            _char = (PlayerCharacter)objectManagerArray[0].CreateObject(0);
            _char.SetMap(_map);            
            _listMonsters = _map.InitMonsterList((MonsterManager)objectManagerArray[2],@"Data\Map\map01\map01_monster.xml");
            _frog = new Frog();
            _frog.Init(Owner.Content) ;
            _frog.InitProcessBar((ProcessBarManager)objectManagerArray[3]);
            _frog.SetCharacter(_char);
            _listPortral = _map.InitPortralList((PortralManger)objectManagerArray[4], @"Data\Map\map01\map01_portral.xml");
        }

        public override void EnterState()
        {
            base.EnterState();            
        }

        public override void UpdateState(GameTime gameTime)
        {
            base.UpdateState(gameTime);
            _map.Update(gameTime);            
            MouseState ms = Mouse.GetState();

            int _checkMonster = -1; // Kiem tra chuot co dang chi len quai vat hay khong
            for (int i = 0; i < _listMonsters.Count; ++i)
            {
                _listMonsters[i].Update(gameTime);
                if (_listMonsters[i].IsDyed || _listMonsters[i].IsDying)
                    continue;
                if (_char != null && Math.Sqrt(Math.Pow(_listMonsters[i].X - _char.X, 2) - Math.Pow(_listMonsters[i].Y - _char.Y, 2)) < _listMonsters[i].Sight)
                    _listMonsters[i].Target = _char;
                   
                if (_listMonsters[i].FocusRect.Contains(new Point((int)GlobalVariables.GameCursor.X, (int)GlobalVariables.GameCursor.Y)))
                    _checkMonster = i;
            }
            if (_checkMonster != -1)
                GlobalVariables.GameCursor.IsAttack = true;
            else
                GlobalVariables.GameCursor.IsIdle = true;

            if (ms.LeftButton == ButtonState.Pressed)
            {
                if (ms.X < GlobalVariables.ScreenWidth && ms.Y < GlobalVariables.ScreenHeight && ms.X >= 0 && ms.Y >= 0)
                {
                    if (!GlobalVariables.GameCursor.IsAttack)
                    {
                        if (_char.Target != null)
                        {
                            _char.Target = null;
                            _char.IsAttacking = false;
                            _char.DestPoint = new Point((int)_char.X, (int)_char.Y);
                            _char.CellToMove = new List<Point>();
                        }
                        Point newCell = _map.PointToCell(new Point((int)GlobalVariables.GameCursor.X, (int)GlobalVariables.GameCursor.Y));
                        if (_map.Matrix[newCell.Y][newCell.X] == true)
                            _char.CellToMove = Utility.FindPath(_map.Matrix, _map.PointToCell(new Point((int)_char.X, (int)_char.Y)), newCell);
                        
                    }
                    else
                    {
                        _char.Target = _listMonsters[_checkMonster];                        
                    }
                }
            }
            
            GlobalVariables.GameCursor.Update(gameTime);
   
            _char.Update(gameTime);
            _frog.Update(gameTime);
            if (_char.IsDyed)
            {
                int nObjectManager = 4;
                GameObjectManager[] objectManegerArray = new GameObjectManager[nObjectManager];
                objectManegerArray[0] = new ButtonManger(@"./Data/XML/buttonmanager.xml");
                objectManegerArray[1] = new BackgroundManager(@"./Data/XML/menubg.xml");
                objectManegerArray[2] = new MenuFrameManager(@"./Data/XML/menuframe.xml");
                objectManegerArray[3] = new GameTitleManager(@"./Data/XML/gametitle.xml");

                GlobalVariables.dX = 0;
                GlobalVariables.dY = 0;

                Owner.GameState.ExitState();
                Owner.GameState = new StateLoading();
                Owner.GameState.InitState(null, this.Owner);
                ((StateLoading)Owner.GameState).GetDataLoading(this.Owner.Content, @"./Data/XML/loadingtomenu.xml", objectManegerArray, typeof(StateMenu));
                Owner.GameState.EnterState();
                Owner.ResetElapsedTime();
            }

            for (int i = 0; i < _listPortral.Count; ++i)
                _listPortral[i].Update(gameTime);
        }

        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            base.DrawState(gameTime, sb);
            _map.Draw(gameTime, sb);
            for (int i = 0; i < _listPortral.Count; ++i)
                _listPortral[i].Draw(gameTime, sb);
            for (int i = 0; i < _listMonsters.Count; ++i)
            {
                if (_listMonsters[i].Y < _char.Y && !_listMonsters[i].IsDyed)
                    _listMonsters[i].Draw(gameTime, sb);
            }
            _char.Draw(gameTime, sb);
            for (int i = 0; i < _listMonsters.Count; ++i)
            {
                if (_listMonsters[i].Y >= _char.Y && !_listMonsters[i].IsDyed)
                    _listMonsters[i].Draw(gameTime, sb);
            }

            _frog.Draw(gameTime, sb);

            GlobalVariables.GameCursor.Draw(gameTime, sb);

        }

        public override void ExitState()
        {
            base.ExitState();
        }

        
    }
}

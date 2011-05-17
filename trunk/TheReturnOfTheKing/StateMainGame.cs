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
        public Map _map;
        public List<Monster> _listMonsters = new List<Monster>();
        public List<Portral> _listPortral = new List<Portral>();
        public List<MapObstacle> _listObstacle = new List<MapObstacle>();
        public PlayerCharacter _char;
        public Frog _frog;
        public GameObjectManager[] _objectManagerArray;
        public List<VisibleGameEntity> _listToDraw;

        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            base.InitState(objectManagerArray, owner);
            _map = (Map)objectManagerArray[1].CreateObject(0);
            GlobalVariables.MapCollisionDim = _map.CollisionDim;
            _char = (PlayerCharacter)objectManagerArray[0].CreateObject(0);
            _char.SetMap(_map);            
            _listMonsters = _map.InitMonsterList((MonsterManager)objectManagerArray[2],@"Data\Map\map01\map01_monster.xml");
            _frog = new Frog();
            _frog.Init(Owner.Content);
            _frog.InitProcessBar((ProcessBarManager)objectManagerArray[3]);
            _frog.SetCharacter(_char);
            _listPortral = _map.InitPortralList((PortralManager)objectManagerArray[4], @"Data\Map\map01\map01_portral.xml");
            _listObstacle = _map.InitObstacle((MapObstacleManager)objectManagerArray[5], @"Data\Map\map01\map01_obstacle.xml");
            _objectManagerArray = objectManagerArray;
            _listToDraw = new List<VisibleGameEntity>();
        }

        public override void EnterState()
        {
            base.EnterState();

        }
        
        public override void UpdateState(GameTime gameTime)
        {
            base.UpdateState(gameTime);

            float minX = Math.Abs(GlobalVariables.dX);
            float maxX = Math.Abs(GlobalVariables.dX) + GlobalVariables.ScreenWidth;
            float minY = Math.Abs(GlobalVariables.dY);
            float maxY = Math.Abs(GlobalVariables.dY) + GlobalVariables.ScreenHeight;
            MouseState ms = Mouse.GetState();

            _listToDraw.Clear();

            _map.Update(gameTime); 

            int _checkMonster = -1; // Kiem tra chuot co dang chi len quai vat hay khong
            for (int i = 0; i < _listMonsters.Count; ++i)
            {
                if (minX < _listMonsters[i].X && _listMonsters[i].X < maxX && minY < _listMonsters[i].Y && _listMonsters[i].Y < maxY)
                {
                    _listMonsters[i].Update(gameTime);
                    _listToDraw.Add(_listMonsters[i]);
                    if (_listMonsters[i].IsDyed || _listMonsters[i].IsDying)
                        continue;
                    if (_char != null && Math.Sqrt(Math.Pow(_listMonsters[i].X - _char.X, 2) - Math.Pow(_listMonsters[i].Y - _char.Y, 2)) < _listMonsters[i].Sight)
                        _listMonsters[i].Target = _char;

                    if (_listMonsters[i].FocusRect.Contains(new Point((int)GlobalVariables.GameCursor.X, (int)GlobalVariables.GameCursor.Y)))
                        _checkMonster = i;
                }
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
            _listToDraw.Add(_char);
            _frog.Update(gameTime);

            if (_char.IsDyed)
            {
                int nObjectManager = 4;
                GameObjectManager[] objectManagerArray = new GameObjectManager[nObjectManager];
                objectManagerArray[0] = new ButtonManger(@"./Data/XML/buttonmanager.xml");
                objectManagerArray[1] = new BackgroundManager(@"./Data/XML/menubg.xml");
                objectManagerArray[2] = new MenuFrameManager(@"./Data/XML/menuframe.xml");
                objectManagerArray[3] = new GameTitleManager(@"./Data/XML/gametitle.xml");

                GlobalVariables.dX = 0;
                GlobalVariables.dY = 0;

                Owner.GameState.ExitState();
                Owner.GameState = new StateLoading();
                Owner.GameState.InitState(null, this.Owner);
                ((StateLoading)Owner.GameState).GetDataLoading(this.Owner.Content, @"./Data/XML/loadingtomenu.xml", objectManagerArray, typeof(StateMenu));
                Owner.GameState.EnterState();
                Owner.ResetElapsedTime();
            }

            

            for (int i = 0; i < _listObstacle.Count; ++i)
            {
                if (minX < _listObstacle[i].X && _listObstacle[i].X < maxX && minY < _listObstacle[i].Y && _listObstacle[i].Y < maxY)
                {
                    _listObstacle[i].Update(gameTime);
                    _listToDraw.Add(_listObstacle[i]);
                }
            }
            for (int i = 0; i < _listPortral.Count; ++i)
            {
                if (minX < _listPortral[i].X && _listPortral[i].X < maxX && minY < _listPortral[i].Y && _listPortral[i].Y < maxY)
                {
                    _listPortral[i].Update(gameTime);
                    _listToDraw.Add(_listPortral[i]);
                }
                if (_listPortral[i].IsCollisionWith(_char))
                {
                    _listPortral[i].GoToDestination(this);
                    break;
                }
            }
        }

        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            base.DrawState(gameTime, sb);

            int minY = (int)Math.Abs(GlobalVariables.dY);
            int maxY = (int)(Math.Abs(GlobalVariables.dY) + GlobalVariables.ScreenHeight);

            _map.Draw(gameTime, sb);

            for (int y = minY; y < maxY; y += 32)
            {
//                 for (int i = 0; i < _listPortral.Count; ++i)
//                 {
//                     if (y < _listPortral[i].Y && _listPortral[i].Y <= y + 32)
//                         _listPortral[i].Draw(gameTime, sb);
//                 }
// 
//                 for (int i = 0; i < _listMonsters.Count; ++i)
//                 {
//                     if (y < _listMonsters[i].Y && _listMonsters[i].Y <= y + 32)
//                         _listMonsters[i].Draw(gameTime, sb);
//                 }
// 
//                 for (int i = 0; i < _listObstacle.Count; ++i)
//                 {
//                     if (y < _listObstacle[i].Y && _listObstacle[i].Y <= y + 32)
//                         _listObstacle[i].Draw(gameTime, sb);
//                 }
// 
//                 if (y < _char.Y && _char.Y <= y + 32)
//                     _char.Draw(gameTime, sb);

                for (int i = 0; i < _listToDraw.Count; ++i)
                {
                    if (y < _listToDraw[i].Y && _listToDraw[i].Y <= y + 32)
                        _listToDraw[i].Draw(gameTime, sb);
                }
            }

//             for (int i = 0; i < _listPortral.Count; ++i)
//                 if (minX < _listPortral[i].X && _listPortral[i].X < maxX && minY < _listPortral[i].Y && _listPortral[i].Y < maxY)
//                         _listPortral[i].Draw(gameTime, sb);
//             
//             for (int i = 0; i < _listObstacle.Count; ++i)
//             {
//                 _listObstacle[i].Draw(gameTime, sb);
//             }
//             for (int i = 0; i < _listMonsters.Count; ++i)
//             {
//                 if (_listMonsters[i].Y < _char.Y && !_listMonsters[i].IsDyed)
//                     _listMonsters[i].Draw(gameTime, sb);
//             }
// 
//             _char.Draw(gameTime, sb);
// 
//             for (int i = 0; i < _listMonsters.Count; ++i)
//             {
//                 if (_listMonsters[i].Y >= _char.Y && !_listMonsters[i].IsDyed)
//                     _listMonsters[i].Draw(gameTime, sb);
//             }

            //_frog.Draw(gameTime, sb);

            GlobalVariables.GameCursor.Draw(gameTime, sb);

        }

        public override void ExitState()
        {
            base.ExitState();
        }

        
    }
}

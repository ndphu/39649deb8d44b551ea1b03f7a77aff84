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
        public Fog _frog;
        public GameObjectManager[] _objectManagerArray;
        public List<VisibleGameEntity> _listToDraw;
        public List<Projectile> _listProjectile = new List<Projectile>();
        public HealthBar _healthBar;
        public SkillBoard _skillBoard;
        public DisplayMessageLayer _displayMessageLayer;
        public LHSkillSelectionFrame _lhSkillSelectionFrame;
        public RHSkillSelectionFrame _rhSkillSelectionFrame;

        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            base.InitState(objectManagerArray, owner);
            _map = (Map)objectManagerArray[1].CreateObject(0);
            GlobalVariables.MapCollisionDim = _map.CollisionDim;
            _char = (PlayerCharacter)objectManagerArray[0].CreateObject(0);
            _char.SetMap(_map);
            _char.StateOwner = this;
            
            _map.Owner = this;
            _listMonsters = _map.InitMonsterList((MonsterManager)objectManagerArray[2],@"Data\Map\map01\map01_monster.xml");

            _frog = new Fog();
            _frog.Init(owner.Content);
            _frog.SetCharacter(_char);

            _displayMessageLayer = new DisplayMessageLayer();

            //Phần ???---------------------------------------------------------------------------
            _listPortral = _map.InitPortralList((PortralManager)objectManagerArray[4], @"Data\Map\map01\map01_portral.xml");
            _listObstacle = _map.InitObstacle((MapObstacleManager)objectManagerArray[5], @"Data\Map\map01\map01_obstacle.xml");
            _objectManagerArray = objectManagerArray;
            _listToDraw = new List<VisibleGameEntity>();

            _char.InitSkill();

            //Phần healthbar--------------------------------------------------------------------
            _healthBar = new HealthBar();
            _healthBar.SetCharacter(_char);

            List<GameObjectManager> _resourcesForHealthbar = new List<GameObjectManager>();
            _resourcesForHealthbar.Add(objectManagerArray[8]);
            _resourcesForHealthbar.Add(objectManagerArray[9]);
            _resourcesForHealthbar.Add(objectManagerArray[10]);
            _healthBar.GetResources(_resourcesForHealthbar);

            //Phần SkillBoard------------------------------------------------------------------
            _skillBoard = new SkillBoard();
            _skillBoard.SetCharacter(_char);

            List<GameObjectManager> _resourcesForSkillBoard = new List<GameObjectManager>();
            _resourcesForSkillBoard.Add(objectManagerArray[8]);
            _resourcesForSkillBoard.Add(objectManagerArray[10]);
            _resourcesForSkillBoard.Add(objectManagerArray[11]);
            _skillBoard.GetResources(_resourcesForSkillBoard);

            //Phần Left-hand selection frame
            _lhSkillSelectionFrame = new LHSkillSelectionFrame();
            _lhSkillSelectionFrame.SetCharacter(_char);

            List<GameObjectManager> _resourceForLHSSelectionFrame = new List<GameObjectManager>();
            _resourceForLHSSelectionFrame.Add(_objectManagerArray[8]);
            _resourceForLHSSelectionFrame.Add(_objectManagerArray[10]);
            _lhSkillSelectionFrame.GetResources(_resourceForLHSSelectionFrame);

            //Phần Right-hand selection frame
            _rhSkillSelectionFrame = new RHSkillSelectionFrame();
            _rhSkillSelectionFrame.SetCharacter(_char);
            _rhSkillSelectionFrame.GetResources(_resourceForLHSSelectionFrame);
        }

        public override void EnterState()
        {
            base.EnterState();
        }
        
        public override void UpdateState(GameTime gameTime)
        {
            base.UpdateState(gameTime);
            if (!GlobalVariables.IsPauseGame)
            {               

                float minX = Math.Abs(GlobalVariables.dX);
                float maxX = Math.Abs(GlobalVariables.dX) + GlobalVariables.ScreenWidth;
                float minY = Math.Abs(GlobalVariables.dY);
                float maxY = Math.Abs(GlobalVariables.dY) + GlobalVariables.ScreenHeight;
                GlobalVariables.GameCursor.IsIdle = true;
                GlobalVariables.AlreadyUseLeftMouse = false;
                GlobalVariables.AlreadyUseRightMouse = false;

                _healthBar.Update(gameTime);
                _lhSkillSelectionFrame.Update(gameTime);
                _rhSkillSelectionFrame.Update(gameTime);
                _skillBoard.Update(gameTime);

                _listToDraw.Clear();
                _map.Update(gameTime);


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
                }

                for (int i = 0; i < _listMonsters.Count; ++i)
                {
                    if (minX < _listMonsters[i].X && _listMonsters[i].X < maxX && minY < _listMonsters[i].Y && _listMonsters[i].Y < maxY)
                    {
                        _listMonsters[i].Update(gameTime);
                        _listToDraw.Add(_listMonsters[i]);

                        if (_listMonsters[i].IsDyed)
                        {
                            _listMonsters.Remove(_listMonsters[i]);
                        }
                    }
                }
                for (int i = 0; i < _listProjectile.Count; ++i)
                {
                    _listProjectile[i].Update(gameTime);
                    if ((_listProjectile[i]._sprite[0].Itexture2D == _listProjectile[i]._sprite[0].Ntexture2D - 1 && _listProjectile[i].IsRemoveAfterEffect) || (_listProjectile[i].LifeTime <= 0 && !_listProjectile[i].IsRemoveAfterEffect))
                        _listProjectile.Remove(_listProjectile[i]);
                }
                _char.Update(gameTime);
                _listToDraw.Add(_char);



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

                _displayMessageLayer.Update(gameTime);
                _frog.Update(gameTime);
            }
            
            if (GlobalVariables.CurrentKeyboardState.IsKeyDown(Keys.N))
                GlobalVariables.IsPauseGame = true;
            if (GlobalVariables.CurrentKeyboardState.IsKeyDown(Keys.M))
                GlobalVariables.IsPauseGame = false;
        }
        
        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            base.DrawState(gameTime, sb);

            int minY = (int)Math.Abs(GlobalVariables.dY);
            int maxY = (int)(Math.Abs(GlobalVariables.dY) + GlobalVariables.ScreenHeight);

            _map.Draw(gameTime, sb);

            for (int i = 0; i < _listProjectile.Count; ++i)
            {
                _listProjectile[i].Draw(gameTime, sb);
            }

            for (int y = minY; y < maxY; y += 16)
            {
                for (int i = 0; i < _listToDraw.Count; ++i)
                {
                    if (y < _listToDraw[i].Y && _listToDraw[i].Y <= y + 32)
                        _listToDraw[i].Draw(gameTime, sb);
                }
            }
            _displayMessageLayer.Draw(gameTime, sb);
            _frog.Draw(gameTime, sb);
            GlobalVariables.GameCursor.Draw(gameTime, sb);
            _skillBoard.Draw(gameTime, sb);
            _rhSkillSelectionFrame.Draw(gameTime, sb);
            _lhSkillSelectionFrame.Draw(gameTime, sb);
            _healthBar.Draw(gameTime, sb);
            if (GlobalVariables.IsPauseGame)
            {
                Texture2D texture = Owner.Content.Load<Texture2D>("manhinhmo");
                sb.Draw(texture, new Vector2(0, 0), Color.White);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}

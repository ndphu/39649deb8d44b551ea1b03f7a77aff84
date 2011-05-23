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
        public List<Projectile> _listProjectile = new List<Projectile>();

        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            base.InitState(objectManagerArray, owner);
            _map = (Map)objectManagerArray[1].CreateObject(0);
            GlobalVariables.MapCollisionDim = _map.CollisionDim;
            _char = (PlayerCharacter)objectManagerArray[0].CreateObject(0);
            _char.SetMap(_map);
            _char.Owner = this;
            
            _map.Owner = this;
            _listMonsters = _map.InitMonsterList((MonsterManager)objectManagerArray[2],@"Data\Map\map01\map01_monster.xml");

            _frog = new Frog();
            _frog.Init(owner.Content);
            _frog.SetCharacter(_char);
            HealthBar _temp = (HealthBar)objectManagerArray[8].CreateObject(0);
            _temp.MainFrame = new HealthBarMainFrame((GameFrame)objectManagerArray[9].CreateObject(0));
            _temp.BloodProcessbar = (ProcessBar)objectManagerArray[10].CreateObject(0);
            _temp.ManaProcessbar = (ProcessBar)objectManagerArray[10].CreateObject(1);
            _temp.Owner = (Frog)_frog;

            StandingButton _tempLeftSkill = (StandingButton)objectManagerArray[11].CreateObject(0);
            _tempLeftSkill.Owner = _temp;
            _temp.LeftSkillButon = new LeftSkillButton(_tempLeftSkill);

            StandingButton _tempRightSkill = (StandingButton)objectManagerArray[11].CreateObject(1);
            _tempRightSkill.Owner = _temp;
            _temp.RightSkillButton = new RightSkillButton(_tempRightSkill);

            StandingButton _tempLeftCommandButton = (StandingButton)objectManagerArray[11].CreateObject(2);
            _tempLeftCommandButton.Owner = _temp;
            _temp.LeftCommandButton = new LeftCommandButton(_tempLeftCommandButton);

            StandingButton _tempRightCommandButton = (StandingButton)objectManagerArray[11].CreateObject(3);
            _tempRightCommandButton.Owner = _temp;
            _temp.RightCommandButton = new RightCommandButton(_tempRightCommandButton);

            _frog.HealthBar = new HealthBar(_temp);

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
            GlobalVariables.GameCursor.IsIdle = true;
            GlobalVariables.AlreadyUseLeftMouse = false;
            GlobalVariables.AlreadyUseRightMouse = false;
            
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
                if (_listProjectile[i]._sprite[0].Itexture2D == _listProjectile[i]._sprite[0].Ntexture2D - 1)
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

            _frog.Update(gameTime);
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

            for (int y = minY; y < maxY; y += 32)
            {
                for (int i = 0; i < _listToDraw.Count; ++i)
                {
                    if (y < _listToDraw[i].Y && _listToDraw[i].Y <= y + 32)
                        _listToDraw[i].Draw(gameTime, sb);
                }
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

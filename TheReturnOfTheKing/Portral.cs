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
    public class Portral : VisibleGameEntity
    {
        public override VisibleGameObject Clone()
        {
            GameSprite[] _spriteTemp = new GameSprite[_nsprite];
            for (int i = 0; i < _nsprite; ++i)
                _spriteTemp[i] = _sprite[i].Clone();
            return new Portral
            {
                _nsprite = this._nsprite,
                _sprite = _spriteTemp,
                Height = this.Height,
                IsMouseHover = this.IsMouseHover,
                Rect = this.Rect,
                Width = this.Width,
                X = this.X,
                Y = this.Y,
                Destination = this.Destination,
            };
        }
        
        public override float X
        {
            get
            {
                return base.X;
            }
            set
            {
                base.X = value;
                for (int i = 0; i < _nsprite; ++i)
                    _sprite[i].X = value;
                CollisionRect = new Rectangle((int)X, (int)Y, (int)GlobalVariables.MapCollisionDim, (int)GlobalVariables.MapCollisionDim);
            }
        }

        public override float Y
        {
            get
            {
                return base.Y;
            }
            set
            {
                base.Y = value;
                for (int i = 0; i < _nsprite; ++i)
                    _sprite[i].Y = value;
                CollisionRect = new Rectangle((int)X, (int)Y, (int)GlobalVariables.MapCollisionDim, (int)GlobalVariables.MapCollisionDim);
            }
        }

        string _destination;

        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public void GoToDestination(StateMainGame mg)
        {
            switch (Destination)
            {
                case "menu":
                    {
                        int nObjectManager = 4;
                        GameObjectManager[] objectManegerArray = new GameObjectManager[nObjectManager];
                        objectManegerArray[0] = new ButtonManger(@"./Data/XML/buttonmanager.xml");
                        objectManegerArray[1] = new BackgroundManager(@"./Data/XML/menubg.xml");
                        objectManegerArray[2] = new MenuFrameManager(@"./Data/XML/menuframe.xml");
                        objectManegerArray[3] = new GameTitleManager(@"./Data/XML/gametitle.xml");

                        GlobalVariables.dX = 0;
                        GlobalVariables.dY = 0;

                        mg.Owner.GameState.ExitState();
                        mg.Owner.GameState = new StateLoading();
                        mg.Owner.GameState.InitState(null, mg.Owner);
                        ((StateLoading)mg.Owner.GameState).GetDataLoading(mg.Owner.Content, @"./Data/XML/loadingtomenu.xml", objectManegerArray, typeof(StateMenu));
                        mg.Owner.GameState.EnterState();
                        mg.Owner.ResetElapsedTime();
                    }
                    break;
                case "map01":
                    {
                        mg._map = (Map)mg._objectManagerArray[1].CreateObject(0);
                        mg._char.SetMap(mg._map);
                        mg._listMonsters = mg._map.InitMonsterList((MonsterManager)mg._objectManagerArray[2], @"Data\Map\map01\map01_monster.xml");
                        mg._frog.SetCharacter(mg._char);
                        mg._listPortral = mg._map.InitPortralList((PortralManger)mg._objectManagerArray[4], @"Data\Map\map01\map01_portral.xml");
                    }
                    break;
                case "map02":
                    {
                        mg._map = (Map)mg._objectManagerArray[1].CreateObject(1);
                        mg._char.SetMap(mg._map);
                        mg._listMonsters = mg._map.InitMonsterList((MonsterManager)mg._objectManagerArray[2], @"Data\Map\map02\map02_monster.xml");
                        mg._frog.SetCharacter(mg._char);
                        mg._listPortral = mg._map.InitPortralList((PortralManger)mg._objectManagerArray[4], @"Data\Map\map02\map02_portral.xml");
                    }
                    break;
            }
        }
    }
}

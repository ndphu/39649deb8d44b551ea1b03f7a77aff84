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
                DestX = this.DestX,
                DestY = this.DestY,
            };
        }

        StateMainGame _owner;

        public StateMainGame Owner
        {
            get { return _owner; }
            set { _owner = value; }
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
        /// <summary>
        /// Map se chuyen den
        /// </summary>
        string _destination;

        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        /// <summary>
        /// Vi tri X tren map moi
        /// </summary>
        int _destX;

        public int DestX
        {
            get { return _destX; }
            set { _destX = value; }
        }
        /// <summary>
        /// Vi tri Y tren map moi
        /// </summary>
        int _destY;

        public int DestY
        {
            get { return _destY; }
            set { _destY = value; }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (this.IsCollisionWith(Owner._char))
                this.GoToDestination(Owner);
        }

        public void GoToDestination(StateMainGame mg)
        {
            switch (Destination)
            {
                case "menu":
                    {
                        int nObjectManager = 4;
                        GameObjectManager[] objectManagerArray = new GameObjectManager[nObjectManager];
                        objectManagerArray[0] = new ButtonManger(@"./Data/XML/buttonmanager.xml");
                        objectManagerArray[1] = new BackgroundManager(@"./Data/XML/menubg.xml");
                        objectManagerArray[2] = new MenuFrameManager(@"./Data/XML/menuframe.xml");
                        objectManagerArray[3] = new GameTitleManager(@"./Data/XML/gametitle.xml");

                        GlobalVariables.dX = 0;
                        GlobalVariables.dY = 0;

                        mg.Owner.GameState.ExitState();
                        mg.Owner.GameState = new StateLoading();
                        mg.Owner.GameState.InitState(null, mg.Owner);
                        ((StateLoading)mg.Owner.GameState).GetDataLoading(mg.Owner.Content, @"./Data/XML/loadingtomenu.xml", objectManagerArray, typeof(StateMenu));
                        mg.Owner.GameState.EnterState();
                        mg.Owner.ResetElapsedTime();
                    }
                    break;
                case "map01":
                    {
                        mg._map = (Map)mg._objectManagerArray[1].CreateObject(0);
                        mg._map.Owner = mg;
                        mg._char.SetMap(mg._map);
                        mg._listMonsters = mg._map.InitMonsterList((MonsterManager)mg._objectManagerArray[2], @"Data\Map\map01\map01_monster.xml");
                        mg._frog.SetCharacter(mg._char);
                       
                        mg._listPortral = mg._map.InitPortralList((PortralManager)mg._objectManagerArray[4], @"Data\Map\map01\map01_portral.xml");
                        mg._char.X = DestX * GlobalVariables.MapCollisionDim;
                        mg._char.Y = DestY * GlobalVariables.MapCollisionDim;
                        GlobalVariables.dX = Math.Min(-mg._char.X + GlobalVariables.ScreenWidth / 2, 0);
                        GlobalVariables.dY = Math.Min(-mg._char.Y + GlobalVariables.ScreenHeight / 2, 0);
                        mg._char.DestPoint = new Point((int)mg._char.X, (int)mg._char.Y);   
                    }
                    break;
                case "map02":
                    {
                        mg._map = (Map)mg._objectManagerArray[1].CreateObject(1);
                        mg._map.Owner = mg;
                        mg._char.SetMap(mg._map);
                        mg._listMonsters = mg._map.InitMonsterList((MonsterManager)mg._objectManagerArray[2], @"Data\Map\map02\map02_monster.xml");
                        mg._frog.SetCharacter(mg._char);
                       
                        mg._listPortral = mg._map.InitPortralList((PortralManager)mg._objectManagerArray[4], @"Data\Map\map02\map02_portral.xml");
                        mg._char.X = DestX * GlobalVariables.MapCollisionDim;
                        mg._char.Y = DestY * GlobalVariables.MapCollisionDim;
                        GlobalVariables.dX = Math.Min(-mg._char.X + GlobalVariables.ScreenWidth / 2, 0);
                        GlobalVariables.dY = Math.Min(-mg._char.Y + GlobalVariables.ScreenHeight / 2, 0);
                        mg._char.DestPoint = new Point((int)mg._char.X, (int)mg._char.Y);   
                    }
                    break;
            }
        }
    }
}

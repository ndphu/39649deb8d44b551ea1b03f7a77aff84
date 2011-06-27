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
    public class Map : VisibleGameEntity
    {
        StateMainGame _owner;

        public StateMainGame Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// Số cột
        /// </summary>
        int _cols;

        public int Cols
        {
            get { return _cols; }
            set { _cols = value; }
        }
        /// <summary>
        /// Số dòng
        /// </summary>
        int _rows;

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }
        /// <summary>
        /// Kích thướt 1 ô logic
        /// </summary>
        int _collisionDim;

        public int CollisionDim
        {
            get { return _collisionDim; }
            set { _collisionDim = value; }
        }
        /// <summary>
        /// Điểm khởi đầu cho nhân vật (X)
        /// </summary>
        int _startPointX;

        public int StartPointX
        {
            get { return _startPointX; }
            set { _startPointX = value; }
        }
        /// <summary>
        /// Điểm khởi đầu cho nhân vật (Y)
        /// </summary>
        int _startPointY;

        public int StartPointY
        {
            get { return _startPointY; }
            set { _startPointY = value; }
        }

        int _curCol;
        int _curRow;
        bool _nextCol; // co ve them manh tiep theo ben phai hok
        bool _nextRow; // co ve them manh tiep theo o duoi hok

        /// <summary>
        /// Số dòng trên 1 màn hình
        /// </summary>
        int _rpF;

        public int RpF
        {
            get { return _rpF; }
            set { _rpF = value; }
        }
        /// <summary>
        /// Số cột trên một màn hình
        /// </summary>
        int _cpF;

        public int CpF
        {
            get { return _cpF; }
            set { _cpF = value; }
        }

        int _pieceWidth;

        public int PieceWidth
        {
            get { return _pieceWidth; }
            set { _pieceWidth = value; }
        }

        int _pieceHeight;

        public int PieceHeight
        {
            get { return _pieceHeight; }
            set { _pieceHeight = value; }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            //base.Draw(gameTime, sb);
            _sprite[_curRow * _cols + _curCol].Draw(gameTime, sb);            
            for (int i = 0; i <= _cpF; ++i)
                for (int j = 0; j <= _rpF; ++j)
                {
                    if ((_curRow + j)* _cols + _curCol + i < _nsprite)
                        _sprite[(_curRow + j) * _cols + _curCol + i].Draw(gameTime, sb);               
                }
            
        }

        public override void Init(ContentManager content)
        {
            base.Init(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _curCol = (int)Math.Abs(GlobalVariables.dX) / _sprite[0].Texture2D[0].Width;
            _curRow = (int)Math.Abs(GlobalVariables.dY) / _sprite[0].Texture2D[0].Height;
            _nextCol = (Math.Abs(GlobalVariables.dX) % _sprite[0].Texture2D[0].Width) != 0;
            _nextRow = (Math.Abs(GlobalVariables.dY) % _sprite[0].Texture2D[0].Height) != 0;

        }
        string _mapName;

        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }
        public override VisibleGameObject Clone()
        {
            return new Map
            {
                _nsprite = this._nsprite,
                _sprite = this._sprite,
                X = this.X,
                Y = this.Y,
                _height = this.Height,
                _width = this.Width,
                _cols = this._cols,
                _rows = this._rows,
                _curCol = this._curCol,
                _curRow = this._curRow,
                _nextCol = this._nextCol,
                _nextRow = this._nextRow,
                _rpF = this._rpF,
                _cpF = this._cpF,
                _matrix = this._matrix,
                _collisionDim = this._collisionDim,
                _startPointX = this._startPointX,
                _startPointY = this._startPointY,
                _mapName = this._mapName,
                _pieceHeight = this._pieceHeight,
                _pieceWidth = this._pieceWidth,
            };
        }
        /// <summary>
        /// Ma trận tương tác
        /// </summary>
        List<List<bool>> _matrix = new List<List<bool>>();

        public List<List<bool>> Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

        public bool IsCollision(Rectangle rect)
        {
            /*
            int start_X = rect.X;
            int start_Y = rect.Y;
            int end_X = Math.Min(start_X + rect.Width, GlobalVariables.ScreenWidth);
            int end_Y = Math.Min(start_Y + rect.Height, GlobalVariables.ScreenHeight);

            for (int i = start_X; i < end_X; ++i)
                for (int j = start_Y; j < end_Y; ++j)
                {
                    if (_matrix[j][i] == true)
                        return true;
                }
            */
            return false;
        }
        /// <summary>
        /// Hàm chuyển từ tọa độ thực sang tọa độ tương đối
        /// </summary>
        /// <param name="p">tọa độ thực</param>
        /// <returns>tọa độ tương đối</returns>
        public Point PointToCell(Point p)
        {
            if (p.X < 0 || p.Y < 0 || p.X >= _width || p.Y >= Height)
                return new Point(0, 0);
            int x = p.X / _collisionDim;
            int y = p.Y / _collisionDim;
            return new Point(x, y);
        }
        /// <summary>
        /// Hàm chuyển từ tọa độ tương đối trên map sang tọa độ thực
        /// </summary>
        /// <param name="p">tọa độ tương đối</param>
        /// <returns>tọa độ thực</returns>
        public Point CellToPoint(Point p)
        {
            return new Point(p.X * _collisionDim, p.Y * _collisionDim);
        }

        /// <summary>
        /// Lấy danh sách quái vật
        /// </summary>
        /// <returns>Mảng các quái vật</returns>
        public List<Monster> InitMonsterList(MonsterManager monsterManager, string xmlMonsterFile)
        {
            List<Monster> ret = new List<Monster>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlMonsterFile);
            XmlNodeList Monsters = doc.SelectNodes(@"//Monster");
            for (int i = 0; i < Monsters.Count; ++i)
            {
                Monster mst = (Monster)monsterManager.CreateObject(int.Parse(Monsters[i].SelectSingleNode(@"Type").InnerText));
                ret.Add(mst);
                ret[i].X = int.Parse(Monsters[i].SelectSingleNode(@"X").InnerText) * GlobalVariables.MapCollisionDim;
                ret[i].Y = int.Parse(Monsters[i].SelectSingleNode(@"Y").InnerText) * GlobalVariables.MapCollisionDim;
                ret[i].DestPoint = new Point((int)ret[i].X, (int)ret[i].Y);
                ret[i].CellToMove = new List<Point>();
                ret[i].SetMap(this);
                ret[i].StateOwner = this.Owner;
                try
                {
                    if (bool.Parse(Monsters[i].SelectSingleNode(@"LastBoss").InnerText))
                        GlobalVariables.LastBoss = ret[i];
                }
                catch
                {
                }
            }
            return ret;
        }

        public List<Portral> InitPortralList(PortralManager portralManager, string xmlPortralFile)
        {
            List<Portral> ret = new List<Portral>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPortralFile);
            XmlNodeList Portrals = doc.SelectNodes(@"//Portral");
            for (int i = 0; i < Portrals.Count; ++i)
            {
                Portral pt = (Portral)portralManager.CreateObject(int.Parse(Portrals[i].SelectSingleNode(@"Type").InnerText));
                ret.Add(pt);
                ret[i].X = int.Parse(Portrals[i].SelectSingleNode(@"X").InnerText) * GlobalVariables.MapCollisionDim;
                ret[i].Y = int.Parse(Portrals[i].SelectSingleNode(@"Y").InnerText) * GlobalVariables.MapCollisionDim;
                ret[i].Destination = Portrals[i].SelectSingleNode(@"Destination").InnerText;
                ret[i].DestX = int.Parse(Portrals[i].SelectSingleNode(@"DestinationX").InnerText);
                ret[i].DestY = int.Parse(Portrals[i].SelectSingleNode(@"DestinationY").InnerText);
                ret[i].Owner = this.Owner;
            }
            return ret;
        }

        internal List<MapObstacle> InitObstacle(MapObstacleManager mapObstacleManager, string xmlMapObstacleFile)
        {
            List<MapObstacle> ret = new List<MapObstacle>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlMapObstacleFile);
            XmlNodeList MapObstacles = doc.SelectNodes(@"//MapObstacle");
            for (int i = 0; i < MapObstacles.Count; ++i)
            {
                MapObstacle pt = (MapObstacle)mapObstacleManager.CreateObject(int.Parse(MapObstacles[i].SelectSingleNode(@"Type").InnerText));
                ret.Add(pt);
                int XLogic = int.Parse(MapObstacles[i].SelectSingleNode(@"X").InnerText);
                int YLogic = int.Parse(MapObstacles[i].SelectSingleNode(@"Y").InnerText);
                ret[i].X = XLogic * GlobalVariables.MapCollisionDim;
                ret[i].Y = YLogic * GlobalVariables.MapCollisionDim;
                for (int j = YLogic + ret[i].StartObstacleY; j < ret[i].ObstacleHeight + YLogic + ret[i].StartObstacleY; ++j)
                {
                    for (int k = XLogic + ret[i].StartObstacleX; k < ret[i].ObstacleWidth + XLogic + ret[i].StartObstacleX; ++k)
                    {
                        Matrix[j][k] = false;
                    }
                }
            }
            return ret;
        }
    }
}
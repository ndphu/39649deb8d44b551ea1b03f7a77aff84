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
using System.IO;

namespace TheReturnOfTheKing
{
    public class MapManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public MapManager(string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_xmlInfo);
                _nprototype = doc.SelectNodes(@"//Map").Count;
                _prototype = new VisibleGameObject[_nprototype];
            }
            catch
            {

            }
        }
        public override bool InitOne(ContentManager content, int id)
        {
            XmlDocument _doc = new XmlDocument();
            _doc.Load(_xmlInfo);
            XmlNode _map = _doc.SelectSingleNode(@"//Map[@id = '" + id.ToString() + "']");

            _prototype[id] = new Map();
            int _cols = int.Parse(_map.SelectSingleNode("Width").InnerText);
            int _rows = int.Parse(_map.SelectSingleNode("Height").InnerText);
            int _pieceWidth = int.Parse(_map.SelectSingleNode("PieceWidth").InnerText);
            int _pieceHeight = int.Parse(_map.SelectSingleNode("PieceHeight").InnerText);
            int _npiece = _prototype[id]._nsprite = _cols * _rows;
            _prototype[id]._sprite = new GameSprite[_npiece];
            string contentName = _map.SelectSingleNode("ContentName").InnerText;
            for (int i = 0; i < _npiece; ++i)
            {
                _prototype[id]._sprite[i] = new GameSprite(content.Load<Texture2D>(contentName + i.ToString("0000")), (i % _cols) * _pieceWidth, (i / _cols) * _pieceHeight);
            }
            ((Map)_prototype[id]).Width = _prototype[id]._sprite[0].Texture2D[0].Width * _cols;
            ((Map)_prototype[id]).Height = _prototype[id]._sprite[0].Texture2D[0].Height * _rows;
            ((Map)_prototype[id]).Cols = _cols;
            ((Map)_prototype[id]).Rows = _rows;
            ((Map)_prototype[id]).RpF = GlobalVariables.ScreenHeight / _pieceHeight + 1;
            ((Map)_prototype[id]).CpF = GlobalVariables.ScreenWidth / _pieceWidth + 1;
            ((Map)_prototype[id]).StartPointX = int.Parse(_map.SelectSingleNode("StartPointX").InnerText);
            ((Map)_prototype[id]).StartPointY = int.Parse(_map.SelectSingleNode("StartPointY").InnerText);

            string collisionName = _map.SelectSingleNode("Collision").InnerText;
            List<List<bool>> matrix = new List<List<bool>>();
            int collisionUnitDim = int.Parse(_map.SelectSingleNode("CollisionUnitDim").InnerText);
            int collisionMatrixWith = (int)((Map)_prototype[id]).Width / collisionUnitDim;
            int collisionMatrixHeight = (int)((Map)_prototype[id]).Height / collisionUnitDim;
            FileStream f = File.OpenRead(collisionName);

            List<bool> temp = new List<bool>();
            while (true)
            {
                int i = f.ReadByte();
                if (i == -1)
                    break;
                if (i == '\r' || i == ' ' || i == '\n')
                    continue;
                if (i == '1')
                    temp.Add(true);
                else
                    temp.Add(false);
                if (temp.Count == collisionMatrixWith)
                {
                    matrix.Add(temp);
                    temp = new List<bool>();
                }
            }
            ((Map)_prototype[id]).Matrix = matrix;
            ((Map)_prototype[id]).CollisionDim = collisionUnitDim;
            ((Map)_prototype[id]).MapName = _map.SelectSingleNode(@"MapName").InnerText;
            return true;
        }
    }
}

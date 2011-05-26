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
    public class GameFrameManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public GameFrameManager (string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);
                XmlNodeList _listFrame = _doc.DocumentElement.SelectNodes("//Frame");
                _nprototype = _listFrame.Count;
                _prototype = new VisibleGameObject [_nprototype];
            }
            catch
            {
                
            }
        }

        public override bool InitOne(ContentManager content, int id)
        {
            XmlDocument _doc = new XmlDocument();
            _doc.Load(_xmlInfo);
            XmlNode _frame = _doc.SelectSingleNode(@"//Frame[@id = '" + id.ToString() + "']");

            _prototype[id] = new GameFrame();

            string _backgroundPath = _frame.SelectSingleNode("BackGround").InnerText;
            if (_backgroundPath == "Null")
            {
                _prototype[id]._nsprite = 0;
                _prototype[id]._sprite = null;
            }
            else
            {
                _prototype[id]._nsprite = 1;
                _prototype[id]._sprite = new GameSprite [_prototype[id]._nsprite];
                Texture2D _temp = content.Load<Texture2D>(_backgroundPath);
                _prototype[id]._sprite[0] = new GameSprite(_temp, 0, 0);
            }
            
            _prototype[id].X = int.Parse(_frame.SelectSingleNode("X").InnerText);
            _prototype[id].Y = int.Parse(_frame.SelectSingleNode("Y").InnerText);
            _prototype[id].Width = int.Parse(_frame.SelectSingleNode("Width").InnerText);
            _prototype[id].Height = int.Parse(_frame.SelectSingleNode("Height").InnerText);
            _prototype[id].Rect = new Rectangle((int)_prototype[id].X,
                (int)_prototype[id].Y,
                (int)_prototype[id].Width,
                (int)_prototype[id].Height);
            ((GameFrame)_prototype[id]).DelayTime = int.Parse(_frame.SelectSingleNode("DelayTime").InnerText);

            MotionInfo _frameMoveInfo = new MotionInfo();
            XmlNode moveInfo = _frame.SelectSingleNode(@"MoveInfo");

            _frameMoveInfo.FirstDection = moveInfo.SelectSingleNode(@"FirstDirection").InnerText;

            if (_frameMoveInfo.FirstDection == "Null")
                _frameMoveInfo = null;
            else
            {
                _frameMoveInfo.IsStanding = false;

                string temp = moveInfo.SelectSingleNode(@"StandingGround").InnerText;
                if (temp == "Null")
                    _frameMoveInfo.StandingGround = float.MinValue;
                else
                    _frameMoveInfo.StandingGround = float.Parse(temp);

                _frameMoveInfo.Vel = new Vector2(float.Parse(moveInfo.SelectSingleNode(@"Velocity").SelectSingleNode(@"X").InnerText),
                    float.Parse(moveInfo.SelectSingleNode(@"Velocity").SelectSingleNode(@"Y").InnerText));

                _frameMoveInfo.Accel = new Vector2(float.Parse(moveInfo.SelectSingleNode(@"Acceleration").SelectSingleNode(@"X").InnerText),
                    float.Parse(moveInfo.SelectSingleNode(@"Acceleration").SelectSingleNode(@"Y").InnerText));

                _frameMoveInfo.DecelerationRate = float.Parse(moveInfo.SelectSingleNode(@"DecelerationRate").InnerText) / 10;

                //Cái này la thang Owner nó sẽ trỏ tới cái gameframe trên prototype
                //Khi clone ra 1 gameframe mới thì phai set lai cai owner này
                //trỏ tới đúng đối tượng button mới duoc clone ra
                //---->>Khong là mọi chuyện hỏng bét.
                _frameMoveInfo.Owner = _prototype[id];
            }
            ((GameFrame)_prototype[id]).Motion = _frameMoveInfo;
            return true;
        }
    }
}

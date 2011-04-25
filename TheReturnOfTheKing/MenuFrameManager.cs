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
    public class MenuFrameManager : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public MenuFrameManager(string xmlInfo)
        {
            _xmlInfo = xmlInfo;
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);
                XmlNodeList _menuFrame = _doc.SelectNodes(@"//MenuFrame");
                _nprototype = _menuFrame.Count;
                _prototype = new VisibleGameObject[_nprototype];
            }
            catch (Exception e)
            {
                
            }
        }

        public override bool InitOne(ContentManager content, int id)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);
                XmlNode _menuFrame = _doc.SelectSingleNode(@"//MenuFrame[@id = '"+ id.ToString() +"']");

                //Menu frame chi bao gom 1 texture..
                _prototype[id] = new MenuFrame ();
                _prototype[id]._nsprite = 1;
                _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

                _prototype[id]._sprite[0] = new GameSprite(content.Load<Texture2D>(_menuFrame.SelectSingleNode(@"Background").InnerText),
                    0,
                    0);

                _prototype[id].Height = int.Parse(_menuFrame.SelectSingleNode(@"Height").InnerText);
                _prototype[id].Width = int.Parse(_menuFrame.SelectSingleNode(@"Width").InnerText);
                _prototype[id].X = int.Parse(_menuFrame.SelectSingleNode(@"X").InnerText);
                _prototype[id].Y = int.Parse(_menuFrame.SelectSingleNode(@"Y").InnerText);
                _prototype[id].Rect = new Rectangle((int)_prototype[id].X, (int)_prototype[id].Y, (int)_prototype[id].Width, (int)_prototype[id].Height);
                ((MenuFrame)_prototype[id]).DelayTime = int.Parse(_menuFrame.SelectSingleNode(@"DelayTime").InnerText);

                MotionInfo _menuMoveInfo = new MotionInfo();
                XmlNode moveInfo = _menuFrame.SelectSingleNode(@"MoveInfo");

                _menuMoveInfo.FirstDection = moveInfo.SelectSingleNode(@"FirstDirection").InnerText;
                if (_menuMoveInfo.FirstDection == "Null") // frame đứng yên
                {
                    _menuMoveInfo = null;
                }
                else
                {
                    _menuMoveInfo.IsStanding = false; // bật cờ di chuyển

                    string temp = moveInfo.SelectSingleNode(@"StandingGround").InnerText;
                    if (temp == "Null")
                        _menuMoveInfo.StandingGround = float.MinValue;
                    else
                        _menuMoveInfo.StandingGround = float.Parse(temp);

                    _menuMoveInfo.Vel = new Vector2(float.Parse(moveInfo.SelectSingleNode(@"Velocity").SelectSingleNode(@"X").InnerText),
                        float.Parse(moveInfo.SelectSingleNode(@"Velocity").SelectSingleNode(@"Y").InnerText));

                    _menuMoveInfo.Accel = new Vector2(float.Parse(moveInfo.SelectSingleNode(@"Acceleration").SelectSingleNode(@"X").InnerText),
                        float.Parse(moveInfo.SelectSingleNode(@"Acceleration").SelectSingleNode(@"Y").InnerText));

                    _menuMoveInfo.DecelerationRate = float.Parse(moveInfo.SelectSingleNode(@"DecelerationRate").InnerText);
                    _menuMoveInfo.Owner = _prototype[id];
                }
                ((MenuFrame)_prototype[id])._motionInfo = _menuMoveInfo;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

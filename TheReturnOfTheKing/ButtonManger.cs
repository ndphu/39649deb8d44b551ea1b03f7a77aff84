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
    public class ButtonManger : GameObjectManager
    {
        public override VisibleGameObject CreateObject(int idx)
        {
            return base.CreateObject(idx);
        }

        public ButtonManger(string xmlInfo)
        {
            try
            {
                _xmlInfo = xmlInfo;
                XmlDocument _doc = new XmlDocument();

                _doc.Load(_xmlInfo);
                XmlNodeList _listButton = _doc.SelectNodes(@"//Button");
                _nprototype = _listButton.Count;
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
                XmlNode _button = _doc.SelectSingleNode(@"//Button[@id = '" + id.ToString() + "']");

                _prototype[id] = new Button();
                _prototype[id]._nsprite = 2;
                _prototype[id]._sprite = new GameSprite[_prototype[id]._nsprite];

                //Cho~ nay code cứng luôn
                //Vì 1 trạng thái cua button hiện tại chỉ xài 2 texture
                //Con sprite dau tien la trang thai Idle..
                _prototype[id]._sprite[0] = new GameSprite(content.Load<Texture2D>(_button.SelectSingleNode(@"Idle/ContentName").InnerText),
                        0,
                        0);

                //Con sprite tip theo la trang thai Clicked + Hover
                _prototype[id]._sprite[1] = new GameSprite(content.Load<Texture2D>(_button.SelectSingleNode(@"MouseHover/ContentName").InnerText),
                        0,
                        0);

                _prototype[id].Height = int.Parse(_button.SelectSingleNode(@"Height").InnerText);
                _prototype[id].Width = int.Parse(_button.SelectSingleNode(@"Width").InnerText);


                _prototype[id].X = int.Parse(_button.SelectSingleNode("X").InnerText);
                _prototype[id].Y = int.Parse(_button.SelectSingleNode("Y").InnerText);

                ((Button)_prototype[id]).DelayTime = int.Parse(_button.SelectSingleNode("DelayTime").InnerText);
                _prototype[id].Rect = new Rectangle((int)_prototype[id].X, (int)_prototype[id].Y, (int)_prototype[id].Width, (int)_prototype[id].Height);

                MotionInfo _buttonMoveInfo = new MotionInfo();
                XmlNode moveInfo = _button.SelectSingleNode(@"MoveInfo");

                _buttonMoveInfo.FirstDection = moveInfo.SelectSingleNode(@"FirstDirection").InnerText;

                if (_buttonMoveInfo.FirstDection == "Null")
                    _buttonMoveInfo = null;
                else
                {
                    _buttonMoveInfo.IsStanding = false;

                    string temp = moveInfo.SelectSingleNode(@"StandingGround").InnerText;
                    if (temp == "Null")
                        _buttonMoveInfo.StandingGround = float.MinValue;
                    else
                        _buttonMoveInfo.StandingGround = float.Parse(temp);

                    _buttonMoveInfo.Vel = new Vector2(float.Parse(moveInfo.SelectSingleNode(@"Velocity").SelectSingleNode(@"X").InnerText),
                        float.Parse(moveInfo.SelectSingleNode(@"Velocity").SelectSingleNode(@"Y").InnerText));

                    _buttonMoveInfo.Accel = new Vector2(float.Parse(moveInfo.SelectSingleNode(@"Acceleration").SelectSingleNode(@"X").InnerText),
                        float.Parse(moveInfo.SelectSingleNode(@"Acceleration").SelectSingleNode(@"Y").InnerText));

                    _buttonMoveInfo.DecelerationRate = float.Parse(moveInfo.SelectSingleNode(@"DecelerationRate").InnerText);

                    //Cái này la thang Owner nó sẽ trỏ tới cái button trên prototype
                    //Khi clone ra 1 button mới thì phai set lai cai owner này
                    //trỏ tới đúng đối tượng button mới duoc clone ra
                    //---->>Khong là mọi chuyện hỏng bét.
                    _buttonMoveInfo.Owner = _prototype[id];
                }
                ((Button)_prototype[id])._motionInfo = _buttonMoveInfo;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}

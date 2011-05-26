using System;
using System.Collections.Generic;
using System.Linq;
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
    public class StateLoading : GameState
    {
        //private Texture2D[] _backGround; //Back ground cho loadingScreen
        private GameSprite[] _backGroundImage;
        private int _nBackGroundImage = 0;
        private Texture2D _standingProcessBar; //Cái khung của process bar
        private Texture2D _animateProcessBar; //Dung dịch chảy trong process bar

        private GameObjectManager[] _objectManagerArray; //Mang cac objectManager cần load

        public GameObjectManager[] ObjectManagerArray
        {
            get { return _objectManagerArray; }
            set { _objectManagerArray = value; }
        }


        private int _nObjectManager; //Số lượng objectManager duoc truyền vào

        public int NObjectManager
        {
            get { return _nObjectManager; }
            set { _nObjectManager = value; }
        }

        private string _xmlInfo;

        private int _objectIndex = 0; //Thứ tự Object được load.
        private int _prototypeIndex = 0; //Thứ tự prototype duoc load trong 1 object
        //manager tuong ung

        private Type _type; //Kiểu của state tiếp theo cần chuyển.

        //Cái này là vị trí đặt Processbar
        private int _xPro;
        private int _yPro;

        //Vị trí tọa độ X bắt đầu và kết thúc của thanh dung dịch trong animated Process
        private int _xStartAnimatePro;
        private int _xEndAnimatePro;

        private int _stepLengh = 0;
        private int _completedSteps = 0;

        private int _delayTime = 0;
        private int _iDelayTime = 0;

        private bool _loadDone = false; // Da load xong het thong tin cua cac manager chua?
        private GameState temp = null;

        //int _debugDelay;

        /// <summary>
        /// Vị trí vẽ processbar animate
        /// </summary>
        float _drawingRate;

        ProcessBar _processBar;



        //--------------FUNCTION----------------------------------------------------------------------------

        public override void InitState(GameObjectManager[] objectManagerArray, MainGame owner)
        {
            base.InitState(objectManagerArray, owner);
        }

        //Lấy vào chuỗi xml định nghĩa một số thông tin riêng của Loading state (hình  
        //ảnh backGround, hình ảnh processBar) mảng các objectManager cần load và kiểu 
        //của Game state kế tiếp.
        public void GetDataLoading(ContentManager content, string xmlInfo, GameObjectManager[] objectManagerArray, Type type)
        {
            _nObjectManager = objectManagerArray.Length;
            _objectManagerArray = new GameObjectManager[_nObjectManager];

            for (int i = 0; i < _nObjectManager; i++)
            {
                _objectManagerArray[i] = objectManagerArray[i];
                //1 step là 1 doi tuong prototype cần load.
                _stepLengh += _objectManagerArray[i]._nprototype;
            }
            _stepLengh++; // them cai innit cho gamestate tip theo.
            _type = type; //Lưu lại type của state tip theo
            _xmlInfo = xmlInfo; //Lưu lại chuoi XML luu thong tin rieng cua loadind state

            XmlDocument _doc = new XmlDocument();
            _doc.Load(_xmlInfo);

            XmlNode _backGroundNote = _doc.DocumentElement.SelectSingleNode("BackGround");
            XmlNodeList _imageNoteList = _backGroundNote.SelectNodes("//Image");

            _nBackGroundImage = _imageNoteList.Count;
            _backGroundImage = new GameSprite[_nBackGroundImage];
            for (int i = 0; i < _nBackGroundImage; i++)
            {
                Texture2D _temp = content.Load<Texture2D>(_imageNoteList[i].SelectSingleNode("Path").InnerText);
                int _xTemp = int.Parse(_imageNoteList[i].SelectSingleNode("X").InnerText) - (int)GlobalVariables.dX;
                int _yTemp = int.Parse(_imageNoteList[i].SelectSingleNode("Y").InnerText) - (int)GlobalVariables.dY;
                _backGroundImage[i] = new GameSprite(_temp, _xTemp, _yTemp);
                _backGroundImage[i].Xoffset = 0;
                _backGroundImage[i].Yoffset = 0;
            }

            _delayTime = int.Parse(_doc.DocumentElement.SelectSingleNode("DelayTime").InnerText);
            string _processXMLInfo = _doc.DocumentElement.SelectSingleNode("ProcessBar").SelectSingleNode("ContentName").InnerText;
            
            //Truyền va init tại chỗ vì cái ProcessBarManager chỉ xài cho loading state
            ProcessBarManager pbm = new ProcessBarManager(_processXMLInfo);
            for (int i = 0; i < pbm._nprototype; i++)
            {
                pbm.InitOne(content, i);
            }
            _processBar = (ProcessBar)pbm.CreateObject(0);
        }

        public override void EnterState()
        {
            base.EnterState();
            GlobalVariables.GameCursor.IsEmpty = true;
        }

        public override void UpdateState(GameTime gameTime)
        {
            if (_loadDone)
            {
                if (_iDelayTime == _delayTime)
                {
                    Owner.GameState = temp;
                    GlobalVariables.GameCursor.IsIdle = true;
                }
                else
                    _iDelayTime++;
            }

            else
            {
                if (_completedSteps == _stepLengh)
                {
                    _loadDone = true;
                    return;
                }

                if (_iDelayTime == _delayTime)
                {
                    if (_prototypeIndex >= _objectManagerArray[_objectIndex]._nprototype)
                    {
                        _prototypeIndex = 0;
                        _objectIndex++;
                    }
                    if (_objectIndex >= _nObjectManager)
                    {
                        switch (_type.Name)
                        {
                            case "StateMenu":
                                {
                                    temp = new StateMenu();
                                    temp.InitState(_objectManagerArray, this.Owner);
                                    temp.EnterState();
                                    _completedSteps++;
                                    _delayTime /= 2;
                                    _iDelayTime = 0;
                                    break;
                                }

                            case "StateMainGame":
                                {
                                    temp = new StateMainGame();
                                    temp.InitState(_objectManagerArray, this.Owner);
                                    temp.EnterState();
                                    _completedSteps++;
                                    _delayTime /= 2;
                                    _iDelayTime = 0;
                                    break;
                                }
                        }
                        Owner.ResetElapsedTime();
                        _drawingRate = (float)_completedSteps / (float)_stepLengh;
                        _processBar.UpdateDrawRect(_drawingRate);
                        return;
                    }

                    _objectManagerArray[_objectIndex].InitOne(Owner.Content, _prototypeIndex);
                    _completedSteps++;
                    Owner.ResetElapsedTime();
                    
                    _drawingRate = (float)_completedSteps / (float)_stepLengh;
                    _processBar.UpdateDrawRect(_drawingRate);

                    _prototypeIndex++;
                }
                else
                    _iDelayTime++;

            }
        }

        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            if (_nBackGroundImage > 0)
            {
                for (int i = 0; i < _nBackGroundImage; i++)
                {
                    _backGroundImage[i].Draw(gameTime, sb);
                }
                _processBar.Draw(gameTime, sb);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}

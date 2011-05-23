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
        

        private Texture2D _backGround; //Back ground cho loadingScreen
        


        private GameObjectManager[] _objectManagerArray; //Mang cac objectManager
        //cần load
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

            try
            {
                XmlDocument _doc = new XmlDocument();
                _doc.Load(_xmlInfo);

                _backGround = content.Load<Texture2D>(_doc.DocumentElement.SelectSingleNode("BackGround").InnerText);
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
            catch
            {
                return;
            }
        }

        public override void EnterState()
        {
            base.EnterState();
            GlobalVariables.GameCursor.IsEmpty = true;
        }

        //Dau tien la Update cai background + Process image truoc + sound (neu co)
        //Sau do, moi~ loop update la innit 1 doi tuong trong 1 mang prototype.
        public override void UpdateState(GameTime gameTime)
        {
            /*if (_debugDelay > 0)
            {
                _debugDelay--;
                return;
            }*/
            //base.UpdateState(gameTime);
            //Nếu đã load xong..
            if (_loadDone)
            {
                //Delay 1 chut truoc khi thuc hien viec chuyen game state..
                if (_iDelayTime == _delayTime)
                {
                    /*
                    switch (_type.Name)
                    {
                        case "StateMenu":
                            {
                                Owner.GameState = new StateMenu();
                                break;
                            }
                    }
                    Owner.GameState.InitState(_objectManagerArray, this.Owner);
                    Owner.GameState.EnterState();
                    return;
                     */
                    //Sau 1 khoảng thời gian delaytime mới gán lại gamestate cho chương trình
                    //--> gamestate mới của chương trình sẽ chạy thẳng vào Update()
                    //--> màn hình sẽ mượt hơn rất nhiều.
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
                    //Nếu như id đã vượt quá số lượng id trong object hien thời thì
                    //chuyển wa object tip theo
                    if (_prototypeIndex >= _objectManagerArray[_objectIndex]._nprototype)
                    {
                        _prototypeIndex = 0;
                        _objectIndex++;
                    }
                    //Nếu số lượng objectIndex vuot wa so luon object -> da~ load xong toan bo
                    // cac manager.

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
                        //_debugDelay = 5;
                        Owner.ResetElapsedTime();
                        //_drawingOffset = (_xEndAnimatePro - _xStartAnimatePro) * _completedSteps / _stepLengh + _xStartAnimatePro;  
                        _drawingRate = (float)_completedSteps / (float)_stepLengh;
                        _processBar.UpdateDrawRect(_drawingRate);
                        return;
                    }

                    //LoadOne
                    _objectManagerArray[_objectIndex].InitOne(Owner.Content, _prototypeIndex);
                    _completedSteps++;
                    //_debugDelay = 5;
                    Owner.ResetElapsedTime();
                    //_drawingOffset = (_xEndAnimatePro - _xStartAnimatePro) * _completedSteps / _stepLengh + _xStartAnimatePro;
                    _drawingRate = (float)_completedSteps / (float)_stepLengh;
                    _processBar.UpdateDrawRect(_drawingRate);
                    //Tăng id prototype hiện thời lên 1.
                    _prototypeIndex++;
                }
                else
                    _iDelayTime++;
                
            }
        }
        
        public override void DrawState(GameTime gameTime, SpriteBatch sb)
        {
            //base.DrawState(gameTime, sb);
            //Sau khi backGround được load xong thì mới vẽ (độc lập với delaytime)
            if (_backGround != null)
            {
                sb.Draw(_backGround, new Vector2(0, 0), Color.White);
                //sb.Draw(_animateProcessBar, new Vector2(_xPro, _yPro), new Rectangle(0, 0, (int)_drawingOffset, _animateProcessBar.Height), Color.White);
                //sb.Draw(_standingProcessBar, new Vector2(_xPro, _yPro), Color.White);  
                _processBar.Draw(gameTime, sb);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}

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

namespace TheReturnOfTheKing
{
    public static class GlobalVariables
    {
        private static float _dX;

        public static float dX
        {
            get { return GlobalVariables._dX; }
            set { GlobalVariables._dX = value; }
        }

        private static float _dY;

        public static float dY
        {
            get { return GlobalVariables._dY; }
            set { GlobalVariables._dY = value; }
        }

        static int _screenWidth;

        public static int ScreenWidth
        {
            get { return GlobalVariables._screenWidth; }
            set { GlobalVariables._screenWidth = value; }
        }

        static int _screenHeight;

        public static int ScreenHeight
        {
            get { return GlobalVariables._screenHeight; }
            set { GlobalVariables._screenHeight = value; }
        }

        
        static MouseObserver _mouseObserver;

        public static MouseObserver MouseObserver
        {
            get { return GlobalVariables._mouseObserver; }
            set { GlobalVariables._mouseObserver = value; }
        }

        static KeyboardObserver _keyboardObserver;

        public static KeyboardObserver KeyboardObserver
        {
            get { return GlobalVariables._keyboardObserver; }
            set { GlobalVariables._keyboardObserver = value; }
        }

        static float _mapCollisionDim;

        public static float MapCollisionDim
        {
            get { return GlobalVariables._mapCollisionDim; }
            set { GlobalVariables._mapCollisionDim = value; }
        }
        
        static Cursor _gameCursor;

        public static Cursor GameCursor
        {
            get { return _gameCursor; }
            set { _gameCursor = value; }
        }

        static SpriteFont sf;

        public static SpriteFont Sf
        {
            get { return GlobalVariables.sf; }
            set { GlobalVariables.sf = value; }
        }

        static bool _alreadyUseLeftMouse;

        public static bool AlreadyUseLeftMouse
        {
            get { return GlobalVariables._alreadyUseLeftMouse; }
            set { GlobalVariables._alreadyUseLeftMouse = value; }
        }

        static bool _alreadyUseRightMouse;

        public static bool AlreadyUseRightMouse
        {
            get { return GlobalVariables._alreadyUseRightMouse; }
            set { GlobalVariables._alreadyUseRightMouse = value; }
        }

        //Khai báo 2 biến mouse state
        //2 biến này sẽ được khai báo 'new' 1 lần trong hàm LoadContent của MainGame.cs

        //MouseState hiện hành.
        static MouseState _currentMouseState;

        public static MouseState CurrentMouseState
        {
            get { return GlobalVariables._currentMouseState; }
            set { GlobalVariables._currentMouseState = value; }
        }

        //MouseState trước đó. 
        static MouseState _preMouseState;

        public static MouseState PreMouseState
        {
            get { return GlobalVariables._preMouseState; }
            set { GlobalVariables._preMouseState = value; }
        }
    }
}

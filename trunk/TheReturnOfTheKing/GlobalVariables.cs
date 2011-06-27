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
        /// <summary>
        /// Delta X
        /// </summary>
        private static float _dX;

        public static float dX
        {
            get { return GlobalVariables._dX; }
            set { GlobalVariables._dX = value; }
        }

        /// <summary>
        /// Delta Y
        /// </summary>
        private static float _dY;

        public static float dY
        {
            get { return GlobalVariables._dY; }
            set { GlobalVariables._dY = value; }
        }

        /// <summary>
        /// Chiều rộng của màn hình
        /// </summary>
        static int _screenWidth;

        public static int ScreenWidth
        {
            get { return GlobalVariables._screenWidth; }
            set { GlobalVariables._screenWidth = value; }
        }

        /// <summary>
        /// Chiều cao của màn hình
        /// </summary>
        static int _screenHeight;

        public static int ScreenHeight
        {
            get { return GlobalVariables._screenHeight; }
            set { GlobalVariables._screenHeight = value; }
        }

        
        /// <summary>
        /// Kích thước của một ô tương tác
        /// </summary>
        static int _mapCollisionDim;

        public static int MapCollisionDim
        {
            get { return GlobalVariables._mapCollisionDim; }
            set { GlobalVariables._mapCollisionDim = value; }
        }

        /// <summary>
        /// Con trỏ chuột của game
        /// </summary>
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

        /// <summary>
        /// Biến kiểm tra có đối tượng nào đã dùng LeftMouse hay chưa
        /// </summary>
        static bool _alreadyUseLeftMouse;

        public static bool AlreadyUseLeftMouse
        {
            get { return GlobalVariables._alreadyUseLeftMouse; }
            set { GlobalVariables._alreadyUseLeftMouse = value; }
        }

        /// <summary>
        /// Biến kiểm tra đã có đối tượng nào dùng RightMouse hay chưa
        /// </summary>
        static bool _alreadyUseRightMouse;

        public static bool AlreadyUseRightMouse
        {
            get { return GlobalVariables._alreadyUseRightMouse; }
            set { GlobalVariables._alreadyUseRightMouse = value; }
        }

        //Khai báo 2 biến mouse state
        //2 biến này sẽ được khai báo 'new' 1 lần trong hàm LoadContent của MainGame.cs

        /// <summary>
        /// MouseState của lần update hiện tại
        /// </summary>
        static MouseState _currentMouseState;

        public static MouseState CurrentMouseState
        {
            get { return GlobalVariables._currentMouseState; }
            set { GlobalVariables._currentMouseState = value; }
        }
        
        /// <summary>
        /// MouseState của lần update trước đó
        /// </summary>
        static MouseState _previousMouseState;

        public static MouseState PreviousMouseState
        {
            get { return GlobalVariables._previousMouseState; }
            set { GlobalVariables._previousMouseState = value; }
        }

        /// <summary>
        /// KeyboarState của lần update hiện tại
        /// </summary>
        static KeyboardState _currentKeyboardState;

        public static KeyboardState CurrentKeyboardState
        {
            get { return GlobalVariables._currentKeyboardState; }
            set { GlobalVariables._currentKeyboardState = value; }
        }
        /// <summary>
        /// KeyboardState của lần update trước.
        /// </summary>
        static KeyboardState _previousKeyboardState;

        public static KeyboardState PreviousKeyboardState
        {
            get { return GlobalVariables._previousKeyboardState; }
            set { GlobalVariables._previousKeyboardState = value; }
        }

        private static Random _globalRandom = new Random();

        public static Random GlobalRandom
        {
            get { return GlobalVariables._globalRandom; }
            set { GlobalVariables._globalRandom = value; }
        }

        static bool isPauseGame;

        public static bool IsPauseGame
        {
            get { return GlobalVariables.isPauseGame; }
            set { GlobalVariables.isPauseGame = value; }
        }

        static AudioEngine audioEngine;

        public static AudioEngine AudioEngine
        {
            get { return GlobalVariables.audioEngine; }
            set { GlobalVariables.audioEngine = value; }
        }
        static WaveBank waveBank;

        public static WaveBank WaveBank
        {
            get { return GlobalVariables.waveBank; }
            set { GlobalVariables.waveBank = value; }
        }

        static SoundBank soundBank;

        public static SoundBank SoundBank
        {
            get { return GlobalVariables.soundBank; }
            set { GlobalVariables.soundBank = value; }
        }

        static Cue _backgroundSound;

        public static Cue BackgroundSound
        {
            get { return GlobalVariables._backgroundSound; }
            set { GlobalVariables._backgroundSound = value; }
        }

        static bool _isEnableSound = true;

        public static bool IsEnableSound
        {
            get { return _isEnableSound; }
            set { _isEnableSound = value; }
        }

        public static void PlayEffectSound(string name)
        {
            if (IsEnableSound)
            {
                SoundBank.GetCue(name).Play();                
            }
        }

        static Monster _lastBoss;

        public static Monster LastBoss
        {
            get { return _lastBoss; }
            set { _lastBoss = value; }
        }
    }
}

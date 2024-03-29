using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Threading;

namespace TheReturnOfTheKing
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState _gameState;

        public GameState GameState
        {
            get { return _gameState; }
            set { _gameState = value; }
        }
        
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";       
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GlobalVariables.AudioEngine = new AudioEngine("Content\\snd\\GameSounds.xgs");
            GlobalVariables.WaveBank = new WaveBank(GlobalVariables.AudioEngine, "Content\\snd\\Wave Bank.xwb");
            GlobalVariables.SoundBank = new SoundBank(GlobalVariables.AudioEngine, "Content\\snd\\Sound Bank.xsb");
            
            base.Initialize();
            //IsFixedTimeStep = false;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.graphics.IsFullScreen = true;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            GlobalVariables.Sf = Content.Load<SpriteFont>("sf");
            
            GlobalVariables.ScreenHeight = this.Window.ClientBounds.Height;
            GlobalVariables.ScreenWidth = this.Window.ClientBounds.Width;

            //Khởi tạo 2 biến mouseState
            GlobalVariables.CurrentMouseState = new MouseState();
            GlobalVariables.PreviousMouseState = new MouseState();

            GlobalVariables.GameCursor = new Cursor();
            GlobalVariables.GameCursor.Init(Content);
   
            //_gameState = new StateMenu();
            //_gameState.InitState(Content, this);
            //_gameState.EnterState();

            int nObjectManager = 3;
            GameObjectManager[] objectManagerArray = new GameObjectManager[nObjectManager];
            objectManagerArray[0] = new BackgroundManager(@"./Data/XML/menubg.xml");
            objectManagerArray[1] = new GameFrameManager(@"./Data/XML/gameframe-statemenu.xml");
            objectManagerArray[2] = new ButtonManger(@"./Data/XML/buttonmanager-statemenu.xml");
            _gameState = new StateLoading();
            _gameState.InitState(null, this);
            ((StateLoading)_gameState).GetDataLoading(Content, @"./Data/XML/loadingtomenu.xml", objectManagerArray, typeof(StateMenuManager));
            _gameState.EnterState();

            //int nObjectManager = 12;
            //GameObjectManager[] objectManagerArray = new GameObjectManager[nObjectManager];

            //objectManagerArray[1] = new MapManager(@"Data\Map\map.xml");
            //objectManagerArray[0] = new PlayerCharacterManager(@"Data\character\character.xml");
            //objectManagerArray[2] = new MonsterManager(@"Data\monster\monster.xml");
            //objectManagerArray[3] = new ProcessBarManager(@"Data\XML\processbar-stateloading.xml");
            //objectManagerArray[4] = new PortralManager(@"Data\Portral\Portral.xml");
            //objectManagerArray[5] = new MapObstacleManager(@"Data\MapObstacle\MapObstacle.xml");
            //objectManagerArray[6] = new ProjectileManager(@"Data\Projectile\Projectile.xml");
            //objectManagerArray[7] = new SkillManager(@"Data\Skill\Skill.xml");
            //objectManagerArray[8] = new GameFrameManager(@"Data\XML\gameframe-statemaingame.xml");
            //objectManagerArray[9] = new ProcessBarManager(@"Data\XML\processbar-statemaingame.xml");
            //objectManagerArray[10] = new ButtonManger(@"Data\XML\buttonmanager-statemaingame.xml");
            //objectManagerArray[11] = new LabelManager(@"Data\XML\labelmanager-statemaingame.xml");

            //_gameState = new StateLoading();
            //_gameState.InitState(null, this);
            //((StateLoading)_gameState).GetDataLoading(Content, @"./Data/XML/loadingtomenu.xml", objectManagerArray, typeof(StateMainGame));
            //_gameState.EnterState();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (GlobalVariables.BackgroundSound != null)
            {
                if (GlobalVariables.IsEnableSound == true)
                {
                    if (!GlobalVariables.BackgroundSound.IsPlaying)
                    {
                        GlobalVariables.BackgroundSound = GlobalVariables.SoundBank.GetCue(GlobalVariables.BackgroundSound.Name);
                        GlobalVariables.BackgroundSound.Play();
                    }
                }
                else
                    GlobalVariables.BackgroundSound.Stop(AudioStopOptions.Immediate);
            }

            GlobalVariables.AlreadyUseLeftMouse = false;

            //Lấy MouseState và KeyboardState
            GlobalVariables.CurrentMouseState = Mouse.GetState();
            GlobalVariables.CurrentKeyboardState = Keyboard.GetState();

            //GameUpdate            
            _gameState.UpdateState(gameTime);
            GlobalVariables.GameCursor.Update(gameTime);

            //Sau khi GameUpdate xong, lưu lại MouseState và KeyboardState.
            GlobalVariables.PreviousMouseState = GlobalVariables.CurrentMouseState;
            GlobalVariables.PreviousKeyboardState = GlobalVariables.CurrentKeyboardState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            // TODO: Add your drawing code here

            spriteBatch.Begin();
            _gameState.DrawState(gameTime, spriteBatch);
            ////_cursor.Draw(gameTime, spriteBatch);
            GlobalVariables.GameCursor.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

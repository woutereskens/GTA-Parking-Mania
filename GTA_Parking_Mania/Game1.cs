#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
using System.IO;
#endregion

namespace GTA_Parking_Mania
{
    // The Main Game
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;

        // With the SpriteBatch Object you can draw 2D Images
        private SpriteBatch spriteBatch;

        // Textures
        // backgroundtextures
        protected Texture2D menuSceneBackgroundTexture;
        protected Texture2D startSceneBackgroundTexture;
        protected Texture2D actionSceneBackgroundTexture;
        protected Texture2D helpSceneBackgroundTexture;
        protected Texture2D creditSceneBackgroundTexture;
        protected Texture2D gameOverSceneBackgroundTexture;
        protected Texture2D highScoreBackgroundTexture;

        // objecttextures
        protected Texture2D carTexture;
        protected Texture2D personTexture;

        // Game Scenes
        protected MenuScene menuScene;
        protected ActionScene actionScene;
        protected GameScene activeScene;
        protected HelpScene helpScene;
        protected StartScene startScene;
        protected CreditScene creditScene;
        protected GameOverScene gameOverScene;
        protected AddHighScoreScene addHighScoreScene;
        protected HighScoreScene highScoreScene;

        // Fonts
        SpriteFont menuFont;

        // Used for handle input
        KeyboardState oldKeyboardState;

        // Levels
        LevelLoader mLevel;
        LevelLoader mLevel1;
        LevelLoader mLevel2;
        LevelLoader mLevel3;

        // Soundeffects
        SoundEffect crash;

        // Set the CurrentLevel and the TotalScore
        public int currentLevel = 1;
        public double totalScore = 0;

        public Game1()
            : base()
        {
            // Creation of the game window
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";
        }

        // Initialize
        protected override void Initialize()
        {
            // Initialize
            base.Initialize();
        }

        // LoadContent
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Services.AddService(typeof(SpriteBatch), spriteBatch);

            // Open the stream
            System.IO.Stream stream;

            // Load the BackgroundTexture of the startscene
            stream = TitleContainer.OpenStream("Content/start.png");
            startSceneBackgroundTexture = Texture2D.FromStream(GraphicsDevice, stream);

            // Load the PersonTexture
            stream = TitleContainer.OpenStream("Content/person.png");
            personTexture = Texture2D.FromStream(GraphicsDevice, stream);

            // Make a new StartScene
            startScene = new StartScene(this, startSceneBackgroundTexture, personTexture);
            Components.Add(startScene);

            // Show that StartScene
            startScene.Show();
            activeScene = startScene;
        }

        // Create the MenuScene
        private void CreateMenuScene()
        {
            // Open the stream
            System.IO.Stream stream;

            // Load the BackgroundTexture of the Menu
            stream = TitleContainer.OpenStream("Content/menu.png");
            menuSceneBackgroundTexture = Texture2D.FromStream(GraphicsDevice, stream);

            // Load the SpriteFont of the Menu
            menuFont = Content.Load<SpriteFont>("Broadway40Font");

            // Load the MenuScroll
            stream = TitleContainer.OpenStream("Content/horn.wav");
            SoundEffect menuScroll = SoundEffect.FromStream(stream);

            // Make a new MenuScene
            menuScene = new MenuScene(this, menuFont, menuSceneBackgroundTexture, menuScroll);
            Components.Add(menuScene);
        }
        
        // Create the ActionScene
        private void CreateActionScene()
        {
            // Open the stream
            System.IO.Stream stream;

            // Load the CarTexture
            stream = TitleContainer.OpenStream("Content/car.png");
            carTexture = Texture2D.FromStream(GraphicsDevice, stream);

            // Load the sound of a starting car
            stream = TitleContainer.OpenStream("Content/car_start.wav");
            SoundEffect actionSound = SoundEffect.FromStream(stream);

            // Load the sound of a crashing car
            stream = TitleContainer.OpenStream("Content/crash.wav");
            crash = SoundEffect.FromStream(stream);

            // When CurrentLevel is 1
            if (currentLevel == 1)
            {
                // Load Level1
                mLevel1 = new LevelLoader("Content/Level1.xml", this.Content);
                mLevel = mLevel1;
            }

            // When CurrentLevel is 2
            if (currentLevel == 2)
            {
                // Load Level2
                mLevel2 = new LevelLoader("Content/Level2.xml", this.Content);
                mLevel = mLevel2;
            }

            // When CurrentLevel is 3
            if (currentLevel == 3)
            {
                // Load Level3
                mLevel3 = new LevelLoader("Content/Level3.xml", this.Content);
                mLevel = mLevel3;
            }

            // Make a new ActionScene
            actionScene = new ActionScene(this, carTexture, personTexture, actionSound, mLevel, currentLevel);
            Components.Add(actionScene);
        }

        // Create HelpScene
        private void CreateHelpScene()
        {
            // Load the BackgroundTexture
            helpSceneBackgroundTexture = Content.Load<Texture2D>("help.png");

            // Make a new HelpScene
            helpScene = new HelpScene(this, helpSceneBackgroundTexture);
            Components.Add(helpScene);
        }

        // Create HighScoreSene
        private void CreateHighScoreScene()
        {
            // Load the BackgroundTexture
            highScoreBackgroundTexture = Content.Load<Texture2D>("highscores.png");

            // Load the MenuFont
            menuFont = Content.Load<SpriteFont>("BroadWay40Font");

            // Make a new HighScoreScene
            highScoreScene = new HighScoreScene(this, menuFont, highScoreBackgroundTexture);
            Components.Add(highScoreScene);
        }

        // Create AddHighScoreScene
        private void CreateAddHighScoreScene()
        {
            // Load the MenuFont
            menuFont = Content.Load<SpriteFont>("Broadway40Font");

            // Make a new HighScoreScene
            addHighScoreScene = new AddHighScoreScene(this, menuFont, totalScore);
            Components.Add(addHighScoreScene);
        }

        // Create GameOverScene
        private void CreateGameOverScene()
        {
            // Load the BackgroundTexture
            gameOverSceneBackgroundTexture = Content.Load<Texture2D>("gameover.png");

            // Make a new GameOverScene
            gameOverScene = new GameOverScene(this, gameOverSceneBackgroundTexture);
            Components.Add(gameOverScene);
        }

        // Create CreditScene
        private void CreateCreditScene()
        {
            // Load the BackgroundTexture
            creditSceneBackgroundTexture = Content.Load<Texture2D>("credits.png");

            // Make a new CreditScene
            creditScene = new CreditScene(this, creditSceneBackgroundTexture);
            Components.Add(creditScene);
        }

        //UnloadContent
        protected override void UnloadContent()
        {

        }

        // Update
        protected override void Update(GameTime gameTime)
        {
            // Tell which Scene what to do
            HandleScenesInput();

            // Update
            base.Update(gameTime);
        }

        //Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            base.Draw(gameTime);
            spriteBatch.End();
        }

        // Tell which Scene what to do
        private void HandleScenesInput()
        {
            if (activeScene == menuScene)
            {
                HandleMenuSceneInput();
            }
            else if (activeScene == actionScene)
            {
                HandleActionSceneInput();
            }
            else if (activeScene == helpScene)
            {
                HandleHelpSceneInput();
            }
            else if (activeScene == startScene)
            {
                HandleStartSceneInput();
            }
            else if (activeScene == creditScene)
            {
                HandleCreditSceneInput();
            }
            else if (activeScene == gameOverScene)
            {
                HandleGameOverSceneInput();
            }
            else if (activeScene == addHighScoreScene)
            {
                HandleAddHighScoreSceneInput();
            }
            else if (activeScene == highScoreScene)
            {
                HandleHighScoreSceneInput();
            }
        }

        // Show a Scene
        protected void ShowScene(GameScene scene)
        {
            activeScene.Hide();
            activeScene = scene;
            scene.Show();
        }

        // Tell what the MenuScene has to do
        private void HandleMenuSceneInput()
        {
            // Instantiate
            KeyboardState keyboardState = Keyboard.GetState();
            bool entered = (oldKeyboardState.IsKeyDown(Keys.Enter) &&
                           (keyboardState.IsKeyUp(Keys.Enter)));
            oldKeyboardState = keyboardState;

            if (entered)
            {
                switch (menuScene.SelectedMenuIndex)
                {
                    case 0:
                        if (actionScene == null || actionScene.gameOver)
                        {
                            CreateActionScene();
                        }
                        ShowScene(actionScene);
                        break;
                    case 1:
                        if (helpScene == null)
                        {
                            CreateHelpScene();
                        }
                        ShowScene(helpScene);
                        break;
                    case 2:
                        if (creditScene == null)
                        {
                            CreateCreditScene();
                        }
                        ShowScene(creditScene);
                        break;
                    case 3:
                        CreateHighScoreScene();
                        ShowScene(highScoreScene);
                        break;
                    case 4:
                        Exit();
                        break;
                }
            }
        }

        // Tell what the StartScene has to do
        private void HandleStartSceneInput()
        {
            // Instantiate
            KeyboardState keyboardState = Keyboard.GetState();
            bool entered = (oldKeyboardState.IsKeyDown(Keys.Enter) && (keyboardState.IsKeyUp(Keys.Enter)));
            oldKeyboardState = keyboardState;

            // CreateMenuScene
            if (entered)
            {
                CreateMenuScene();
                ShowScene(menuScene);
            }
        }

        // Tell what the HighScoreScene has to do
        private void HandleHighScoreSceneInput()
        {
            // Instantiate
            KeyboardState keyboardState = Keyboard.GetState();
            bool escaped = (oldKeyboardState.IsKeyDown(Keys.Escape) && (keyboardState.IsKeyUp(Keys.Escape)));
            oldKeyboardState = keyboardState;

            // ShowMenuScene
            if (escaped)
            {
                ShowScene(menuScene);
            }
        }

        // Tell what the ActionScene has to do
        private void HandleActionSceneInput()
        {
            // Instantiate
            KeyboardState keyboardState = Keyboard.GetState();
            bool escaped = (oldKeyboardState.IsKeyDown(Keys.Escape) && (keyboardState.IsKeyUp(Keys.Escape)));
            oldKeyboardState = keyboardState;

            if (escaped)
            {
                ShowScene(menuScene);
            }

            // If the Game is over
            if (actionScene.gameOver)
            {
                crash.Play();
                CreateGameOverScene();
                ShowScene(gameOverScene);
                totalScore = 0;
                currentLevel = 1;
                actionScene.level1Completed = false;
                actionScene.level2Completed = false;
                actionScene.level3Completed = false;
            }

            // When Level1 is completed
            if (actionScene.level1Completed)
            {
                currentLevel = 2;

                totalScore += actionScene.score;

                CreateActionScene();
                ShowScene(actionScene);
            }

            // When Level2 is completed
            if (actionScene.level2Completed)
            {
                currentLevel = 3;
                totalScore += actionScene.score;

                CreateActionScene();
                ShowScene(actionScene);
            }

            // When Level3 is completed
            if (actionScene.level3Completed)
            {
                totalScore += actionScene.score;

                CreateAddHighScoreScene();
                ShowScene(addHighScoreScene);

                totalScore = 0;
                currentLevel = 1;
                actionScene.level1Completed = false;
                actionScene.level2Completed = false;
                actionScene.level3Completed = false;

                actionScene = null;
            }
        }

        // Tell what the HelpScene has to do
        private void HandleHelpSceneInput()
        {
            // Instantiate
            KeyboardState keyboardState = Keyboard.GetState();
            bool escaped = (oldKeyboardState.IsKeyDown(Keys.Escape) &&
                           (keyboardState.IsKeyUp(Keys.Escape)));
            oldKeyboardState = keyboardState;

            // ShowMenuScene
            if (escaped)
            {
                ShowScene(menuScene);
            }
        }

        // Tell what the CreditScene has to do
        private void HandleCreditSceneInput()
        {
            // Instantiate
            KeyboardState keyboardState = Keyboard.GetState();
            bool escaped = (oldKeyboardState.IsKeyDown(Keys.Escape) &&
                           (keyboardState.IsKeyUp(Keys.Escape)));
            oldKeyboardState = keyboardState;

            // ShowMenuScene
            if (escaped)
            {
                ShowScene(menuScene);
            }
        }

        // Tell what the AddHighScoreScene has to do
        private void HandleAddHighScoreSceneInput()
        {
            // Instantiate
            KeyboardState keyboardState = Keyboard.GetState();
            bool escaped = (oldKeyboardState.IsKeyDown(Keys.Escape) &&
                           (keyboardState.IsKeyUp(Keys.Escape)));
            oldKeyboardState = keyboardState;

            // ShowMenuScene
            if (escaped)
            {
                ShowScene(menuScene);
            }

            // CreateCreditScene
            if (addHighScoreScene.highScoreAdded == true)
            {
                addHighScoreScene = null;
                CreateCreditScene();
                ShowScene(creditScene);
            }
        }

        // Tell what the GameOver has to do
        private void HandleGameOverSceneInput()
        {
            // Instantiate
            KeyboardState keyboardState = Keyboard.GetState();
            bool entered = (oldKeyboardState.IsKeyDown(Keys.Enter) && (keyboardState.IsKeyUp(Keys.Enter)));
            oldKeyboardState = keyboardState;

            // ShowMenuScene
            if (entered)
            {
                ShowScene(menuScene);
            }
        }
    }
}

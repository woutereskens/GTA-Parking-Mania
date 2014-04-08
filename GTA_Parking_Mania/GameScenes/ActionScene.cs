using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace GTA_Parking_Mania
{
    // The Actual Game
    public class ActionScene : GameScene
    {
        // The SpriteBatch object
        protected SpriteBatch spriteBatch = null;

        // SoundEffect
        protected SoundEffect actionSound;

        // Drawable Game Component
        Car car;

        // GameState elements
        protected Boolean paused;
        public Boolean gameOver;
        public Boolean level1Completed;
        public Boolean level2Completed;
        public Boolean level3Completed;
        protected KeyboardState oldKeyboardState;

        // The BackGround ImageComponent
        protected ImageComponent background;

        // Current Level of the game
        public int currentLevel;

        // The Score of the current Level
        public double score;

        // Instantiate the Level
        LevelLoader mLevel;

        public ActionScene(Game game, Texture2D carTexture, Texture2D personTexture, SoundEffect actionSound, LevelLoader mLevel, int currentLevel)
            : base(game)
        {
            // Set the Spritefount
            this.actionSound = actionSound;

            // Set the Level
            this.mLevel = mLevel;

            // Set the Current Level
            this.currentLevel = currentLevel;

            // Set the SpriteBatch
            spriteBatch = (SpriteBatch) Game.Services.GetService(typeof(SpriteBatch));

            // Make a new Car Object
            car = new Car(game, carTexture);
            components.Add(car);
        }

        // Show the ActionScene
        public override void Show()
        {
            gameOver = false;
            paused = false;

            base.Show();
        }

        // Initialize
        public override void Initialize()
        {
            // Play the car_start Sound
            actionSound.Play();

            // Initialize
            base.Initialize();
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            // Instantie the KeyboardState
            KeyboardState keyboardState = Keyboard.GetState();

            // When Pause is pressed
            bool pKey = (oldKeyboardState.IsKeyDown(Keys.P) && (keyboardState.IsKeyUp(Keys.P)));
            oldKeyboardState = keyboardState;

            // When Pause is pressed again unpause the game
            if (pKey)
            {
                paused = !paused;
            }

            // Whe the game isn't paused or over
            if ((!paused) && (!gameOver))
            {
                // Get the Car Bounds
                Rectangle carBounds = car.getBounds();

                // Instantiate intersected to false
                Boolean intersected = false;

                // When the Level is Level1
                if (currentLevel == 1)
                {
                    // Set the two Rectangles to intersect with
                    Rectangle firstRectangle = new Rectangle(0, 0, 700 + 16, 600);
                    Rectangle rectangleFinish = new Rectangle(725, 225, 50, 50);

                    // When the Car intersects with the first Rectangle the game is over
                    if (carBounds.Intersects(firstRectangle))
                    {
                        intersected = true;
                    }

                    // When the Car intersects with the RectangleFinish the Level is completed
                    if (carBounds.Intersects(rectangleFinish))
                    {
                        level1Completed = true;
                        score = 1000 - gameTime.TotalGameTime.Seconds;
                    }
                }

                // When the Level is Level2
                if (currentLevel == 2)
                {
                    // Set the two Rectangles to intersect with
                    Rectangle firstRectangle = new Rectangle(0, 100, 700+16, 500);
                    Rectangle rectangleFinish = new Rectangle(0, 0, 400, 100);

                    // When the Car intersects with the first Rectangle the game is over
                    if (carBounds.Intersects(firstRectangle))
                    {
                        intersected = true;
                    }

                    // When the Car intersects with the RectangleFinish the Level is completed
                    if (carBounds.Intersects(rectangleFinish))
                    {
                        level2Completed = true;
                        score = 2000 - gameTime.TotalGameTime.Seconds;
                    }
                }

                // When the Level is Level3
                if (currentLevel == 3)
                {
                    // Set the two Rectangles to intersect with
                    Rectangle firstRectangle = new Rectangle(0, 100, 700 + 16, 500);
                    Rectangle rectangleFinish = new Rectangle(0,0,100,100);

                    // When the Car intersects with the first Rectangle the game is over
                    if (carBounds.Intersects(firstRectangle))
                    {
                        intersected = true;
                    }

                    // When the Car intersects with the RectangleFinish the Level is completed
                    if (carBounds.Intersects(rectangleFinish))
                    {
                        level3Completed = true;
                        score = 3000 - gameTime.TotalGameTime.Seconds;
                    }
                }

                // When intersected is true the game is over
                if (intersected == true)
                {
                    gameOver = true;
                }

                // Update
                base.Update(gameTime);
            }
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Draw the level
            mLevel.Draw(this.spriteBatch);

            // Draw
            base.Draw(gameTime);
        }
    }
}

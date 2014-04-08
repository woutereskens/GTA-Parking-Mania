using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    // The Walking Person
    public class Person : Microsoft.Xna.Framework.DrawableGameComponent
    {
        // PersonTexture
        protected Texture2D texture;

        // Position of the Person
        protected Vector2 position = new Vector2();

        // Default size of the PersonTexture
        protected const int WIDTH = 34;
        protected const int HEIGHT = 63;

        // Size of the Screen
        protected Rectangle screenBounds;

        // Frames
        protected List<Rectangle> frames;
        private int activeFrame;

        // Instantiate the FrameTime
        int lastFrameTime;
        const int TIME_BETWEEN_FRAMES = 200;

        public Person(Game game, Texture2D texture)
            : base(game)
        {
            // PersonTexture
            this.texture = texture;

            // Size of the Screen
            screenBounds = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

            // Frames
            frames = new List<Rectangle>();
            lastFrameTime = System.Environment.TickCount;

            // Create the frames
            CreateFrames();

            // Set the active frame to zero
            activeFrame = 0;

            // Put the Person in the start position
            PutInStartPosition();
        }

        // Put the Person  in the start position
        public void PutInStartPosition()
        {
            position = new Vector2(WIDTH, screenBounds.Height - HEIGHT-10);
        }

        // Create the frames
        public void CreateFrames()
        {
            for (int i = 0; i < 6; i++)
            {
                // Look for all the textures in the image
                switch(i)
                {
                    case 0:
                        frames.Add(new Rectangle(0, 0, 34, 67));
                        break;
                    case 1:
                        frames.Add(new Rectangle(48, 0, 62, 67));
                        break;
                    case 2:
                        frames.Add(new Rectangle(127, 0, 63, 67));
                        break;
                    case 3:
                        frames.Add(new Rectangle(210, 0, 38, 67));
                        break;
                    case 4:
                        frames.Add(new Rectangle(258, 0, 62, 67));
                        break;
                    case 5:
                        frames.Add(new Rectangle(332, 0, 62, 67));
                        break;
                }
            }
        }

        // Initialize
        public override void Initialize()
        {
            base.Initialize();
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            // Update the position of the Person
            position.X += 0.70f;

            // If the Person goes out of the Screenbounds set his position to zero
            if (position.X > screenBounds.Width - WIDTH)
            {
                position.X = 0;
            }

            // Update
            base.Update(gameTime);
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Update the FrameTime
            if (System.Environment.TickCount - lastFrameTime > TIME_BETWEEN_FRAMES)
            {
                activeFrame = (activeFrame + 1) % frames.Count;
                lastFrameTime = System.Environment.TickCount;
            }

            // Get the SpriteBatch
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            // Draw the Person with it's frame
            sBatch.Draw(texture, position, frames[activeFrame], Color.White);

            // Draw
            base.Draw(gameTime);
        }

    }
}

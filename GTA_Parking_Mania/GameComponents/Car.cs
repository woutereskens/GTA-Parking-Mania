using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    // The Driving Car
    class Car : Microsoft.Xna.Framework.DrawableGameComponent
    {
        // CarTexture
        protected Texture2D texture;

        // Position of the Car
        protected Vector2 position = new Vector2();

        // Size of the CarTexture
        protected const int WIDTH = 32;
        protected const int HEIGHT = 56;

        // Size of the Screen
        protected Rectangle screenBounds; 

        // Other Car Features
        float carHeading;
        float carSpeed;
        float steerAngle;

        public Car(Game game, Texture2D texture)
            : base(game)
        {
            // CarTexture
            this.texture = texture;

            // Size of the Screen
            screenBounds = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

            // Put the Car in the start position
            PutInStartPosition();
        }

        // Put the Car in the start position
        private void PutInStartPosition()
        {
            position.X = 750;
            position.Y = screenBounds.Height - HEIGHT + 20;
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            // Instantiate booleans
            Boolean speedAdjusted = false;
            Boolean steerAdjusted = false;

            // Press Up then adjust the speed
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                speedAdjusted = true;
                carSpeed -= 5f; 
            }

            // Press Down then adjust the speed
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                speedAdjusted = true;
                carSpeed += 5f;
            }

            // If SpeedAdjusted is false slow the car down
            if (!speedAdjusted)
            {
                carSpeed *= 0.95f;
            }

            // Press Left adjust the steering and the steerangle
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                steerAdjusted = true;
                steerAngle -= (MathHelper.Pi / 80);                
            }

            // Press Right adjust the steering and the steerangle
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                steerAdjusted = true;
                steerAngle += (MathHelper.Pi / 80);
            }

            // If SteerAdjusted is false rotate the steer to it's origin
            if (!steerAdjusted)
            {
                steerAngle *= 0.8f;
            }

            // Simple 2D steering physics
            Vector2 frontWheel;
            Vector2 backWheel;

            frontWheel.X = position.X + WIDTH / 2 * (float)Math.Sin(carHeading);
            frontWheel.Y = position.Y + WIDTH / 2 * (float)Math.Cos(carHeading);

            backWheel.X = position.X - WIDTH / 2 * (float)Math.Sin(carHeading);
            backWheel.Y = position.Y - WIDTH / 2 * (float)Math.Cos(carHeading);

            backWheel.X += carSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * (float)Math.Sin(carHeading);
            backWheel.Y += carSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * (float)Math.Cos(carHeading);

            frontWheel.X += carSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * (float)Math.Sin(carHeading + steerAngle);
            frontWheel.Y += carSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * (float)Math.Cos(carHeading + steerAngle);

            // Adjust the position of the car
            position.X = (frontWheel.X + backWheel.X) / 2;
            position.Y = (frontWheel.Y + backWheel.Y) / 2;

            // Adjust the Car Heading
            carHeading = (float)Math.Atan2(frontWheel.X - backWheel.X, frontWheel.Y - backWheel.Y);

            // Update
            base.Update(gameTime);
        }
        
        // Get the bounds of the Car
        public Rectangle getBounds()
        {
            double aDouble = position.X * Math.Sin(-carHeading) + position.Y * Math.Cos(-carHeading);
            double bDouble = position.X * Math.Cos(-carHeading) + position.Y * Math.Sin(-carHeading);

            int a = (int)aDouble;
            int b = (int)bDouble;

            // Return the rectangle of the Car
            return new Rectangle((int)position.X, (int)position.Y, a, b);
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Get the SpriteBatch
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            // Draw the Car
            sBatch.Draw(texture, position, new Rectangle(0, 0, WIDTH, HEIGHT), Color.White, -carHeading, new Vector2(WIDTH / 2, HEIGHT / 2), 1.0f, SpriteEffects.None, 1f);

            // Draw
            base.Draw(gameTime);
        }
    }
}

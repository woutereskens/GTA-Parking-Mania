using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    // The Start Scene
    public class StartScene : GameScene
    {
        // Instantiate the BackgroundTexture
        protected Texture2D backgroundTexture;

        // Instantiate the drawablegamecomponent
        Person person;

        // Instantiate the size of the screen
        protected Rectangle screenBounds;

        public StartScene(Game game, Texture2D background, Texture2D personTexture)
            : base(game)
        {
            // Set the size of the screen
            screenBounds = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

            // Add the background
            components.Add(new ImageComponent(game, background, ImageComponent.DrawMode.Stretch));

            // Make a new Person
            person = new Person(game, personTexture);
            components.Add(person);
        }

        // Initialize
        public override void Initialize()
        {
            // Initialize
            base.Initialize();
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            // Update
            base.Update(gameTime);
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Draw
            base.Draw(gameTime);
        }

        // Show the scene
        public override void Show()
        {
            base.Show();
        }
    }
}

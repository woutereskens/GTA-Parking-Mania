using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    public class AddHighScoreScene : GameScene
    {
        // Instantiate the Menu
        protected AddHighScoreTextMenu menu;

        // Instantiate the BackgroundTexture
        protected Texture2D backgroundTexture;

        // Instantiate the HighScoreAdded
        public Boolean highScoreAdded;

        // Get the totalscore
        double totalScore = 0;

        // Instantiate the position of the letters
        int XpositionCharacter;
        int YpositionCharacter;

        public AddHighScoreScene(Game game, SpriteFont font, double totalScore)
            : base(game)
        {
            // Set the totalscore
            this.totalScore = totalScore;

            // Instantiate the keyboard
            menu = new AddHighScoreTextMenu(game, font, totalScore);

            // Create the keyboard
            CreateKeyboard();

            // Position the keyboard
            menu.Position = new Vector2(0, 0);

            // Add the keyboard to the components
            components.Add(menu);
        }

        // Initialize
        public override void Initialize()
        {
            base.Initialize();
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            // Set the HighScoreAdded to true
            if (menu.highscoreAdded == true)
            {
                highScoreAdded = true;
            }

            // Upadte
            base.Update(gameTime);
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Draw
            base.Draw(gameTime);
        }

        // Get the SelectedMenuIndex
        public int SelectedMenuIndex
        {
            get { return menu.SelectedIndex; }
        }

        // Show the AddHighScoreScene
        public override void Show()
        {
            base.Show();
        }

        // Create the keyboard
        private void CreateKeyboard()
        {
            // Draw all the letters of the alphabet
            for (int i = 65; i <= 90; i++)
            {
                // Add the characters
                menu.AddMenuItem(Char.ConvertFromUtf32(i), new Vector2(XpositionCharacter, YpositionCharacter));

                // Position the characters
                XpositionCharacter += 70;

                // Draw a new line of characters
                if (i - 64 == 11 || i - 64 == 22)
                {
                    XpositionCharacter = 30;
                    YpositionCharacter += 70;
                }

            }

            // Backspace character
            menu.AddMenuItem(Char.ConvertFromUtf32(60), new Vector2(XpositionCharacter, YpositionCharacter));

            // Space character
            menu.AddMenuItem("Space", new Vector2(XpositionCharacter + 70, YpositionCharacter));

            // Done character
            menu.AddMenuItem("Done", new Vector2(590, YpositionCharacter));
        }
    }
}

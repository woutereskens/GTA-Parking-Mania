using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    public class AddHighScoreTextMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        // Instantiate the font
        protected SpriteFont font;

        // Instantiate the position of the keyboard
        protected Vector2 position = new Vector2();

        // Instantiate SelectedIndex, menuItems
        protected int selectedIndex = 0;
        private readonly List<String> menuItems;
        private readonly List<Vector2> menuPositions;
        protected String name = "";

        // Instantiate the Boolean HighScoreAdded
        public Boolean highscoreAdded = false;

        // Instantiate the totalScore
        double totalScore;

        // Instantiate the keyboardstate
        KeyboardState oldKeyboardState;

        public AddHighScoreTextMenu(Game game, SpriteFont font, double totalScore)
            : base(game)
        {
            // Set the TotalScore
            this.totalScore = totalScore;

            // Set the font
            this.font = font;

            // Make new list of MenuItems and MenuPositions
            menuItems = new List<String>();
            menuPositions = new List<Vector2>();

            // Set the oldkeyboardstate
            oldKeyboardState = Keyboard.GetState();
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
            // Instantiate the booleans
            bool right, left, enter;

            // Set the new keyboardstate
            KeyboardState keyBoardState = Keyboard.GetState();

            // Set the booleans of the keys
            right = oldKeyboardState.IsKeyUp(Keys.Right) && keyBoardState.IsKeyDown(Keys.Right);
            left = oldKeyboardState.IsKeyUp(Keys.Left) && keyBoardState.IsKeyDown(Keys.Left);
            enter = oldKeyboardState.IsKeyUp(Keys.Enter) && keyBoardState.IsKeyDown(Keys.Enter);

            // If the person pressed right index plus one
            if (right)
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
            }

            // If the person pressed left index minus one
            if (left)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }

            // If the person pressed enter
            if (enter)
            {
                switch(menuItems[selectedIndex])
                {
                    // Backspace
                    case "<":
                        if (name.Length > 0)
                        {
                            name = name.Substring(0, name.Length - 1);
                        }
                        break;
                    // Finished adding HighScores
                    case "Done":
                        if (name.Trim() != "")
                        {
                            AddHighScore();
                            highscoreAdded = true;
                        }
                        break;
                    // Space
                    case "Space":
                        name += " ";
                        break;
                    // Get the value of the char
                    default:
                        name += menuItems[selectedIndex];
                        break;
                }
            }

            // Set the keyboardstate to the old keyboardstate
            oldKeyboardState = keyBoardState;

            // Update
            base.Update(gameTime);
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Instantiate the Color
            Color theColor;

            // The SpriteBatch Object
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            // The YPosition
            float y = position.Y;

            // Draw the menu
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == SelectedIndex)
                {
                    // When the Current index is selected set the color to gold
                    theColor = Color.Gold;
                }
                else
                {
                    // Else set the color to white
                    theColor = Color.White;
                }
                // Draw the Keyboard
                sBatch.DrawString(font, menuItems[i], menuPositions[i], Color.Gray);
                sBatch.DrawString(font, menuItems[i], menuPositions[i], theColor);

                // Instantly draw the name
                sBatch.DrawString(font, "Your name: " + name, new Vector2(0, 450), Color.Gold);

                // Instantly draw the score
                sBatch.DrawString(font, "Your score: " + totalScore, new Vector2(0, 500), Color.Gold);
            }

            // Draw
            base.Draw(gameTime);
        }

        // Add the Item to the Keyboard
        public void AddMenuItem(string item, Vector2 position)
        {
            menuPositions.Add(position);
            menuItems.Add(item);
        }

        // Get back the Selected Index
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }

        // Get back the Position of the Keyboard
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        // Add the Highscore to the list of highscores
        private void AddHighScore()
        {
            // Instantiate
            StreamReader streamReader = new StreamReader("highscore.txt");
            List<string> dataList = new List<string>();

            // Read existing scores and save them
            while (streamReader.EndOfStream == false)
            {
                dataList.Add(streamReader.ReadLine());
            }

            streamReader.Close();
            streamReader.Dispose();

            // Instantiate
            StreamWriter streamWriter = new StreamWriter("highscore.txt");

            // Write existing and new highscores to the file
            foreach (string scores in dataList)
            {
                streamWriter.WriteLine(scores);
            }
            streamWriter.WriteLine(name + "," + totalScore);

            streamWriter.Close();
            streamWriter.Dispose();

            // Set the name back to nothing
            name = "";
        }
    }
}

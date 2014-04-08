using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    // The HighScoreScene
    public class HighScoreScene : GameScene
    {
        // The List of all names
        protected List<String> namen;

        // The list of all scores
        protected List<int> scores;

        // The list of the top 8 HighScores
        public List<String> textHighScore;

        // The font
        SpriteFont font;

        // The Position of the HighScores
        protected Vector2 position;

        // The Position of the Background
        protected Vector2 positionBackground;

        // The Texture of the background
        protected Texture2D backgroundTexture;

        public HighScoreScene(Game game, SpriteFont font, Texture2D backgroundTexture)
            : base(game)
        {
            // Set the font
            this.font = font;

            // Set the backgroundtexture
            this.backgroundTexture = backgroundTexture;
        }

        // Initialize
        public override void Initialize()
        {
            // Initialize all the Lists
            namen = new List<String>();
            scores = new List<int>();
            textHighScore = new List<String>();

            // Initialize the positions
            position = new Vector2(5, 85);
            positionBackground = new Vector2(0, 0);

            // Fill the highscorelist
            FillHighScoreList();

            // Initialize
            base.Initialize();
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // The SpriteBatch Object
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            // The position on the y axis
            float y = position.Y;

            // Draw the background
            sBatch.Draw(backgroundTexture, positionBackground, Color.White);

            // Draw the highscores
            for (int i = 0; i < textHighScore.Count; i++)
            {
                sBatch.DrawString(font, textHighScore[i], new Vector2(position.X, y), Color.Gold);

                // Set the Y axis lower to draw the next highscore
                y += 60;
            }

            // Draw
            base.Draw(gameTime);
        }

        // Fill the highscorelist
        public void FillHighScoreList()
        {
            // Instantiate a new StreamReader from the highscore.txt file
            StreamReader reader = new StreamReader("highscore.txt");

            // Read all the objects from the file
            String[] gegevensArray;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                gegevensArray = line.Split(',');
                namen.Add(gegevensArray[0]);
                scores.Add(Int32.Parse(gegevensArray[1]));
            }
            reader.Close();
            reader.Dispose();

            // The the list to an array to sort
            string[] namenArray = namen.ToArray();
            int[] scoresArray = scores.ToArray();

            // Sort the array by score
            Array.Sort(scoresArray, namenArray);
            Array.Reverse(namenArray);
            Array.Reverse(scoresArray);

            // Set the array back to a list
            namen = namenArray.ToList();
            scores = scoresArray.ToList();

            // Add the highscores
            for (int i = 0; i < namen.Count; i++)
            {
                if ((i + 1) <= 8)
                {
                    textHighScore.Add((i + 1) + ". " + namen[i] + " Score: " + scores[i]);
                }
            }
        }
    }
}

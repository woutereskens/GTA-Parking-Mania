using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    // The TextMenu
    public class TextMenu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        // Instantiate the font
        protected SpriteFont font;

        // Instantiate the position of the menu
        protected Vector2 position = new Vector2();

        // Instantiate selectedIndex and MenuItems
        protected int selectedIndex = 0;
        private readonly List<String> menuItems;

        // Instantiate the keyboardstate
        KeyboardState oldKeyboardState;

        // Instantiate the Sound of the MenuScroll
        SoundEffect menuScroll;

        public TextMenu(Game game, SpriteFont font, SoundEffect menuScroll)
            : base(game)
        {
            // Set the font
            this.font = font;

            // Set the sound of the menuscroll
            this.menuScroll = menuScroll;

            // Make new list of menuitems
            menuItems = new List<String>();

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
            bool down, up;

            // Set the new keyboardstate
            KeyboardState keyBoardState = Keyboard.GetState();

            // Set the booleans
            down = oldKeyboardState.IsKeyUp(Keys.Down) && keyBoardState.IsKeyDown(Keys.Down);
            up = oldKeyboardState.IsKeyUp(Keys.Up) && keyBoardState.IsKeyDown(Keys.Up);

            // If the person pressed Down index plus one
            if (down)
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }

                // Play the menuscroll sound
                menuScroll.Play();
            }

            // If the person pressed Up index minus one
            if (up)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Count - 1;
                }

                // Play the menuscroll sound
                menuScroll.Play();
            }

            // Set the keyboardstate to the old keyboardstate
            oldKeyboardState = keyBoardState;

            // Update
            base.Update(gameTime);
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Instantiate
            Color theColor;

            // The SpriteBatch Object
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            // The YPosition
            float y = position.Y;

            // Draw the menu
            for (int i = 0; i < menuItems.Count; i++)
            {
                // If the index is selected draw it in gold 
                if (i == SelectedIndex)
                {
                    theColor = Color.Gold;
                }
                // else draw it in white
                else
                {
                    theColor = Color.White;
                }
                sBatch.DrawString(font, menuItems[i], new Vector2(position.X + 2, y + 2), Color.Gray);
                sBatch.DrawString(font, menuItems[i], new Vector2(position.X, y), theColor);
                y += 60;
            }

            // Draw
            base.Draw(gameTime);
        }

        // Add an item to the menu
        public void AddMenuItem(string item)
        {
            menuItems.Add(item);
        }

        // Get back the selected index
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }

        // Get back the position of the menu
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}

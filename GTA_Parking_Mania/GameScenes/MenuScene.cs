using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    // The Menu
    public class MenuScene : GameScene
    {
        // Instantiate the Menu
        protected TextMenu menu;

        // Instantiate the backgroundTexture
        protected Texture2D backgroundTexture;

        public MenuScene(Game game, SpriteFont font, Texture2D background, SoundEffect menuScroll)
            : base(game)
        {
            // Add the background 
            components.Add(new ImageComponent(game, background, ImageComponent.DrawMode.Stretch));

            // Instantiate the menu
            menu = new TextMenu(game, font, menuScroll);

            // Add items to the menu
            menu.AddMenuItem("Start");
            menu.AddMenuItem("Help");
            menu.AddMenuItem("Credits");
            menu.AddMenuItem("Highscores");
            menu.AddMenuItem("Quit");

            // Position the menu
            menu.Position = new Vector2(475, 200);

            // Add the menu to the components
            components.Add(menu);
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

        //Draw
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

        // Show the MenuScene
        public override void Show()
        {
            base.Show();
        }
    }
}

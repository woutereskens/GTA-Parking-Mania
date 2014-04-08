using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GTA_Parking_Mania
{
    // The ImageComponent draws an image
    public class ImageComponent : DrawableGameComponent
    {
        // Instantiate the DrawMode
        public enum DrawMode
        {
            Center = 1,
            Stretch,
        } ;

        // Texture to draw
        protected readonly Texture2D texture;
        // Draw Mode
        protected readonly DrawMode drawMode;
        // Spritebatch
        protected SpriteBatch spriteBatch = null;
        // Image Rectangle
        protected Rectangle imageRect;

        public ImageComponent(Game game, Texture2D texture, DrawMode drawMode)
            : base(game)
        {
            // Set the Texture
            this.texture = texture;
            
            // Set the drawmode
            this.drawMode = drawMode;

            // Get the current spritebatch
            spriteBatch = (SpriteBatch) Game.Services.GetService(typeof (SpriteBatch));

            // Create a rectangle with the size and position of the image
            switch (drawMode)
            {
                // Center the image in the window
                case DrawMode.Center:
                    imageRect = new Rectangle((Game.Window.ClientBounds.Width - 
                        texture.Width)/2,(Game.Window.ClientBounds.Height - 
                        texture.Height)/2,texture.Width, texture.Height);
                    break;
                // Stretch the image in the window
                case DrawMode.Stretch:
                    imageRect = new Rectangle(0, 0, Game.Window.ClientBounds.Width, 
                        Game.Window.ClientBounds.Height);
                    break;
            }
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Draw the image
            spriteBatch.Draw(texture, imageRect, Color.White);

            // Draw
            base.Draw(gameTime);
        }
    }
}

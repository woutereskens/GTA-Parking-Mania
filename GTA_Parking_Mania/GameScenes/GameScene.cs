using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    // The Basic Game Scene
    public class GameScene : Microsoft.Xna.Framework.DrawableGameComponent
    {
        // Instantiate all the components
        protected List<GameComponent> components;

        public GameScene(Game game)
            : base(game)
        {
            components = new List<GameComponent>();
            Visible = false;
            Enabled = false;
        }

        // Show the GameScene
        public virtual void Show()
        {
            Visible = true;
            Enabled = true;
        }

        // Hide the GameScene
        public virtual void Hide()
        {
            Visible = false;
            Enabled = false;
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
            // Update all the components
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].Enabled)
                {
                    components[i].Update(gameTime);
                }
            }

            // Update
            base.Update(gameTime);
        }

        // Draw
        public override void Draw(GameTime gameTime)
        {
            // Draw all the DrawableGameComponents
            for (int i = 0; i < components.Count; i++)
            {
                if ((components[i] is DrawableGameComponent) && ((DrawableGameComponent)components[i]).Visible)
                {
                    ((DrawableGameComponent) components[i]).Draw(gameTime);
                }
            }

            // Draw
            base.Draw(gameTime);
        }
    }
}

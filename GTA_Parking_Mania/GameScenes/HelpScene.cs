using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    public class HelpScene : GameScene
    {
        // The Help Scene
        public HelpScene(Game game, Texture2D textureBack)
            : base(game)
        {
            // Add the background
            components.Add(new ImageComponent(game, textureBack, ImageComponent.DrawMode.Stretch));
        }
    }
}

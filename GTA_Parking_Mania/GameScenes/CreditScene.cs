using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTA_Parking_Mania
{
    // The Credit Scene
    public class CreditScene : GameScene
    {
        public CreditScene(Game game, Texture2D textureBack)
            : base(game)
        {
            // Add the background to the creditscene
            components.Add(new ImageComponent(game, textureBack, ImageComponent.DrawMode.Stretch));
        }
    }
}

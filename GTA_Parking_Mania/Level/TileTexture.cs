using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GTA_Parking_Mania
{
    // This is what the Tile represents
    class TileTexture
    {
        public char Symbol;
        public Texture2D Texture;
        public Rectangle SourceRectangle;
        public bool Walkable;

        public TileTexture()
        {

        }
    }
}

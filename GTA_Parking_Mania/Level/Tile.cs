using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace GTA_Parking_Mania
{
    // An individual tile within the larger background
    public class Tile
    {
        public Vector2 Position;
        public char Symbol;
        public bool Walkable;

        public Tile(char theSymbol, Vector2 thePosition, bool isWalkable)
        {
            Symbol = theSymbol;
            Position = thePosition;
            Walkable = isWalkable;
        }
    }
}

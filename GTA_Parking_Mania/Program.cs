#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace GTA_Parking_Mania
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create a new game object
            using (var game = new Game1())
                // Start the game loop
                game.Run();
        }
    }
#endif
}

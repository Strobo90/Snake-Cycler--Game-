using System;
using Microsoft.VisualBasic;
using Unit05.Game.Casting;

namespace Unit05.Game
{
    /// <summary>
    /// <para>A tasty item that Cycles like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Constants
    {
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 1;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;
        public static int MIN_X = 0;
        public static int MIN_Y = 0;

        public static int FRAME_RATE = 90;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Cycler";
        
        public static Color RED = new Color(255, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);
        public static Color ORANGE = new Color(255,87,35);
        public static Color BLUE = new Color(89,203,232);

    }
}
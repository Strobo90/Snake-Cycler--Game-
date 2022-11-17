using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;
using Unit05.Game;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {   
            // creates the cast
            Cast cast = new Cast();
            Cycler cycler = new Cycler(100, Constants.MAX_Y/4, Constants.BLUE);
            Cycler cycler2 = new Cycler(100, Constants.MAX_Y*3/4, Constants.ORANGE);
            // cycler.GetSegments();
            
            // creates Player 1's scoreboard and set its color to Blue
            Score score = new Score();
            score.SetColor(Constants.BLUE);
            score.SetText("Player 1");

            // creates Player 2's scoreboard and set its color to Orange
            Score score2 = new Score();
            score2.SetColor(Constants.ORANGE);
            score2.SetText("Player 2");

            // adds the scores and cyclers to the cast
            cast.AddActor("cycler", cycler);
            cast.AddActor("cycler2", cycler2);
            cast.AddActor("score", score);
            cast.AddActor("score2", score2);

            // Sets positions on screen for scoreboards and cyclers.
            Point position = new Point(100,100);
            Point position2 = new Point(300,500);
            Point screpos = new Point(20,20);
            Point screpos2 = new Point(800,20);
            cycler.SetPosition(position);
            cycler2.SetPosition(position2);
            score.SetPosition(screpos);
            score2.SetPosition(screpos2);

            // creates the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // creates the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // starts the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
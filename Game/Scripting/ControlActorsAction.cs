using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the Cycler.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the Cycler's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }
            

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }
            
            // left
            if (keyboardService.IsKeyDown("j"))
            {
                direction2 = new Point(-Constants.CELL_SIZE, 0);
            }
            

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                direction2 = new Point(0, Constants.CELL_SIZE);
            }
            
            Cycler cycler = (Cycler)cast.GetFirstActor("cycler");
            Cycler cycler2 = (Cycler)cast.GetFirstActor("cycler2");
            cycler.TurnHead(direction);
            cycler2.TurnHead(direction2);

        }
    }
}
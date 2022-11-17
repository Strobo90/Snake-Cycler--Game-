using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the Cycler 
    /// collides with the trail of other Cycler, or the Cycler collides with its own trail segments, 
    /// both result with game over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private int loser = 0; //set to 1 if player 1 loses or to 2 if player 2 loses

        // set the position of game winner message used when someone wins the game
        Point winMsgPosition = new Point(Constants.MAX_X/2 - 40, Constants.MAX_Y/2 - 50);

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the Cycler collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Cycler cycler = (Cycler)cast.GetFirstActor("cycler");
            Cycler cycler2 = (Cycler)cast.GetFirstActor("cycler2");
            Actor head = cycler.GetHead();
            Actor head2 = cycler2.GetHead();
            List<Actor> body = cycler.GetBody();
            List<Actor> body2 = cycler2.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    Actor message = new Actor();
                    message.SetText("PLAYER 1 SUICIDE!");
                    message.SetPosition(winMsgPosition);
                    cast.AddActor("messages", message);
                    isGameOver = true;
                    loser = 1;
                }
            }

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    Actor message = new Actor();
                    message.SetText("PLAYER 1 WINS!");
                    message.SetPosition(winMsgPosition);
                    cast.AddActor("messages", message);
                    isGameOver = true;
                    loser = 2;
                }
            }

             foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    Actor message = new Actor();
                    message.SetText("PLAYER 2 SUICIDE!");
                    message.SetPosition(winMsgPosition);
                    cast.AddActor("messages", message);
                    isGameOver = true;
                    loser = 2;
                }
            }

             foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    Actor message = new Actor();
                    message.SetText("PLAYER 2 WINS!");
                    message.SetPosition(winMsgPosition);
                    cast.AddActor("messages", message);
                    isGameOver = true;
                    loser = 1;
                }
            }
            
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                //creates instances of both cyclers
                Cycler cycler = (Cycler)cast.GetFirstActor("cycler");
                List<Actor> segments = cycler.GetSegments();
                Cycler cycler2 = (Cycler)cast.GetFirstActor("cycler2");
                List<Actor> segments2 = cycler2.GetSegments();

                // create a "game over" message
                int x = (Constants.MAX_X / 2) - 40;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);
                
                if (loser == 1)
                {
                    // make all of cycler 1 turn white
                    foreach (Actor segment in segments)
                    {   
                        segment.SetColor(Constants.WHITE);
                        cycler.SetColor(Constants.WHITE);
                        Actor head = cycler.GetHead();
                        head.SetColor(Constants.WHITE);
                    }
                }
                
                else if (loser == 2)
                {
                    // make all of cycler 2 turn white
                    foreach (Actor segment in segments2)
                    {    
                        segment.SetColor(Constants.WHITE);
                        cycler2.SetColor(Constants.WHITE);
                        Actor head = cycler2.GetHead();
                        head.SetColor(Constants.WHITE);
                    }
                }    
            }
        }
    }
}
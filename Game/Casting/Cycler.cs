using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>The first Cycler which should spawn on the left.</para>
    /// <para>The responsibility of Cycler is to move itself.</para>
    /// </summary>
    public class Cycler : Actor
    {
        private List<Actor> segments = new List<Actor>();
        private Point position = new Point(0, 0);

        /// <summary>
        /// Constructs a new instance of a Cycler.
        /// Prepares the body of the Cylcer and 
        /// sets what color its trail will be.
        /// </summary>
        public Cycler(int x, int y, Color color)
        {
            PrepareBody(x,y);
            SetColor(color);
        }

        /// <summary>
        /// Gets the Cycler's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the Cycler's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the Cycler's segments (including the head).
        /// </summary>
        /// <returns>A list of Cycler segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }
        

        /// <inheritdoc/>
        public override void MoveNext()
        {
            Actor segment = new Actor();

            Actor tail = segments.Last<Actor>();
            Actor head = segments[0];
            Point velocity = head.GetVelocity();
            Point position = head.GetPosition();
            segment.SetPosition(position);
            head.SetText("@@");
            head.SetColor(GetColor());
            segment.SetText("o");
            segment.SetColor(GetColor());
            segments.Insert(1, segment);
           
            GetHead().MoveNext();

            
        }

        /// <summary>
        /// Turns the head of the Cycler in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the Cycler body for moving.
        /// </summary>
        private void PrepareBody(int x, int y)
        {
            
            Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
            Point position = new Point(x, y); //use for correct position of cycler on the screen
            
            Actor segment = new Actor();
            segment.SetPosition(position);
            segment.GetPosition();
            segment.SetVelocity(velocity);
            segment.SetColor(GetColor());
            segments.Add(segment); //adds segment to cycler's trail (grows the trail)
            
        }
    }
}
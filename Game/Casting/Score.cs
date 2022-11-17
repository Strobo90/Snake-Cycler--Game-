using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// This is a class for a scoreboard. Right now our scores are used to just
    /// display which player is which and to display a gameOver message.
    /// The score class has room to be used to actually keep score if we can make the
    /// game replayable.
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of a score.
        /// </summary>
        public Score()
        {
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"Score {this.points}");
        }
    }
}
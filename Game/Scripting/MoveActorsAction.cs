using System.Collections.Generic;
using Unit05.Game.Casting;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>

    public class MoveActorsAction : Action
    {
        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActorsAction()
        {            
        }
        /// <summary>
        /// Gets all the actors from the cast. Loop through actors and calls MoveNext method.
        /// </summary>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> actors = cast.GetAllActors();
            foreach(Actor actor in actors)
            {
                actor.MoveNext();
            }
        }
    }
}
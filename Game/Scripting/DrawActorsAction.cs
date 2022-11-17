using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of DrawActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Cycler cycler = (Cycler)cast.GetFirstActor("cycler");
            Cycler cycler2 = (Cycler)cast.GetFirstActor("cycler2");
            List<Actor> segments = cycler.GetSegments();
            List<Actor> segments2 = cycler2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor score2 = cast.GetFirstActor("score2");
            List<Actor> messages = cast.GetActors("messages");
            List<Actor> caption = cast.GetActors(Constants.CAPTION);
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score);
            videoService.DrawActor(score2);
            videoService.DrawActors(messages);
            videoService.DrawActors(caption);
            videoService.FlushBuffer();
        }
    }
}
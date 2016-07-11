using System;

namespace MusicStore.Logic.Artists
{
    public class Track
    {
        public virtual string Name { get; protected set; }

        public virtual Album Album { get; }

        public virtual TimeSpan Duration { get; protected set; }
    }
}

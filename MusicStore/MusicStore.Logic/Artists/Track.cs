using System;
using MusicStore.Logic.Common;

namespace MusicStore.Logic.Artists
{
    public class Track : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual Album Album { get; protected set; }

        public virtual TimeSpan Duration { get; protected set; }

        protected Track()
        {
        }

        public Track(string name, Album album, TimeSpan duration)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException();
            if (Album == null)
                throw new InvalidOperationException();

            Name = name;
            Album = album;
            Duration = duration;
        }
    }
}

using System;
using MusicStore.Logic.Common;

namespace MusicStore.Logic.Artists
{
    public class Track : Entity
    {
        public virtual int Number { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual Album Album { get; protected set; }

        public virtual int? Duration { get; protected set; }

        protected Track()
        {
        }

        public Track(int number, string name, Album album, int? duration = null)
        {
            if (number < 1)
                throw new InvalidOperationException();
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException();
            if (album == null)
                throw new InvalidOperationException();

            Number = number;
            Name = name;
            Album = album;
            Duration = duration;
        }
    }
}

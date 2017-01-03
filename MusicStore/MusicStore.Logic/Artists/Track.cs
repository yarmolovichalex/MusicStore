using System;
using MusicStore.Logic.Common;

namespace MusicStore.Logic.Artists
{
    public class Track : IdentifiedValueObject<Track>
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

        protected override bool EqualsCore(Track other)
        {
            return Number == other.Number && Name == other.Name && Album == other.Album;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Number.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Album.GetHashCode();
                return hash;
            }
        }
    }
}

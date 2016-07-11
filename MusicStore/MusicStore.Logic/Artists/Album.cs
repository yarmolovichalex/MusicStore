using System;
using System.Collections.Generic;
using MusicStore.Logic.Common;
using MusicStore.Logic.SharedKernel;

namespace MusicStore.Logic.Artists
{
    public class Album : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual Artist Artist { get; protected set; }

        public virtual int Year { get; protected set; }

        public virtual IList<Track> Tracks { get; protected set; }

        public virtual Money Price { get; protected set; }

        protected Album()
        {
        }

        public Album(string name, Artist artist, int year, IList<Track> tracks, Money price)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException();
            if (Artist == null)
                throw new InvalidOperationException();
            if (Year < 1900 || Year > DateTime.Now.Year)
                throw new InvalidOperationException();
            if (Tracks == null || Tracks.Count == 0)
                throw new InvalidOperationException();

            Name = name;
            Artist = artist;
            Year = year;
            Tracks = tracks;
            Price = price;
        }
    }
}

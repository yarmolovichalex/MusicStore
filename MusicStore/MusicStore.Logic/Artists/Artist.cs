using System;
using System.Collections.Generic;
using MusicStore.Logic.Common;

namespace MusicStore.Logic.Artists
{
    public class Artist : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual string Country { get; protected set; }

        public virtual ICollection<Album> Albums { get; }

        protected Artist()
        {
        }

        public Artist(string name, string country) : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException();

            Name = name;
            Country = country;
            Albums = new List<Album>();
        }

        public virtual void AddAlbum(Album album)
        {
            Albums.Add(album);
        }
    }
}

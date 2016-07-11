using System.Collections.Generic;
using MusicStore.Logic.Common;

namespace MusicStore.Logic.Artists
{
    public class Artist : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual string Country { get; protected set; }

        public virtual IList<Album> Albums { get; protected set; }

        protected Artist()
        {
        }

        public Artist(string name, string country, IList<Album> albums) : this()
        {
            Name = name;
            Country = country;
            Albums = albums;
        }
    }
}

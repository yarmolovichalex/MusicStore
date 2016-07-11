using System.Collections.Generic;

namespace MusicStore.Logic
{
    public class Album : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual Artist Artist { get; }

        public int Year { get; protected set; }

        protected virtual IList<Track> Tracks { get; } = new List<Track>();
    }
}

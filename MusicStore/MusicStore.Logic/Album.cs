using System.Collections.Generic;

namespace MusicStore.Logic
{
    public class Album : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual Artist Artist { get; }

        protected virtual IList<Track> Tracks { get; } = new List<Track>();
    }
}

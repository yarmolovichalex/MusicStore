using System.Collections.Generic;
using MusicStore.Logic.Common;

namespace MusicStore.Logic.Artists
{
    public class Album : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual Artist Artist { get; }

        public virtual int Year { get; protected set; }

        protected virtual IList<Track> Tracks { get; } = new List<Track>();
    }
}

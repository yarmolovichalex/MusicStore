using System.Collections.Generic;

namespace MusicStore.Logic
{
    public class Artist : Entity
    {
        public virtual string Name { get; protected set; }

        protected virtual IList<Album> Albums { get; } = new List<Album>();
    }
}

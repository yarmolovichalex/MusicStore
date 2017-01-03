using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace MusicStore.Logic.Artists
{
    public class TrackMap : ClassMap<Track>
    {
        public TrackMap()
        {
            Id(Reveal.Member<Track>("Id"));
            Map(x => x.Number);
            Map(x => x.Name);
            Map(x => x.Duration).Nullable();

            References(x => x.Album);
        }
    }
}
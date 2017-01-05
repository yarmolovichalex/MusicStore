using FluentNHibernate;
using FluentNHibernate.Mapping;
using MusicStore.Logic.Model.Artist;

namespace MusicStore.Logic.Persistence.Artist
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
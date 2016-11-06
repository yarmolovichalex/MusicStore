using FluentNHibernate.Mapping;

namespace MusicStore.Logic.Artists
{
    public class TrackMap : ClassMap<Track>
    {
        public TrackMap()
        {
            Id(x => x.Id);
            Map(x => x.Number);
            Map(x => x.Name);
            Map(x => x.Duration).Nullable();

            References(x => x.Album);
        }
    }
}
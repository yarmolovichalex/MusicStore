using FluentNHibernate.Mapping;

namespace MusicStore.Logic.Artists
{
    public class AlbumMap : ClassMap<Album>
    {
        public AlbumMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Year);
            Map(x => x.Price);

            References(x => x.Artist);

            HasMany(x => x.Tracks).Cascade.SaveUpdate().Inverse();
        }
    }
}

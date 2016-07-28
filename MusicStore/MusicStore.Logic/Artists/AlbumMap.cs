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

            References(x => x.Artist);

            Component(x => x.Price, y =>
            {
                y.Map(x => x.Amount);
                y.Map(x => x.Currency);
            });

            HasMany(x => x.Tracks).Cascade.SaveUpdate().Inverse();
        }
    }
}

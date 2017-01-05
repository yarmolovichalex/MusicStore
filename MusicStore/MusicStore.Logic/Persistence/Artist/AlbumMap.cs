using FluentNHibernate;
using FluentNHibernate.Mapping;
using MusicStore.Logic.Model.Artist;

namespace MusicStore.Logic.Persistence.Artist
{
    public class AlbumMap : ClassMap<Album>
    {
        public AlbumMap()
        {
            Id(Reveal.Member<Album>("Id"));
            Map(x => x.Name);
            Map(x => x.Year).Nullable();

            References(x => x.Artist);

            //Component(x => x.Price, y =>
            //{
            //    y.Map(x => x.Amount).Nullable();
            //    y.Map(x => x.Currency).Nullable();
            //});

            HasMany(x => x.Tracks).Cascade.All().Inverse().AsSet();
        }
    }
}

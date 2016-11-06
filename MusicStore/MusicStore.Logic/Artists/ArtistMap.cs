using FluentNHibernate.Mapping;

namespace MusicStore.Logic.Artists
{
    public class ArtistMap : ClassMap<Artist>
    {
        public ArtistMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Unique();
            Map(x => x.Country).Nullable();

            HasMany(x => x.Albums).Cascade.SaveUpdate().Inverse();
        }
    }
}
﻿using FluentNHibernate.Mapping;

namespace MusicStore.Logic.Artists
{
    public class AlbumMap : ClassMap<Album>
    {
        public AlbumMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Year).Nullable();

            References(x => x.Artist);

            Component(x => x.Price, y =>
            {
                y.Map(x => x.Amount).Nullable();
                y.Map(x => x.Currency).Nullable();
            });

            HasMany(x => x.Tracks).Cascade.All().Inverse();
        }
    }
}

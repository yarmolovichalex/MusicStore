﻿using System;
using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.Common;
using MusicStore.Logic.Utils;
using NHibernate;
using NHibernate.Linq;

namespace MusicStore.Logic.Artists
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public Artist GetByName(string name)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Artist>().FirstOrDefault(x => x.Name == name);
            }
        }

        public IList<Artist> GetAll()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Artist>().ToList();
            }
        }

        public void AddAlbum(Guid artistId, Album album)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var artist = session.Get<Artist>(artistId);
                artist.AddAlbum(album);
                session.SaveOrUpdate(artist);
                transaction.Commit();
            }
        }
    }
}

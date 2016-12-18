using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.Common;
using MusicStore.Logic.DTOs.Album;
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
    }
}
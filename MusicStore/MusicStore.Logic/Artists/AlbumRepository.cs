using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.Common;
using MusicStore.Logic.Utils;
using NHibernate;
using NHibernate.Linq;

namespace MusicStore.Logic.Artists
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public IList<Album> GetAll()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Album>().ToList();
            }
        }
    }
}
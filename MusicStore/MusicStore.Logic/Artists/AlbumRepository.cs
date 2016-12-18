using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.Common;
using MusicStore.Logic.DTOs.Album;
using MusicStore.Logic.DTOs.Track;
using MusicStore.Logic.Utils;
using NHibernate;
using NHibernate.Linq;

namespace MusicStore.Logic.Artists
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public IEnumerable<AlbumDTO> GetAll()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Album>().Select(x => new AlbumDTO
                {
                    ArtistName = x.Artist.Name,
                    Name = x.Name,
                    Year = x.Year,
                    Tracks = x.Tracks.Select(y => new TrackDTO
                    {
                        Number = y.Number,
                        Name = y.Name,
                        Duration = y.Duration
                    })
                }).ToList();
            }
        }
    }
}
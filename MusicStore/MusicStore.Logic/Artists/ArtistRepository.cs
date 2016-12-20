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

        public IList<AlbumDTO> GetAllAlbums()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var artists = session.Query<Artist>().FetchMany(x => x.Albums).ThenFetchMany(y => y.Tracks).ToList();

                var result = new List<AlbumDTO>();
                foreach (var artist in artists)
                {
                    result.AddRange(artist.Albums.Select(album => new AlbumDTO
                    {
                        ArtistName = artist.Name,
                        Name = album.Name,
                        Year = album.Year,
                        Tracks = album.Tracks.Select(y => new TrackDTO
                        {
                            Number = y.Number,
                            Name = y.Name,
                            Duration = y.Duration
                        })
                    }));
                }

                return result.ToList();
            }
        }
    }
}
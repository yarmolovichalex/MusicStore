using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.DTO.Album;
using MusicStore.Logic.DTO.Track;
using MusicStore.Logic.Model.Artist;
using MusicStore.Logic.Utils;
using NHibernate;
using NHibernate.Linq;

namespace MusicStore.Logic.Persistence.Artist
{
    public class ArtistRepository : Repository<Model.Artist.Artist>, IArtistRepository
    {
        public Model.Artist.Artist GetByName(string name)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Model.Artist.Artist>().FirstOrDefault(x => x.Name == name);
            }
        }

        public IList<Model.Artist.Artist> GetAll()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Model.Artist.Artist>().ToList();
            }
        }

        public IList<AlbumDTO> GetAllAlbums()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var artists = session.Query<Model.Artist.Artist>().FetchMany(x => x.Albums).ThenFetchMany(y => y.Tracks).ToList();

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
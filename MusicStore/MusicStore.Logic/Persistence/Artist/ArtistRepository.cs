using System;
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

        public AlbumsOfArtistDTO GetAlbumsOfArtistWithTracks(Guid artistId)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var artist = session.Query<Model.Artist.Artist>().Where(x => x.Id == artistId).FetchMany(x => x.Albums).ThenFetchMany(x => x.Tracks).ToList().FirstOrDefault();

                if (artist != null)
                {
                    return new AlbumsOfArtistDTO
                    {
                        ArtistId = artistId,
                        ArtistName = artist.Name,
                        Albums = artist.Albums.Select(album => new AlbumDTO
                        {
                            Name = album.Name,
                            Year = album.Year,
                            CoverUrl = album.CoverUrl,
                            Tracks = album.Tracks.Select(track => new TrackDTO
                            {
                                Number = track.Number,
                                Name = track.Name,
                                Duration = track.Duration
                            })
                        })
                    };
                }

                return null;
            }
        }
    }
}
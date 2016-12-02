using System.Collections.Generic;
using MusicStore.Logic.Common;
using MusicStore.Logic.DTOs.Album;

namespace MusicStore.Logic.Artists
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Artist GetByName(string name);
        IList<Artist> GetAll();
        void AddAlbum(Album album);
        IEnumerable<AlbumDTO> GetAllWithAlbums();
    }
}
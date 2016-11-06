using System.Collections.Generic;
using MusicStore.Logic.Common;
using MusicStore.Logic.DTOs.Album;

namespace MusicStore.Logic.Artists
{
    public interface IAlbumRepository : IRepository<Album>
    {
        IEnumerable<AlbumDTO> GetAll();
    }
}
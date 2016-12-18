using System.Collections.Generic;
using MusicStore.Logic.DTOs.Album;

namespace MusicStore.Logic.Business
{
    public interface IAlbumService
    {
        IEnumerable<AlbumDTO> GetAll();
        void AddAlbum(AlbumDTO album);
    }
}

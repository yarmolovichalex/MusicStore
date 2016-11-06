using MusicStore.Logic.DTOs.Album;

namespace MusicStore.Logic.Business
{
    public interface IArtistService
    {
        void AddAlbum(AddAlbumDTO dto);
    }
}
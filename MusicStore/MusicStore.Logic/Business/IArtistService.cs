using System.Collections.Generic;
using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Album;
using MusicStore.Logic.DTOs.Artist;

namespace MusicStore.Logic.Business
{
    public interface IArtistService
    {
        void AddAlbum(AddAlbumDTO dto);
        void Save(Artist artist);
        IEnumerable<ArtistDTO> GetAll();
        void Save(ICollection<Artist> artists);
    }
}
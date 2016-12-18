using System.Collections.Generic;
using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Artist;

namespace MusicStore.Logic.Business
{
    public interface IArtistService
    {
        void Save(Artist artist);
        IEnumerable<ArtistDTO> GetAll();
        void Save(ICollection<Artist> artists);
    }
}
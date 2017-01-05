using System.Collections.Generic;
using MusicStore.Logic.DTO.Artist;

namespace MusicStore.Logic.Model.Artist
{
    public interface IArtistService
    {
        void Save(Artist artist);
        IEnumerable<ArtistDTO> GetAll();
        void Save(ICollection<EditArtistDTO> artists);
        void Save(ICollection<Artist> artists);
    }
}
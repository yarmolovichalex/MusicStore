using System;
using System.Collections.Generic;

namespace MusicStore.Logic.DTO.Album
{
    public class AlbumsOfArtistDTO
    {
        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<AlbumDTO> Albums { get; set; }
    }
}

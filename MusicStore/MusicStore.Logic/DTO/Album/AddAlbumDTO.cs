using System.Collections.Generic;
using MusicStore.Logic.DTO.Track;

namespace MusicStore.Logic.DTO.Album
{
    public class AddAlbumDTO
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public IEnumerable<AddTrackDTO> Tracks { get; set; }
    }
}
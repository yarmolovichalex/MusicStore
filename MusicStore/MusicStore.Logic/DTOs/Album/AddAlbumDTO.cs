using System.Collections.Generic;
using MusicStore.Logic.DTOs.Track;

namespace MusicStore.Logic.DTOs.Album
{
    public class AddAlbumDTO
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public IEnumerable<AddTrackDTO> Tracks { get; set; }
    }
}
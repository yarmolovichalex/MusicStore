using System.Collections.Generic;
using MusicStore.Logic.DTO.Money;
using MusicStore.Logic.DTO.Track;

namespace MusicStore.Logic.DTO.Album
{
    public class AlbumDTO
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public MoneyDTO Price { get; set; }
        public IEnumerable<TrackDTO> Tracks { get; set; }
    }
}
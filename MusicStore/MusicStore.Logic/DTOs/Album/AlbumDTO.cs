using System.Collections.Generic;
using MusicStore.Logic.DTOs.Money;
using MusicStore.Logic.DTOs.Track;

namespace MusicStore.Logic.DTOs.Album
{
    public class AlbumDTO
    {
        public string ArtistName { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public MoneyDTO Price { get; set; }
        public IEnumerable<TrackDTO> Tracks { get; set; }
    }
}
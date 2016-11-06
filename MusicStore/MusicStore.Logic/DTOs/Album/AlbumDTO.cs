using MusicStore.Logic.DTOs.Money;

namespace MusicStore.Logic.DTOs.Album
{
    public class AlbumDTO
    {
        public string ArtistName { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public MoneyDTO Price { get; set; }
    }
}
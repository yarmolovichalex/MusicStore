using System;

namespace MusicStore.Logic.DTOs.Artist
{
    public class EditArtistDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
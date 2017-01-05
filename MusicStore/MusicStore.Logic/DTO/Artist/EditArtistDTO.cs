using System;

namespace MusicStore.Logic.DTO.Artist
{
    public class EditArtistDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
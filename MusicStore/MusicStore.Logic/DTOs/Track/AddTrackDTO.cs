using System;

namespace MusicStore.Logic.DTOs.Track
{
    public class AddTrackDTO
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }
    }
}
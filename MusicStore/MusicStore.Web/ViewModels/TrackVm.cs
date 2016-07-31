using System;

namespace MusicStore.Web.ViewModels
{
    public class TrackVm
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public Guid ArtistID { get; set; }
        public Guid AlbumID { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace MusicStore.Web.ViewModels
{
    public class AlbumVm
    {
        public string Name { get; set; }
        public Guid ArtistID { get; set; }
        public string ArtistName { get; set; } // TODO remove
        public int? Year { get; set; }
        public MoneyVm Price { get; set; }
        public IEnumerable<TrackVm> Tracks { get; set; }
    }
}
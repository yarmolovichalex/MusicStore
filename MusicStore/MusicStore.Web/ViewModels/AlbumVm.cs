using System.Collections.Generic;

namespace MusicStore.Web.ViewModels
{
    public class AlbumVm
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public MoneyVm Price { get; set; }
        public IEnumerable<TrackVm> Tracks { get; set; }
    }
}
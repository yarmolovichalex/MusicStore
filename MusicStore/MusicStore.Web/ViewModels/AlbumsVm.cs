using System;
using System.Collections.Generic;

namespace MusicStore.Web.ViewModels
{
    public class AlbumsVm
    {
        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<AlbumVm> Albums { get; set; }
    }
}
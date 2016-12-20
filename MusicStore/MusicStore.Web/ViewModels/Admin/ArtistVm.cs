using System;

namespace MusicStore.Web.ViewModels.Admin
{
    public class ArtistVm
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
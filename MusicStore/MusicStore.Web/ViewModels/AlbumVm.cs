namespace MusicStore.Web.ViewModels
{
    public class AlbumVm
    {
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public int Year { get; set; }
        public MoneyVm Price { get; set; }
    }
}
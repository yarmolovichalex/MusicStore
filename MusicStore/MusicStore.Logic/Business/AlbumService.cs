using System.Collections.Generic;
using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Album;

namespace MusicStore.Logic.Business
{
    public class AlbumService : IAlbumService
    {
        private readonly IArtistRepository _artistRepository;

        public AlbumService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public IEnumerable<AlbumDTO> GetAll()
        {
            return _artistRepository.GetAllAlbums();
        }

        public void AddAlbum(AlbumDTO album)
        {
            var artist = _artistRepository.GetByName(album.ArtistName);
            artist?.AddAlbum(new AddAlbumDTO
            {
                Name = album.Name,
                Year = album.Year
            });
        }
    }
}

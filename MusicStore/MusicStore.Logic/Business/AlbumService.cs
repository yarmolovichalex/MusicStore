using System.Collections.Generic;
using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Album;

namespace MusicStore.Logic.Business
{
    public class AlbumService : IAlbumService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository, IArtistRepository artistRepository)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
        }

        public IEnumerable<AlbumDTO> GetAll()
        {
            return _albumRepository.GetAll();
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

using System.Collections.Generic;
using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Album;

namespace MusicStore.Logic.Business
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public IEnumerable<AlbumDTO> GetAll()
        {
            return _albumRepository.GetAll();
        }
    }
}

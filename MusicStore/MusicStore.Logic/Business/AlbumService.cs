using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Album;
using MusicStore.Logic.DTOs.Money;

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
            return _albumRepository.GetAll().Select(x => new AlbumDTO
            {
                ArtistName = _artistRepository.GetById(x.Artist.Id).Name, // TODO
                Name = x.Name,
                Year = x.Year,
                Price = new MoneyDTO
                {
                    Amount = x.Price.Amount,
                    Currency = x.Price.Currency
                }
            });
        }
    }
}

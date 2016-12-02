using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Album;
using MusicStore.Logic.DTOs.Artist;
using MusicStore.Logic.SharedKernel;

namespace MusicStore.Logic.Business
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void AddAlbum(AddAlbumDTO dto)
        {
            var artist = _artistRepository.GetByName(dto.ArtistName);
            if (artist != null)
            {
                _artistRepository.AddAlbum(new Album(dto.Name, artist, dto.Year, new Money(dto.Price.Amount ?? 0m, dto.Price.Currency)));
            }
        }

        public void Save(Artist artist)
        {
            _artistRepository.Save(artist);
        }



        public IEnumerable<ArtistDTO> GetAll()
        {
            return _artistRepository.GetAll().Select(x => new ArtistDTO
            {
                Name = x.Name,
                Country = x.Country
            });
        }

        public void Save(ICollection<Artist> artists)
        {
            _artistRepository.Save(artists);
        }
    }
}
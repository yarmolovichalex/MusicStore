using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Album;
using MusicStore.Logic.SharedKernel;

namespace MusicStore.Logic.Business
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = new ArtistRepository();
        }

        public void AddAlbum(AddAlbumDTO dto)
        {
            var artist = _artistRepository.GetByName(dto.ArtistName);
            if (artist != null)
            {
                _artistRepository.AddAlbum(artist.Id,
                    new Album(dto.Name, artist, dto.Year.Value, new Money(dto.Price.Amount ?? 0m, dto.Price.Currency)));
            }
        }
    }
}
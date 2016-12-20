using System.Collections.Generic;
using System.Linq;
using MusicStore.Logic.Artists;
using MusicStore.Logic.DTOs.Artist;

namespace MusicStore.Logic.Business
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Save(Artist artist)
        {
            _artistRepository.Save(artist);
        }

        public IEnumerable<ArtistDTO> GetAll()
        {
            return _artistRepository.GetAll().Select(x => new ArtistDTO
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country
            });
        }

        public void Save(ICollection<EditArtistDTO> artists)
        {
            foreach (var dto in artists)
            {
                if (dto.Id == null)
                {
                    _artistRepository.Save(new Artist(dto.Name, dto.Country));
                }
                else
                {
                    var artist = _artistRepository.GetById(dto.Id.Value);
                    if (artist != null)
                    {
                        artist.UpdateInfo(dto.Name, dto.Country);
                        _artistRepository.Save(artist);
                    }
                    else
                    {
                        // todo logging and/or notification
                    }
                }
            }
        }

        public void Save(ICollection<Artist> artists)
        {
            _artistRepository.Save(artists);
        }
    }
}
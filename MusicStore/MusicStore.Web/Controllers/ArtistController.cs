using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MusicStore.Logic.Artists;

namespace MusicStore.Web.Controllers
{
    public class ArtistController : ApiController
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistController()
        {
            _artistRepository = new ArtistRepository();
        }

        public IList<ArtistShortVm> GetAllArtists()
        {
            return _artistRepository.GetAll().Select(x => new ArtistShortVm
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }

    public class ArtistShortVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using MusicStore.Logic.DTO.Album;
using MusicStore.Logic.Model.Common;

namespace MusicStore.Logic.Model.Artist
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Artist GetByName(string name);
        IList<Artist> GetAll();
        AlbumsOfArtistDTO GetAlbumsOfArtistWithTracks(Guid artistId);
    }
}
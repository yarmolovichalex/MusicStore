using System.Collections.Generic;
using MusicStore.Logic.Common;

namespace MusicStore.Logic.Artists
{
    public interface IAlbumRepository : IRepository<Album>
    {
        IList<Album> GetAll();
    }
}
using System.Collections.Generic;
using MusicStore.Logic.Common;

namespace MusicStore.Logic.Artists
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Artist GetByName(string name);
        IList<Artist> GetAll();
    }
}

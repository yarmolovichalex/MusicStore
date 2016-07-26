using System;

namespace MusicStore.Logic.Common
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        void Save(T aggregateRoot);
    }
}

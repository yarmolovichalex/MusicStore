using System;
using System.Collections.Generic;

namespace MusicStore.Logic.Model.Common
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        void Save(T entity);
        void Save(ICollection<T> entities);
    }
}
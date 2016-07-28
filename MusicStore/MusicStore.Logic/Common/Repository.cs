using System;
using MusicStore.Logic.Utils;
using NHibernate;

namespace MusicStore.Logic.Common
{
    public abstract class Repository<T> : IRepository<T>
    {
        public T GetById(Guid id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public void Save(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }
    }
}

using System;

namespace MusicStore.Logic.Model.Common
{
    public abstract class IdentifiedValueObject<T> : ValueObject<T> where T : IdentifiedValueObject<T>
    {
        private Guid Id { get; set; }
    }
}

using System;

namespace MusicStore.Logic.Common
{
    public abstract class IdentifiedValueObject<T> : ValueObject<T> where T : IdentifiedValueObject<T>
    {
        private Guid Id { get; set; }
    }
}

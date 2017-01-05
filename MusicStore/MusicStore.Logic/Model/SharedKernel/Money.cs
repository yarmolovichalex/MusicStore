using System;
using MusicStore.Logic.Model.Common;

namespace MusicStore.Logic.Model.SharedKernel
{
    public class Money : ValueObject<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money()
        {
        }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new InvalidOperationException();
            if (string.IsNullOrEmpty(currency))
                throw new InvalidOperationException();

            Amount = amount;
            Currency = currency;
        }

        protected override bool EqualsCore(Money other)
        {
            return Amount == other.Amount
                   && Currency == other.Currency;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Amount.GetHashCode();
                hash = hash * 23 + Currency.GetHashCode();
                return hash;
            }
        }
    }
}

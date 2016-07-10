namespace MusicStore.Logic
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

using System;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class PhoneNumber
    {
        public Guid Id { get; private set; }
        private int Number { get; set; }

        public PhoneNumber(int name)
        {
            Id = Guid.NewGuid();
            Number= name;
        }

        public PhoneNumber GetPhoneNumbers()
        {
            return this;
        }
    }
}

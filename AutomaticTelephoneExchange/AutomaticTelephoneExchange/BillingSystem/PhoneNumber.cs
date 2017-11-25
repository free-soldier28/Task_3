using System;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class PhoneNumber
    {
        public Guid Id { get; private set; }
        public int Number { get; private set; }
        public bool FreeStatus { get; set; } = true;

        public PhoneNumber(int name)
        {
            Id = Guid.NewGuid();
            Number= name;
        }

        public PhoneNumber GetPhoneNumbers()
        {
            return this;
        }

        public void ChangeFreeStatus(bool status)
        {
            FreeStatus = status;
        }

    }
}

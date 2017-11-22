using System;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class Abonent
    {
        public Guid Id { get; private set; }
        private string FIO { get; set; }
        private string PassportId { get; set; }

        public Abonent(string fio, string passportId)
        {
            Id = Guid.NewGuid();
            FIO = fio;
            PassportId = passportId;
        }

        public Abonent GetAbonent()
        {
            return this;
        }

    }
}

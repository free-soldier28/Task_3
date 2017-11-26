using System;
using AutomaticTelephoneExchange.Enum;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class TariffOffer
    {
        public Guid Id {  get; private set; }
        public Tariff Name { get; private set; }
        public double Price { get; private set; }

        public TariffOffer(Tariff tariffName, double price)
        {
            Id = Guid.NewGuid();
            Name = tariffName;
            Price = price;
        }

    }
}

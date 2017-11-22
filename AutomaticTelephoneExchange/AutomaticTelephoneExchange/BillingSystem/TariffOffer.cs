using System;
using AutomaticTelephoneExchange.Enum;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class TariffOffer
    {
        public Guid Id {  get; private set; }
        private Tariff Name { get; set; }
        private double Price { get; set; }

        public TariffOffer(Tariff tariffName, double price)
        {
            Id = Guid.NewGuid();
            Name = tariffName;
            Price = price;
        }

        public TariffOffer GetTariffOffers()
        {
            return this;
        }
    }
}

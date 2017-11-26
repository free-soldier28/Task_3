using System.Collections.Generic;
using AutomaticTelephoneExchange.Enum;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class BillingSystem
    {
        public List<CallDetailing> callDetailing = new List<CallDetailing>();

        public List<TariffOffer> tariffs = new List<TariffOffer>
        {
            new TariffOffer(Tariff.Standart, 0.10),
            new TariffOffer(Tariff.Comfort, 0.30),
            new TariffOffer(Tariff.VIP, 0.50)
        };

    }
}

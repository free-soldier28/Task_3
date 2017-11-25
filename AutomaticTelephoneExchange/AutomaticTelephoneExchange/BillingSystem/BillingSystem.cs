using System;
using System.Collections.Generic;
using System.Linq;
using AutomaticTelephoneExchange.Enum;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class BillingSystem
    {
        public List<Contract> contracts = new List<Contract>();
        public List<CallDetailing> callDetailing = new List<CallDetailing>();


        public List<TariffOffer> tariffs = new List<TariffOffer>
        {
            new TariffOffer(Tariff.Standart, 0.10),
            new TariffOffer(Tariff.Comfort, 0.30),
            new TariffOffer(Tariff.VIP, 0.50)
        };

        public List<PhoneNumber> phoneNumbers = new List<PhoneNumber>
        {
            new PhoneNumber(51501),
            new PhoneNumber(51685),
            new PhoneNumber(51280),
            new PhoneNumber(52889),
            new PhoneNumber(54113),
            new PhoneNumber(57160)
        };

        public Guid GetIdFreePhoneNumber()
        {
            return phoneNumbers.Where(x => x.FreeStatus == true).Select(x=>x.Id).FirstOrDefault();
        }

        public void SetFreePhoneNumber(Guid _id)
        {
            var terminal = phoneNumbers.Where(x => x.Id == _id).FirstOrDefault();
            terminal.ChangeFreeStatus(false);
        }

    }
}

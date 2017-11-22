using System.Collections.Generic;
using AutomaticTelephoneExchange.Enum;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class BillingSystem
    {
        public List<Contract> contracts = new List<Contract>();
        public List<CallDetailing> callDetailing = new List<CallDetailing>();

        public List<Abonent> abonents = new List<Abonent>
        {
            new Abonent("Чижиков А.И", "3210781M064PB6"),
            new Abonent("Петров Ю.Д", "4830781P028KN3"),
            new Abonent("Сериков И.Г", "3212781G013СP8"),
            new Abonent("Иванова Л.Н", "5014602J064AB1"),
            new Abonent("Бубенцов Ю.Б.", "5730781R064PB0")
        };

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

    }
}

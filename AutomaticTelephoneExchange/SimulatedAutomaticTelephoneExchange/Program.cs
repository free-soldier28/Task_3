using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomaticTelephoneExchange.ATE;
using AutomaticTelephoneExchange.BillingSystem;

namespace SimulatedAutomaticTelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Abonent> abonents = new List<Abonent>
            {
                new Abonent("Chizhikov A.I.", "3210781M064PB6"),
                new Abonent("Petrov Y.D", "4830781P028KN3"),
                new Abonent("Serikov I.G.", "3212781G013СP8"),
                new Abonent("Ivanova L.N.", "5014602J064AB1"),
                new Abonent("Bubentsov Y.B.", "5730781R064PB0")
            };

            PhoneExchange phoneExchange = new PhoneExchange();
            BillingSystem bilingSystem = new BillingSystem();

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                var Abonent = abonents[i];
                Guid idFreePhoneNumber = bilingSystem.GetIdFreePhoneNumber(); //Возвращаем id первого свободного номера телефона из коллекции

                int randomNumberTarrid = random.Next(bilingSystem.tariffs.Count); //Рандомно возвращаем номер таррифа из коллекции
                Guid IdRandomTariff = bilingSystem.tariffs[randomNumberTarrid].Id; //Возвращаем id рандомного тарифа

                int randomBalans = random.Next(0, 50); //Разновмно генерируем начальный баланс для абонента

                Guid idFreeTerminal = phoneExchange.GetIdFreeTerminal(); //Возвращаем id свободного терминала
                Guid idFreePort = phoneExchange.GetIdFreePort(); //Возвращаем id свободного порта АТС

                //Заключение договоров с клиентами
                bilingSystem.contracts.Add(new Contract(Abonent.Id, idFreePhoneNumber, IdRandomTariff, randomBalans, idFreeTerminal, idFreePort));
                phoneExchange.SetFreeStatusPort(idFreePort);
                phoneExchange.SetFreeStatusTerminal(idFreeTerminal);
                bilingSystem.SetFreePhoneNumber(idFreePhoneNumber);

                string nameTarrif = bilingSystem.tariffs.Where(x => x.Id == IdRandomTariff).Select(z => z.Name).FirstOrDefault().ToString();
                Console.WriteLine("Abonent " + Abonent.FIO + " concluded a contract for the tariff plan " + nameTarrif);
            }

            Console.ReadKey();
        }
    }
}

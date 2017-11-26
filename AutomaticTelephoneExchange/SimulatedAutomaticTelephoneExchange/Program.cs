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

            for (int i = 0; i < abonents.Count - 1; i++)
            {
                var abonent = abonents[i];
                
                var freePort = phoneExchange.GetFreePort(); //Находим свободный порт
                var freeTerminal = phoneExchange.GetFreeTerminal(freePort); //Находим свободный терминал
                var _freePhoneNumber = phoneExchange.GetFreePhoneNumber(); //Находим свободный номер телефона

                int _randomNumberTarrid = random.Next(bilingSystem.tariffs.Count); //Рандомно возвращаем номер таррифа из коллекции
                var randomTariff = bilingSystem.tariffs[_randomNumberTarrid]; //Рандомно возвращаем тариф

                int randomBalans = random.Next(0, 50); //Разновмно генерируем начальный баланс для абонента

                //Заключение договора с клиентом
                phoneExchange.contracts.Add(new Contract(abonent.Id, _freePhoneNumber, randomTariff.Id, randomBalans, freeTerminal.Id, freePort.Id));

                //Выдаем абоненту терминал и порт
                freeTerminal.Port = freePort;
                abonent.Terminal = freeTerminal;

                //Добавляем в коллеции АТС порт, телефон и номер абонента
                phoneExchange.allocatedTerminals.Add(freePort, freeTerminal);
                phoneExchange.allocatedPhoneNumber.Add(_freePhoneNumber, freeTerminal);

                Console.WriteLine("Abonent " + abonent.FIO + " concluded a contract for the tariff plan " + randomTariff.Name);
            }

            //Подключение к порту телефона абонентом
            var randomNumberAbonent = random.Next(0, abonents.Count - 1);
            var randomAbonent = abonents[randomNumberAbonent];
            randomAbonent.ConnectTerminalToPort();

            //Отключение от порта телефона абонентом
            randomNumberAbonent = random.Next(0, abonents.Count - 1);
            randomAbonent = abonents[randomNumberAbonent];
            randomAbonent.DisconnectTerminalToPort();

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomaticTelephoneExchange;
using AutomaticTelephoneExchange.ATE;
using AutomaticTelephoneExchange.BillingSystem;

namespace SimulatedAutomaticTelephoneExchange
{
    public class Program
    {
        public static PhoneExchange phoneExchange;
        public static BillingSystem bilingSystem;

        static void Main(string[] args)
        {
            int randomNumberAbonent;
            Abonent randomAbonent;

            Console.OutputEncoding = Encoding.UTF8;

            List<Abonent> abonents = new List<Abonent>
            {
                new Abonent("Chizhikov A.I.", "3210781M064PB6"),
                new Abonent("Petrov Y.D", "4830781P028KN3"),
                new Abonent("Serikov I.G.", "3212781G013СP8"),
                new Abonent("Ivanova L.N.", "5014602J064AB1"),
                new Abonent("Bubentsov Y.B.", "5730781R064PB0")
            };

            phoneExchange = new PhoneExchange();
            bilingSystem = new BillingSystem();

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

                abonent.Terminal.Port.PortState += Show_Message; //Подписываемся на события порта абонета

                //Добавляем в коллеции АТС терминал и номер абонента
                phoneExchange.allocatedPhoneNumber.Add(_freePhoneNumber, freeTerminal);
                phoneExchange.allocatedTerminals.Add(freePort, freeTerminal);

                Console.WriteLine("Abonent " + abonent.FIO + " concluded a contract for the tariff plan " + randomTariff.Name);
                abonent.ConnectTerminalToPort(); //Подключение к порту телефона абонентом
            }

            //Исходящий вызов абонента
            randomNumberAbonent = random.Next(0, abonents.Count - 1);
            randomAbonent = abonents[randomNumberAbonent];

            var randomNumberPhoneNumber = random.Next(0, phoneExchange.phoneNumbers.Count - 1);
            string randomPhoneNumber = phoneExchange.phoneNumbers[randomNumberPhoneNumber];
            randomAbonent.OutboundСall(randomPhoneNumber);

            //Завершение звонка
            randomAbonent.EndCall();

            //Отключение от порта телефона абонентом
            randomNumberAbonent = random.Next(0, abonents.Count - 1);
            randomAbonent = abonents[randomNumberAbonent];
            randomAbonent.DisconnectTerminalToPort();

            Console.ReadKey();
        }

        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}

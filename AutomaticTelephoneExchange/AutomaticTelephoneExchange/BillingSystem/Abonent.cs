using System;
using AutomaticTelephoneExchange.ATE;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class Abonent
    {
        public Guid Id { get; private set; }
        public string FIO { get; private set; }
        private string PassportId { get; set; }
        public Terminal Terminal { get; set; }
        
        public Abonent(string _fio, string _passportId)
        {
            Id = Guid.NewGuid();
            FIO = _fio;
            PassportId = _passportId;
        }

        public void ConnectTerminalToPort()
        {
           Console.WriteLine("Abonent "+ FIO + " connected the terminal to the port");
        }

        public void DisconnectTerminalToPort()
        {
            Console.WriteLine("Abonent " + FIO + " disconnected the terminal from the port");
        }

        public void OutboundСall(string _numberPhone) //Исходящий вызов
        {
            Console.WriteLine("");
        }

        public void IncomingCall(string _numberPhone) //Входящий вызов
        {
            Console.WriteLine("");
        }


        public void EndCall()
        {

        }

    }
}

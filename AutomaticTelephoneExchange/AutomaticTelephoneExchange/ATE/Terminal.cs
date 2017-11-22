using System;
using System.Linq;

namespace AutomaticTelephoneExchange.ATE
{
    public class Terminal
    {
        public Guid Id { get; private set; }
        public Guid IdPort { get; private set; }

        public Terminal()
        { 
            Id = Guid.NewGuid();
        }

        public void ConnectToPort(Guid _idPort)
        {
            IdPort = _idPort;
        }

        public void DisconnectToPort()
        {
            IdPort = Guid.Empty;
        }

        public void MakeCall(string _phoneNumber)
        {
            if (!_phoneNumber.Any())
            {
                Console.WriteLine("Разговор начат");
            }
            else
            {
                Console.WriteLine("Абонент занят");
            }         
        }

        public void EndCall()
        {
            Console.WriteLine("Разговор окончен");
        }

    }
}

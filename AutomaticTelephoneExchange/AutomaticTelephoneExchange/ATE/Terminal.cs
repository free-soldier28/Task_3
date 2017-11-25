using System;
using System.Linq;

namespace AutomaticTelephoneExchange.ATE
{
    public class Terminal
    {
        public Guid Id { get; private set; }
        public Guid IdPort { get; private set; }
        public bool FreeStatus { get; private set; } = true;

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

        public Terminal GetTerminal()
        {
            return this;
        }

        public void ChangeFreeStatus(bool status)
        {
            FreeStatus = status;
        }
    }
}

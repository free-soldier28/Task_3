using System;
using System.Linq;

namespace AutomaticTelephoneExchange.ATE
{
    public class Terminal
    {
        public Guid Id { get; private set; }
        public Port Port { get; set; }

        public Terminal()
        { 
            Id = Guid.NewGuid();
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

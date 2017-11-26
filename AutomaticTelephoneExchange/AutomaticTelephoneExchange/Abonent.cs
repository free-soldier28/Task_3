using System;
using System.Linq;
using AutomaticTelephoneExchange.ATE;

namespace AutomaticTelephoneExchange
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
            if (Terminal.Port.ConnectionTerminal == false)
            {
                Terminal.Port.Connect(FIO);
            }
            else
            {
                Console.WriteLine("Warning!!! The terminal is already connected to the port.");
            }
        }

        public void DisconnectTerminalToPort()
        {
            if (Terminal.Port.ConnectionTerminal == true)
            {
                Terminal.Port.Disconnect(FIO);
            }
            else
            {
                Console.WriteLine("Warning!!! The terminal is already disconnected from the port.");
            }
            
        }
     
        public void OutboundСall(string _numberPhone)  //Исходящий вызов
        {
            if (_numberPhone != null)
            {
                Terminal.Port.OutboundСall(FIO, _numberPhone);
            }
            else
            {
                Console.WriteLine("A call can not be made. You did not enter a phone number.");
            }

        }

        public void IncomingCall() //Входящий вызов
        {
            Terminal.Port.IncomingCall();
        }

        public void EndCall() //Закончить звонок
        {
            Terminal.Port.EndCall(FIO);
        }

    }
}

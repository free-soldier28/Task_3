using System;
using AutomaticTelephoneExchange.ATE;

namespace AutomaticTelephoneExchange
{
    public class Abonent
    {
        public Guid Id { get; private set; }
        public string FIO { get; private set; }
        private string PassportId { get; set; }
        public Terminal Terminal { get; set; }
        
        public Abonent(string fio, string passportId)
        {
            Id = Guid.NewGuid();
            FIO = fio;
            PassportId = passportId;
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

        public void OutboundСall(Abonent interlocutor)  //Исходящий вызов
        {
            if (interlocutor != null)
            {
                Terminal.Port.OutboundСall(FIO, interlocutor);
            }
            else
            {
                Console.WriteLine("A call can not be made. You did not enter a phone number.");
            }

        }

        public void EndCall() //Закончить звонок
        {
            Terminal.Port.EndCall(FIO);
        }

    }
}

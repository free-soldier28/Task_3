using System;
using AutomaticTelephoneExchange.ATE;

namespace AutomaticTelephoneExchange
{
    public class Abonent
    {
        public Guid Id { get; private set; }
        public string FIO { get; private set; }
        private string PassportId { get; set; }
        private Terminal Terminal { get; set; }
        
        public Abonent(string fio, string passportId)
        {
            Id = Guid.NewGuid();
            FIO = fio;
            PassportId = passportId;
        }

        public void AssignTerminal(Terminal terminal)
        {
            Terminal = terminal;
        }

        public void ConnectTerminalToPort()
        {
            Terminal.ConnectToPort(FIO);
        }

        public void DisconnectTerminalToPort()
        {
            Terminal.DisconnectToPort(FIO);
        }

        public void OutboundСall(string phoneNumberInterlocutor)  
        {
            Terminal.OutboundСallToPort(FIO, phoneNumberInterlocutor);
        }

        public void EndCall() 
        {
            Terminal.EndCallToPort(FIO);
        }

    }
}

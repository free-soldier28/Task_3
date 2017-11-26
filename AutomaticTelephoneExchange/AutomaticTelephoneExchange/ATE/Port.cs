using System;

namespace AutomaticTelephoneExchange.ATE
{
    public class Port
    {
        public Guid Id { get; private set; }
        private bool ConnectionTerminal { get; set; } = false;
        private bool CallStatus { get; set; }

        public Port()
        {
            Id = Guid.NewGuid();
        }

        public void Connect()
        {
            ConnectionTerminal = true;
        }

        public void Disconnect()
        {
            ConnectionTerminal = false;
        }

        public bool GetConnectionStatus()
        {
            return ConnectionTerminal;
        }


        public bool GetCallStatus()
        {
            return CallStatus;
        }

    }
}

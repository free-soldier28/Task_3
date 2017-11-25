using System;

namespace AutomaticTelephoneExchange.ATE
{
    public class Port
    {
        public Guid Id { get; private set; }
        public Guid IdTerminal { get; private set; }
        private bool Connection { get; set; } = false;
        private bool CallStatus { get; set; }
        public bool FreeStatus { get; private set; } = true;

        public Port()
        {
            Id = Guid.NewGuid();
        }

        public void Connect()
        {
            Connection = true;
        }

        public void Disconnect()
        {
            Connection = false;
        }

        public bool GetConnectionStatus()
        {
            return Connection;
        }

        public bool GetCallStatus()
        {
            return CallStatus;
        }

        public Port GetPort()
        {
            return this;
        }

        public void ChangeFreeStatus(bool status)
        {
            FreeStatus = status;
        }

    }
}

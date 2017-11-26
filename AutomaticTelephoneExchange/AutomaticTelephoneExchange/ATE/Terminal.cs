using System;

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

    }
}

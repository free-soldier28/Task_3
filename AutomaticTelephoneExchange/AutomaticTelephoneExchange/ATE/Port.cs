using System;

namespace AutomaticTelephoneExchange.ATE
{
    public class Port
    {
        public Guid Id { get; private set; }
        public bool ConnectionTerminal { get; private set; } 
        private bool StatusCall { get; set; } = false;

        public delegate void PortStatus(string message);
        public event PortStatus PortState;

        public Port()
        {
            Id = Guid.NewGuid();
            ConnectionTerminal = false;
        }

        public void Connect(string fio)
        {
            ConnectionTerminal = true;

            if (PortState != null)
            {
                PortState($"Abonent " + fio + " connected the terminal to the port");
            }
        }

        public void Disconnect(string fio)
        {
            ConnectionTerminal = false;

            if (PortState != null)
            {
                PortState($"Abonent " + fio + " disconnected the terminal from the port");
            }
        }

        //Исходящий вызов
        public void OutboundСall(string fio, Abonent interlocutor)
        {
            if (ConnectionTerminal == true)
            {
                if (PortState != null)
                {
                    PortState($"Abonent " + fio + " calls the subscriber " + interlocutor.FIO );
                    IncomingCall(interlocutor); 
                }
            }
            else
            {
                PortState($"A call can not be made. The subscriber terminal is not connected to the port.");
            }
        }

        //Входящий выхов
        public void IncomingCall(Abonent interlocutor)
        {
            if (ConnectionTerminal == true)
            {
                if (StatusCall == false)
                {
                    StatusCall = true;
                    PortState($"Abonent " + interlocutor.FIO + " accepts a call");
                }
                else
                {
                    PortState($"Subscriber is busy.");
                }
            }
            else
            {
                PortState($"A call can not be made. The subscriber terminal is not connected to the port.");
            }


         }

        //Закончить звонок
        public void EndCall(string fio)
        {
            StatusCall = false;
            PortState($"Abonent " + fio + " the call ended.");
        }

    }
}

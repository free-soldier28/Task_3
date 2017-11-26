﻿using System;

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

        public void Connect(string _fio)
        {
            ConnectionTerminal = true;

            if (PortState != null)
            {
                PortState($"Abonent " + _fio + " connected the terminal to the port");
            }
        }

        public void Disconnect(string _fio)
        {
            ConnectionTerminal = false;

            if (PortState != null)
            {
                PortState($"Abonent " + _fio + " disconnected the terminal from the port");
            }
        }

        //Исходящий вызов
        public void OutboundСall(string _fio, string _numberPhone)
        {
            if (ConnectionTerminal == true)
            {
                StatusCall = true;

                if (PortState != null)
                {
                    PortState($"Abonent " + _fio + " talking with the subscriber " + _numberPhone);
                }
            }
            else
            {
                PortState($"A call can not be made. The subscriber terminal is not connected to the port.");
            }
        }

        //Входящий выхов
        public void IncomingCall()
        {
            if (StatusCall != true)
            {
                PortState($"Abonent disconnected the terminal from the port");
            }
            else
            {
                PortState($"Subscriber is busy.");
            }

        }

        //Закончить звонок
        public void EndCall(string _fio)
        {
            StatusCall = false;
            PortState($"Abonent " + _fio + " the call ended.");
        }

        public bool GetConnectionStatus()
        {
            return ConnectionTerminal;
        }
    }
}

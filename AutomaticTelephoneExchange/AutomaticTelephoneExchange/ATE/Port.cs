using System;

namespace AutomaticTelephoneExchange.ATE
{
    public class Port
    {
        public Guid Id { get; private set; }
        public bool ConnectionTerminal { get; private set; } = false;
        public bool TalkState { get; private set; } = false; //Состояние разговара

        public delegate void PortStatus(string message);
        public delegate void CallStatus(string message, string phoneNumberInterlocutor);
        public event PortStatus PortStateEvent;
        public event CallStatus CallStateEvent;

        public Port()
        {
            Id = Guid.NewGuid();
        }

        public void Connect(string fio)
        {
            ConnectionTerminal = true;

            if (PortStateEvent != null)
            {
                PortStateEvent($"Abonent " + fio + " connected the terminal to the port."); //Сообщение: "Абонент ФИО подключил терминал к порту"
            }
        }

        public void Disconnect(string fio)
        {
            ConnectionTerminal = false;

            if (PortStateEvent != null)
            {
                PortStateEvent($"Abonent " + fio + " disconnected the terminal from the port.");  //Сообщение: "Абонент ФИО отключил терминал от порта"
            }
        }

        //Исходящий вызов
        public void OutboundСall(string fio, string phoneNumberInterlocutor)
        {
            if (CallStateEvent != null)
            {
                TalkState = true;
                CallStateEvent($"Abonent " + fio + " calls the caller by phone number " + phoneNumberInterlocutor, phoneNumberInterlocutor); // Сообщение: "Абонент ФИО вызывает абонета по номеру телефона"
            }
        }

        //Входящий вызов
        public void IncomingCall(string phoneNumberInterlocutor, Terminal terminalInterlocutor)
        {
            TalkState = true;
            terminalInterlocutor.IncomingСall();
         }

        //Закончить звонок
        public void EndCall(string fio)
        {
            TalkState = false;
            PortStateEvent($"Abonent " + fio + " the call ended.");
        }

    }
}

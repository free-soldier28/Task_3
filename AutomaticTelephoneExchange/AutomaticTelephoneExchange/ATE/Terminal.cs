using System;

namespace AutomaticTelephoneExchange.ATE
{
    public class Terminal
    {
        public delegate void Call(string message);
        public event Call IncomingСallEvent;

        public Guid Id { get; private set; }
        private Port Port { get; set; }

        public Terminal()
        {
            Id = Guid.NewGuid();
            IncomingСallEvent += IncomingСallMessage;
        }

        public void AssignPort(Port port)
        {
            Port = port;
        }

        public void ConnectToPort(string FIO)
        {
            if (Port.ConnectionTerminal == false)
            {
                Port.Connect(FIO);
            }
            else
            {
                Console.WriteLine("Warning!!! The terminal is already connected to the port."); // Сообщение: "Предупреждение!!! Терминал уже подключен к порту"
            }
        }

        public void DisconnectToPort(string FIO)
        {
            if (Port.ConnectionTerminal == true)
            {
                Port.Disconnect(FIO);
            }
            else
            {
                Console.WriteLine("Warning!!! The terminal is already disconnected from the port."); //Сообщение: "Предупреждение!!! Терминал уже отсоединен от порта"
            }
        }

        public void OutboundСallToPort(string FIO, string phoneNumberInterlocutor)  //Исходящий вызов
        {
            if (Port.ConnectionTerminal == true)
            {
                if (phoneNumberInterlocutor != "")
                {
                    Port.OutboundСall(FIO, phoneNumberInterlocutor);
                }
                else
                {
                    Console.WriteLine("A call can not be made. You did not enter a phone number."); //Сообщение: "Вызов невозможен. Вы не указали номер телефона"
                }
            }
            else
            {
                Console.WriteLine("You can not make calls. the terminal is not connected to the port"); //Сообщение: "Вы не можете делать звонки. терминал не подключен к порту"  
            }
        }

        public void EndCallToPort(string FIO) //Закончить звонок
        {
            Port.EndCall(FIO);
        }

        public void IncomingСall() //Входящий вызов 
        {
            IncomingСallEvent($"Abonent received an incoming call"); // Сообщение: "Абонент ФИО принял входящий вызов"
        }


        private static void IncomingСallMessage(string message) // обрабатываем событие входящего вызова
        {
            Console.WriteLine(message);
        }

    }
}

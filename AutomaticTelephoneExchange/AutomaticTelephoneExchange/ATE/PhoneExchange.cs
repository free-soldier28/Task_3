using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticTelephoneExchange.ATE
{
    public class PhoneExchange
    {
        private List<Contract> contracts = new List<Contract>();
        private List<Port> ports = new List<Port>();
        private List<Terminal> terminals = new List<Terminal>();

        private static Dictionary<Port, Terminal> allocatedTerminals = new Dictionary<Port, Terminal>();
        private static Dictionary<string, Terminal> allocatedPhoneNumber = new Dictionary<string, Terminal>();

        public void CreatePorts(int countPorts)
        {
            for (int i = 0; i < countPorts; i++)
            {
                var port = new Port();
                port.PortStateEvent += Show_Message;
                port.CallStateEvent += PortCallEvent;
                ports.Add(port);
            }
        }

        public void CreateTerminals(int countTermilals)
        {
            for (int i = 0; i < countTermilals; i++)
            {
                var terminal = new Terminal();
                terminals.Add(terminal);
            }
        }

        public List<string> phoneNumbers = new List<string>
        {
            "51501", "51685", "51280","52889", "54113", "57160"
        };

        public void CreateContract(Contract contract, string phoneNumber, Terminal terminal, Port port)
        {
            contracts.Add(contract);

            allocatedPhoneNumber.Add(phoneNumber, terminal);
            allocatedTerminals.Add(port, terminal);
        }

        public Port GetFreePort()
        {
            Port freePort = null;
            Port temp;

            foreach (var port in ports)
            {
                temp = allocatedTerminals.Where(x => x.Key.Id == port.Id).Select(z=>z.Key).FirstOrDefault();
                if (temp == null)
                {
                    freePort = port;
                    break;
                }
            }
            return freePort;
        }

        public Terminal GetFreeTerminal(Port port)
        {
            Terminal freeTerminal = null;
            Terminal temp;

            foreach (var terminal in terminals)
            {
                temp = allocatedTerminals.Where(x => x.Key.Id == port.Id).Select(z=>z.Value).FirstOrDefault();

                if (temp == null)
                {
                    freeTerminal = terminal;
                    break;
                }
            }
            return freeTerminal;
        }

        public string GetFreePhoneNumber()
        {
            string PhoneNumber = null;
            string temp;

            foreach (var phoneNumber in phoneNumbers)
            {
                temp = allocatedPhoneNumber.Where(x => x.Key == phoneNumber).Select(z=>z.Key).FirstOrDefault();

                if (temp == null)
                {
                    PhoneNumber = phoneNumber;
                    break;
                }
            }
            return PhoneNumber;
        }


        //Обрабатываем события порта вызываемого абонента
        private static void PortCallEvent(string message, string phoneNumber)
        {
            Console.WriteLine(message);

            Terminal terminalInterlocutor = allocatedPhoneNumber.Where(x => x.Key == phoneNumber).Select(z => z.Value).FirstOrDefault();
            Port portInterlocutor = allocatedTerminals.Where(x => x.Value.Id == terminalInterlocutor.Id).Select(z => z.Key).FirstOrDefault();

            if (portInterlocutor.ConnectionTerminal == true)
            {
                if (portInterlocutor.TalkState == false)
                {
                    portInterlocutor.IncomingCall(phoneNumber, terminalInterlocutor);
                }
                else
                {
                    Console.WriteLine("Line is busy."); //Сообщение: "Линия занята"
                }
            }
            else
            {
                Console.WriteLine("The subscriber terminal is not connected to the port."); //Сообщение: "Терминал абонета не подключен к порту"
            }
        }

        //Обработка событий порта вызывающего абонета
        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
    }


}

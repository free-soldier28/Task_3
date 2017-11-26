using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticTelephoneExchange.ATE
{
    public class PhoneExchange
    {
        public List<Port> ports = new List<Port>
        {
            new Port(),
            new Port(),
            new Port(),
            new Port(),
            new Port(),
            new Port()
        };

        public List<Terminal> terminals = new List<Terminal>
        {
            new Terminal(),
            new Terminal(),
            new Terminal(),
            new Terminal(),
            new Terminal(),
            new Terminal()
        };

        public List<string> phoneNumbers = new List<string>
        {
            "A51501", "51685", "51280","52889", "54113", "57160"
        };

        public List<Contract> contracts = new List<Contract>();
        public Dictionary<Port, Terminal> allocatedTerminals = new Dictionary<Port, Terminal>();
        public Dictionary<string, Terminal> allocatedPhoneNumber = new Dictionary<string, Terminal>();

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

        public Terminal GetFreeTerminal(Port _port)
        {
            Terminal freeTerminal = null;
            Terminal temp;
            foreach (var terminal in terminals)
            {
                temp = allocatedTerminals.Where(x => x.Key.Id == _port.Id).Select(z=>z.Value).FirstOrDefault();
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

        //public void ConnectTerminalToPort()
        //{
        //    Console.WriteLine("Abonent " + FIO + " connected the terminal to the port");
        //}

        //public void DisconnectTerminalToPort()
        //{
        //    Console.WriteLine("Abonent " + FIO + " disconnected the terminal from the port");
        //}

    }
}

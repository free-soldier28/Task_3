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
 
        public Guid GetIdFreePort()
        {
            return ports.Where(x => x.FreeStatus == true).Select(z => z.Id).FirstOrDefault();
        }

        public Guid GetIdFreeTerminal()
        {
            return terminals.Where(x => x.FreeStatus == true).Select(z => z.Id).FirstOrDefault();
        }

        public void SetFreeStatusPort(Guid _id)
        {
            var port = ports.Where(x => x.Id == _id).FirstOrDefault();
            port.ChangeFreeStatus(false);
        }

        public void SetFreeStatusTerminal(Guid _id)
        {
           var terminal = terminals.Where(x => x.Id == _id).FirstOrDefault();
           terminal.ChangeFreeStatus(false);
        }
    }
}

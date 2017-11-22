using System.Collections.Generic;

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
    }
}

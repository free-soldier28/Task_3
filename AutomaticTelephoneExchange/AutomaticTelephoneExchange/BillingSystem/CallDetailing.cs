using System;

namespace AutomaticTelephoneExchange.BillingSystem
{
    public class CallDetailing
    {
        public Guid Id { get; private set; }
        private Guid IdAbonent { get; set; }
        private Guid IdInterlocutor { get; set; } // Собеседник
        private DateTime TimeBeginCall { get; set; }
        private DateTime TimeEndCall { get; set; }


        public CallDetailing(Guid idAbonent, Guid idInterlocutor, DateTime timeBegin, DateTime timeEnd)
        {
            IdAbonent = idAbonent;
            IdInterlocutor = idInterlocutor;
            TimeBeginCall = timeBegin;
            TimeEndCall = timeEnd;
        }

    }
}

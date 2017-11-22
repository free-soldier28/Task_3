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


        public CallDetailing(Guid _idAbonent, Guid _idInterlocutor, DateTime _timeBegin, DateTime _timeEnd)
        {
            IdAbonent = _idAbonent;
            IdInterlocutor = _idInterlocutor;
            TimeBeginCall = _timeBegin;
            TimeEndCall = _timeEnd;
        }

    }
}

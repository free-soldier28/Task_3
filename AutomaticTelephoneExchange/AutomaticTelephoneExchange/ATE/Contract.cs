using System;

namespace AutomaticTelephoneExchange.ATE
{
    public class Contract
    {
        public Guid Id { get; private set; }
        public Guid IdAbonent { get; private set; }
        public string PhoneNumber { get; private set; }
        private Guid IdTariff { get; set; }
        public Guid IdTerminal { get; private set; }
        public Guid IdPort { get; private set; }
        private DateTime DateLastTariffChange { get; set; }
        private int Balance { get; set; }


        public Contract(Guid _idAbonent, string _phoneNumber, Guid _idTariff, int _balance, Guid _idTerminal, Guid _idPort)
        {
            Id = Guid.NewGuid();
            IdAbonent = _idAbonent;
            PhoneNumber = _phoneNumber;
            IdTariff = _idTariff;
            Balance = _balance;
            IdTerminal = _idTerminal;
            IdPort = _idPort;
            DateLastTariffChange = DateTime.Now;
        }

        public bool ChangeTariff(Guid _idTariff)
        {
            DateTime date = DateTime.Now.Date;
            
            if (date.Month != DateLastTariffChange.Month)
            {
                IdTariff = _idTariff;
                DateLastTariffChange = date;

                Console.WriteLine("Тарифный план успешно измененю");
                return true;
            }
            else
            {
                Console.WriteLine("Тарифный план не изменен, т.к. доступен для изменения не чаще одного раза в месяц.");
                return false;
            }
        }

        public void UpBalans(int _amountPayment)
        {
            Balance = +_amountPayment;
        }

        protected Contract GetContract()
        {
            return this;
        }

    }
}

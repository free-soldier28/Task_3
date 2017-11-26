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


        public Contract(Guid idAbonent, string phoneNumber, Guid idTariff, int balance, Guid idTerminal, Guid idPort)
        {
            Id = Guid.NewGuid();
            IdAbonent = idAbonent;
            PhoneNumber = phoneNumber;
            IdTariff = idTariff;
            Balance = balance;
            IdTerminal = idTerminal;
            IdPort = idPort;
            DateLastTariffChange = DateTime.Now;
        }

        public bool ChangeTariff(Guid idTariff)
        {
            DateTime date = DateTime.Now.Date;
            
            if (date.Month != DateLastTariffChange.Month)
            {
                IdTariff = idTariff;
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

        public void UpBalans(int amountPayment)
        {
            Balance = + amountPayment;
        }

        protected Contract GetContract()
        {
            return this;
        }

    }
}

using System;

namespace _1_Adapter.Adapter.Transaction
{
    public class Transaction
    {
        public Transaction(DateTime date, double betrag, int kontoidsender, int kontoidempfänger)
        {
            Date = date;
            Betrag = betrag;
            KontoIdSender = kontoidsender;
            KontoIdEmpfänger = kontoidempfänger;
        }
        public Transaction()
        {

        }
        public DateTime Date { get; set; }
        public double Betrag { get; set; }
        public int KontoIdSender { get; set; }
        public int KontoIdEmpfänger { get; set; }
    }
}

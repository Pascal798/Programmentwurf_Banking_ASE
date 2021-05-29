using System;
using Microsoft.VisualBasic;

namespace _3_Domain.Domain.Value_Objects
{
    public sealed class TransactionVO
    {
        public TransactionVO(DateTime date, double betrag, int kontoIdSender, int kontoIdEmpfänger)
        {
            Date = date;
            Betrag = betrag;
            KontoIdSender = kontoIdSender;
            KontoIdEmpfänger = kontoIdEmpfänger;
        }
        public DateTime Date { get; set; }
        public double Betrag { get; set; }
        public int KontoIdSender { get; set; }
        public int KontoIdEmpfänger { get; set; }
        public DateTime getDate()
        {
            return Date;
        }

        public double getBetrag()
        {
            return Betrag;
        }
        public int getKontoIdSender()
        {
            return KontoIdSender;
        }
        public int getKontoIdEmpfänger()
        {
            return KontoIdEmpfänger;
        }
    }
}

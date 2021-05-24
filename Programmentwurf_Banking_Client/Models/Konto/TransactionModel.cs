using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmentwurf_Banking_Client.Models.Konto
{
    public class TransactionModel
    {
        public TransactionModel(DateTime date, double betrag, int kontoIdSender, int kontoIdEmpfänger)
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
    }
}

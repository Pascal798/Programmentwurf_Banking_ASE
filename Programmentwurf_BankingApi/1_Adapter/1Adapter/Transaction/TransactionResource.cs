using Programmentwurf_BankingApi._3Domain.Value_Objects;
using Programmentwurf_BankingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.Transaction
{
    public class TransactionResource
    {
        public TransactionResource(DateTime date, double betrag, int kontoidsender, int kontoidempfänger)
        {
            Date = date;
            Betrag = betrag;
            KontoIdSender = kontoidsender;
            KontoIdEmpfänger = kontoidempfänger;
        }
        public TransactionResource()
        {

        }
        public DateTime Date { get; set; }
        public double Betrag { get; set; }
        public int KontoIdSender { get; set; }
        public int KontoIdEmpfänger { get; set; }
    }
}

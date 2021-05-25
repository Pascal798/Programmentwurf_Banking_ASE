using Programmentwurf_BankingApi._3Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Domain.Entities
{
    public class TransactionEntity
    {
        public TransactionEntity() { }
        public TransactionEntity(DateTime date, double betrag, int senderid, int empfängerid)
        {
            Date = date;
            TransactionInfo = new TransactionVO(betrag, senderid, empfängerid);
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TransactionVO TransactionInfo { get; set; }
    }
}

using System;
using _3_Domain.Domain.Value_Objects;

namespace _3_Domain.Domain.Aggregates
{
    public class TransactionAggregate
    {
        public TransactionAggregate() { }
        public TransactionAggregate(DateTime date, double betrag, int senderid, int empfängerid)
        {
            TransactionInfo = new TransactionVO(date, betrag, senderid, empfängerid);
        }

        public int Id { get; set; }
        public TransactionVO TransactionInfo { get; set; }
    }
}

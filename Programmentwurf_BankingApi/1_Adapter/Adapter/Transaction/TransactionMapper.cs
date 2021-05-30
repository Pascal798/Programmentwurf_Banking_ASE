using System.Collections.Generic;
using _3_Domain.Domain.Aggregates;

namespace _1_Adapter.Adapter.Transaction
{
    public class TransactionMapper
    {
        private static TransactionMapper instance;

        public static TransactionMapper getInstance()
        {
            if(instance == null)
            {
                instance = new TransactionMapper();
            }
            return instance;
        }
        public Transaction apply(TransactionAggregate transaction)
        {
            return map(transaction);
        }

        private Transaction map(TransactionAggregate transaction)
        {
            return new Transaction(
                transaction.TransactionInfo.getDate(),
                transaction.TransactionInfo.getBetrag(),
                transaction.TransactionInfo.getKontoIdSender(),
                transaction.TransactionInfo.getKontoIdEmpfänger());
        }

        public List<Transaction> convertToTransactionResourceList(List<TransactionAggregate> transactionEntities)
        {
            var transactionlist = new List<Transaction>();
            foreach (var transactionEntity in transactionEntities)
            {
                transactionlist.Add(new Transaction(
                    transactionEntity.TransactionInfo.getDate(), 
                    transactionEntity.TransactionInfo.getBetrag(), 
                    transactionEntity.TransactionInfo.getKontoIdSender(), 
                    transactionEntity.TransactionInfo.getKontoIdEmpfänger()));
            }
            return transactionlist;
        }
    }
}

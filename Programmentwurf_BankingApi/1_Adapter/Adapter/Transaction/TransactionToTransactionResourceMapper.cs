using System.Collections.Generic;
using _3_Domain.Domain.Aggregates;

namespace _1_Adapter.Adapter.Transaction
{
    public class TransactionToTransactionResourceMapper
    {
        private static TransactionToTransactionResourceMapper instance;

        public static TransactionToTransactionResourceMapper getInstance()
        {
            if(instance == null)
            {
                instance = new TransactionToTransactionResourceMapper();
            }
            return instance;
        }
        public TransactionResource apply(TransactionAggregate transaction)
        {
            return map(transaction);
        }

        private TransactionResource map(TransactionAggregate transaction)
        {
            return new TransactionResource(
                transaction.TransactionInfo.getDate(),
                transaction.TransactionInfo.getBetrag(),
                transaction.TransactionInfo.getKontoIdSender(),
                transaction.TransactionInfo.getKontoIdEmpfänger());
        }

        public List<TransactionResource> convertToTransactionResourceList(List<TransactionAggregate> transactionEntities)
        {
            var transactionlist = new List<TransactionResource>();
            foreach (var transactionEntity in transactionEntities)
            {
                transactionlist.Add(new TransactionResource(
                    transactionEntity.TransactionInfo.getDate(), 
                    transactionEntity.TransactionInfo.getBetrag(), 
                    transactionEntity.TransactionInfo.getKontoIdSender(), 
                    transactionEntity.TransactionInfo.getKontoIdEmpfänger()));
            }
            return transactionlist;
        }
    }
}

using System;
using System.Collections.Generic;
using _1_Adapter.Adapter.Transaction;
using _3_Domain.Domain.Aggregates;
using Xunit;

namespace Programmentwurf_BankingApi.Adapter.Transaction.Tests
{
    public class TransactionToTransactionResourceMapperTests
    {
        [Fact]
        public void convertToTransactionResourceListTest()
        {
            var transactions = CreateTransactions();
            var transactionArray = transactions.ToArray();
            var transactionlist = TransactionToTransactionResourceMapper.getInstance().convertToTransactionResourceList(transactions).ToArray();

            for (int i = 0; i < transactionArray.Length; i++)
            {
                Assert.Equal(transactionArray[i].TransactionInfo.getDate(), transactionlist[i].Date);
                Assert.Equal(transactionArray[i].TransactionInfo.getBetrag(), transactionlist[i].Betrag);
                Assert.Equal(transactionArray[i].TransactionInfo.getKontoIdSender(), transactionlist[i].KontoIdSender);
                Assert.Equal(transactionArray[i].TransactionInfo.getKontoIdEmpfänger(), transactionlist[i].KontoIdEmpfänger);
            }
        }
        private static List<TransactionAggregate> CreateTransactions()
        {
            var transactionEntites = new List<TransactionAggregate>();
            for (int i = 0; i <= 10; i++)
            {
                transactionEntites.Add(new TransactionAggregate(DateTime.Now, 5.50, i, i + 1));
            }
            return transactionEntites;
        }

        [Fact]
        public void applyTest()
        {
            var transaction = new TransactionAggregate(DateTime.Now, 5.50, 1, 2);
            var transactionResource = TransactionToTransactionResourceMapper.getInstance().apply(transaction);

            Assert.Equal(transaction.TransactionInfo.getDate(), transactionResource.Date);
            Assert.Equal(transaction.TransactionInfo.getBetrag(), transactionResource.Betrag);
            Assert.Equal(transaction.TransactionInfo.getKontoIdSender(), transactionResource.KontoIdSender);
            Assert.Equal(transaction.TransactionInfo.getKontoIdEmpfänger(), transactionResource.KontoIdEmpfänger);
        }
    }
}
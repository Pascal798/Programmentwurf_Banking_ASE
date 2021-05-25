using Programmentwurf_BankingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.Transaction
{
    public class TransactionToTransactionResourceMapper
    {
        public TransactionResource apply(TransactionEntity transaction)
        {
            return map(transaction);
        }

        private TransactionResource map(TransactionEntity transaction)
        {
            return new TransactionResource(
                transaction.Date,
                transaction.TransactionInfo.getBetrag(),
                transaction.TransactionInfo.getKontoIdSender(),
                transaction.TransactionInfo.getKontoIdEmpfänger());
        }
    }
}

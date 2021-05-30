using System.Collections.Generic;
using System.Threading.Tasks;
using _3_Domain.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace _3_Domain.Domain.Repositories
{
    public interface TransactionRepository
    {
        Task<bool> überweisen(TransactionAggregate transaction);
        Task<List<TransactionAggregate>> getAllTransactions(int userid);
        Task<IActionResult> getTransactionsAsMail(int kontoid);
        Task<TransactionAggregate> findById(int transactionid);
    }
}

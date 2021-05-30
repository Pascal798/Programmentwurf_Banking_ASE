using System.Collections.Generic;
using System.Threading.Tasks;
using _1_Adapter.Adapter.Transaction;
using _3_Domain.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi.Plugin.Transaction;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private TransactionRepositoryImpl _transactionRepositoryImpl;
        private TransactionMapper _transactionMapper;

        public TransactionController(TransactionRepositoryImpl transactionRepositoryImpl)
        {
            _transactionRepositoryImpl = transactionRepositoryImpl;
            _transactionMapper = TransactionMapper.getInstance();
        }

        // GET: api/Transaction/GetTransactions/5
        [HttpGet("[action]/{kontoid}")]
        public async Task<List<_1_Adapter.Adapter.Transaction.Transaction>> GetTransactions(int kontoid)
        {
            var transactions = await _transactionRepositoryImpl.getAllTransactions(kontoid);
            var transactionList = _transactionMapper.convertToTransactionResourceList(transactions);

            return transactionList;
        }

        // GET: api/Transaction/5
        [HttpGet("{transactionid}")]
        public async Task<_1_Adapter.Adapter.Transaction.Transaction> GetTransactionEntity(int transactionid)
        {
            var transactionEntity = await _transactionRepositoryImpl.findById(transactionid);

            if (transactionEntity == null)
            {
                System.Console.WriteLine("Transaction not found");
                return null;
            }

            var transactionResource = _transactionMapper.apply(transactionEntity);

            return transactionResource;
        }

        // POST: api/Transaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTransactionEntity(_1_Adapter.Adapter.Transaction.Transaction transactionEntity)
        {
            var transaction = new TransactionAggregate(
                transactionEntity.Date, 
                transactionEntity.Betrag, 
                transactionEntity.KontoIdSender, 
                transactionEntity.KontoIdEmpfänger
                );

            var response = await _transactionRepositoryImpl.überweisen(transaction);
            if (response)
            {
                return new OkResult();
            }

            return NoContent();

        }

        // GET: api/Transaction/
        [HttpGet("[action]/{kontoid}")]
        public async Task<IActionResult> GetTransactionAsMail(int kontoid)
        {
            return await _transactionRepositoryImpl.getTransactionsAsMail(kontoid);
        }
    }
}

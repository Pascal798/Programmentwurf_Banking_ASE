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
        private TransactionToTransactionResourceMapper TransactionToTransactionResourceMapper;

        public TransactionController(TransactionRepositoryImpl transactionRepositoryImpl)
        {
            _transactionRepositoryImpl = transactionRepositoryImpl;
            TransactionToTransactionResourceMapper = TransactionToTransactionResourceMapper.getInstance();
        }

        // GET: api/Transaction/GetTransactions/5
        [HttpGet("[action]/{kontoid}")]
        public async Task<List<TransactionResource>> GetTransactions(int kontoid)
        {
            var transactions = await _transactionRepositoryImpl.getAllTransactions(kontoid);
            var transactionList = TransactionToTransactionResourceMapper.convertToTransactionResourceList(transactions);

            return transactionList;
        }

        // GET: api/Transaction/5
        [HttpGet("{transactionid}")]
        public async Task<TransactionResource> GetTransactionEntity(int transactionid)
        {
            var transactionEntity = await _transactionRepositoryImpl.findById(transactionid);

            if (transactionEntity == null)
            {
                System.Console.WriteLine("Transaction not found");
                return null;
            }

            var transactionResource = TransactionToTransactionResourceMapper.apply(transactionEntity);

            return transactionResource;
        }

        // POST: api/Transaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTransactionEntity(TransactionResource transactionEntity)
        {
            var transaction = new TransactionAggregate(
                transactionEntity.Date, 
                transactionEntity.Betrag, 
                transactionEntity.KontoIdSender, 
                transactionEntity.KontoIdEmpfänger
                );

            _transactionRepositoryImpl.create(transaction);

            return new OkObjectResult("Created");
        }

        // GET: api/Transaction/
        [HttpGet("[action]/{kontoid}")]
        public async Task<IActionResult> GetTransactionAsMail(int kontoid)
        {
            return await _transactionRepositoryImpl.getTransactionsAsMail(kontoid);
        }
    }
}

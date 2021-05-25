using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi._3Domain.Others;
using Programmentwurf_BankingApi.Adapter.Transaction;
using Programmentwurf_BankingApi.Domain.Entities;
using Programmentwurf_BankingApi.Plugin.Transaction;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private TransactionRepositoryBridge TransactionRepositoryBridge;
        private TransactionToTransactionResourceMapper TransactionToTransactionResourceMapper;

        public TransactionController(TransactionRepositoryBridge transactionRepositoryBridge, TransactionToTransactionResourceMapper transactionToTransactionResourceMapper)
        {
            TransactionRepositoryBridge = transactionRepositoryBridge;
            TransactionToTransactionResourceMapper = transactionToTransactionResourceMapper;
        }

        // GET: api/Transaction/GetTransactions/5
        [HttpGet("[action]/{kontoid}")]
        public async Task<List<TransactionResource>> GetTransactions(int kontoid)
        {
            var transactions = await TransactionRepositoryBridge.getAllTransactions(kontoid);
            List<TransactionResource> transactionList = new List<TransactionResource>();

            foreach(var transaction in transactions)
            {
                transactionList.Add(TransactionToTransactionResourceMapper.apply(transaction));
            }

            return transactionList;
        }

        // GET: api/Transaction/5
        [HttpGet("{transactionid}")]
        public async Task<TransactionResource> GetTransactionEntity(int transactionid)
        {
            var transactionEntity = await TransactionRepositoryBridge.findById(transactionid);

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
            var transaction = new TransactionEntity(transactionEntity.Date, transactionEntity.Betrag, transactionEntity.KontoIdSender, transactionEntity.KontoIdEmpfänger);
            TransactionRepositoryBridge.create(transaction);

            return new OkObjectResult("Created");
        }

        // GET: api/Transaction/
        [HttpGet("[action]/{kontoid}")]
        public async Task<IActionResult> GetTransactionAsMail(int kontoid)
        {
            return await TransactionRepositoryBridge.getTransactionsAsMail(kontoid);
        }
    }
}

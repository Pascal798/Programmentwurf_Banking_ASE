using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi.Plugin;
using Programmentwurf_BankingApi._3Domain.Aggregates;
using Programmentwurf_BankingApi._0Plugin.Bank;
using Programmentwurf_BankingApi._1Adapter.Bank;
using Programmentwurf_BankingApi.Adapter.Konto;

namespace Programmentwurf_BankingApi._0Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private BankRepositoryBridge BankRepositoryBridge;
        private BankToBankResourceMapper BankToBankResourceMapper;
        private KontoToKontoResourceMapper KontoToKontoResourceMapper;

        public BankController(BankRepositoryBridge bankRepositoryBridge, BankToBankResourceMapper bankToBankResourceMapper)
        {
            BankRepositoryBridge = bankRepositoryBridge;
            BankToBankResourceMapper = bankToBankResourceMapper;
            KontoToKontoResourceMapper = KontoToKontoResourceMapper.getInstance();
        }

        // GET: api/Bank
        [HttpGet]
        public async Task<List<BankResource>> GetBankAggregate()
        {
            var banks = await BankRepositoryBridge.getAllBanks();
            var list = new List<BankResource>();
            foreach(var bank in banks)
            {
                list.Add(BankToBankResourceMapper.apply(bank));
            }
            return list;
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public async Task<BankResource> GetBankAggregate(int bic)
        {
            var bankAggregate = await BankRepositoryBridge.findById(bic);

            if (bankAggregate == null)
            {
                return null;
            }

            return BankToBankResourceMapper.apply(bankAggregate);
        }

        // POST: api/Bank
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public CreatedAtActionResult PostBankAggregate(BankResource bank)
        {
            BankRepositoryBridge.create(new BankAggregate(bank.Name, bank.BIC, bank.Land, bank.Postleitzahl, bank.Straße));

            return CreatedAtAction(nameof(GetBankAggregate), new { id = bank.BIC }, bank);
        }

        // DELETE: api/Bank/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBankAggregate(int id)
        {
            BankRepositoryBridge.delete(id);
            return NoContent();
        }

        // GET: api/Bank/GetKonten/5
        [HttpGet("[action]/{id}")]
        public async Task<List<KontoResource>> GetKonten(string bic)
        {
            var konten = await BankRepositoryBridge.getKonten(bic);
            var list = new List<KontoResource>();
            foreach(var konto in konten)
            {
                list.Add(KontoToKontoResourceMapper.apply(konto));
            }

            return list;
        }
    }
}

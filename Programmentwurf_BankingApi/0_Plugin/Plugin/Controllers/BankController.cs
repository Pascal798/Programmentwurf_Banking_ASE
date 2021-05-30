using System.Collections.Generic;
using System.Threading.Tasks;
using _1_Adapter.Adapter.Bank;
using _1_Adapter.Adapter.Konto;
using _3_Domain.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi.Plugin.Bank;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private BankRepositoryImpl _bankRepositoryImpl;
        private BankMapper _bankMapper;
        private KontoMapper _kontoMapper;

        public BankController(BankRepositoryImpl bankRepositoryImpl)
        {
            _bankRepositoryImpl = bankRepositoryImpl;
            _bankMapper = BankMapper.getInstance();
            _kontoMapper = KontoMapper.getInstance();
        }

        // GET: api/Bank
        [HttpGet]
        public async Task<List<_1_Adapter.Adapter.Bank.Bank>> GetBankAggregate()
        {
            var banks = await _bankRepositoryImpl.getAllBanks();
            var list = _bankMapper.convertToBankResourceList(banks);
            return list;
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public async Task<_1_Adapter.Adapter.Bank.Bank> GetBankAggregate(int bic)
        {
            var bankAggregate = await _bankRepositoryImpl.findById(bic);

            if (bankAggregate == null)
            {
                return null;
            }

            return _bankMapper.apply(bankAggregate);
        }

        // POST: api/Bank
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CreatedAtActionResult> PostBankAggregate(_1_Adapter.Adapter.Bank.Bank bank)
        {
            await _bankRepositoryImpl.bankAnlegen(new BankAggregate(
                bank.Name, 
                bank.BIC, 
                bank.Land, 
                bank.Postleitzahl, 
                bank.Straße
                ));

            return CreatedAtAction(nameof(GetBankAggregate), new { id = bank.BIC }, bank);
        }

        // DELETE: api/Bank/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAggregate(int id)
        {
            await _bankRepositoryImpl.bankLöschen(id);
            return NoContent();
        }

        // GET: api/Bank/GetKonten/5
        [HttpGet("[action]/{id}")]
        public async Task<List<UserKonto>> GetKonten(string bic)
        {
            var konten = await _bankRepositoryImpl.getKonten(bic);
            var list = _kontoMapper.convertToKontoResourceList(konten);

            return list;
        }
    }
}

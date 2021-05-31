using System.Collections.Generic;
using System.Threading.Tasks;
using _1_Adapter.Adapter.Konto;
using _3_Domain.Domain.Entities;
using _3_Domain.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi.Plugin.Konto;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontoController : ControllerBase
    {
        private KontoRepository _kontoRepo;
        private KontoMapper _kontoMapper;

        public KontoController(KontoRepository kontoRepo)
        {
            _kontoRepo = kontoRepo;
            _kontoMapper = KontoMapper.getInstance();
        }

        // GET: api/Konto
        [HttpGet]
        public async Task<List<UserKonto>> GetKonten()
        {
            var konten = await _kontoRepo.findAllKonten();
            var kontolist = _kontoMapper.convertToKontoResourceList(konten);

            return kontolist;
        }

        // GET: api/Konto/GetKonten/5
        [HttpGet("[action]/{userid}")]
        public List<KontoEntity> GetKonten(int userid)
        {
            var konten = _kontoRepo.getAllKontenFromUser(userid);

            return konten;
        }

        // GET: api/Konto/5
        [HttpGet("{kontoid}")]
        public async Task<UserKonto> GetKontoEntity(int kontoid)
        {
            var kontoEntity = await _kontoRepo.findById(kontoid);

            if (kontoEntity == null)
            {
                System.Console.WriteLine("Konto not found");
                return null;
            }

            var kontoResource = _kontoMapper.apply(kontoEntity);

            return kontoResource;
        }

        // PUT: api/Konto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kontoid}/{betrag}")]
        public async Task<IActionResult> PutKontoEntity(int kontoid, double betrag)
        {
            var response = await  _kontoRepo.kontostandÄndern(kontoid, betrag);
            if (response)
            {
                return new OkResult();
            }

            return new UnauthorizedObjectResult("Failure");
        }

        // POST: api/Konto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userid}")]
        public async Task<IActionResult> PostKontoEntity(KontoEntity konto, int userid)
        {
            konto.UserId = userid;
            var response = await _kontoRepo.kontoErstellen(konto);

            if (response)
            {
                return CreatedAtAction(
                    nameof(GetKontoEntity),
                    new { kontoid = konto.Id },
                    konto);
            }

            return NoContent();
        }

        // DELETE: api/Konto/5
        [HttpDelete("{kontoid}")]
        public async Task<IActionResult> DeleteKontoEntity(int kontoid)
        {
            var response  = await _kontoRepo.kontoLöschen(kontoid);

            if (response)
            {
                return new OkResult();
            }
            return NoContent();
        }
    }
}

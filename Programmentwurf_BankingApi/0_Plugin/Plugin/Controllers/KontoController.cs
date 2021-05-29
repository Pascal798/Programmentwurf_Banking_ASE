using System.Collections.Generic;
using System.Threading.Tasks;
using _1_Adapter.Adapter.Konto;
using _3_Domain.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi.Plugin.Konto;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontoController : ControllerBase
    {
        private KontoRepositoryImpl _kontoRepositoryImpl;
        private KontoToKontoResourceMapper KontoToKontoResourceMapper;

        public KontoController(KontoRepositoryImpl kontoRepositoryImpl)
        {
            _kontoRepositoryImpl = kontoRepositoryImpl;
            KontoToKontoResourceMapper = KontoToKontoResourceMapper.getInstance();
        }

        // GET: api/Konto
        [HttpGet]
        public async Task<List<KontoResource>> GetKonten()
        {
            var konten = await _kontoRepositoryImpl.findAllKonten();
            var kontolist = KontoToKontoResourceMapper.convertToKontoResourceList(konten);

            return kontolist;
        }

        // GET: api/Konto/GetKonten/5
        [HttpGet("[action]/{userid}")]
        public List<KontoEntity> GetKonten(int userid)
        {
            var konten = _kontoRepositoryImpl.getAllKontenFromUser(userid);

            return konten;
        }

        // GET: api/Konto/5
        [HttpGet("{kontoid}")]
        public async Task<KontoResource> GetKontoEntity(int kontoid)
        {
            var kontoEntity = await _kontoRepositoryImpl.findById(kontoid);

            if (kontoEntity == null)
            {
                System.Console.WriteLine("Konto not found");
                return null;
            }

            var kontoResource = KontoToKontoResourceMapper.apply(kontoEntity);

            return kontoResource;
        }

        // PUT: api/Konto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{kontoid}/{betrag}")]
        public IActionResult PutKontoEntity(int kontoid, double betrag)
        {
            _kontoRepositoryImpl.updateKontostand(kontoid, betrag);

            return new OkObjectResult("Updated");
        }

        // POST: api/Konto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userid}")]
        public CreatedAtActionResult PostKontoEntity(KontoEntity konto, int userid)
        {
            konto.UserId = userid;
            _kontoRepositoryImpl.create(konto);

            return CreatedAtAction(
                nameof(GetKontoEntity), 
                new { kontoid = konto.Id }, 
                konto);
        }

        // DELETE: api/Konto/5
        [HttpDelete("{kontoid}")]
        public NoContentResult DeleteKontoEntity(int kontoid)
        {
            _kontoRepositoryImpl.delete(kontoid);

            return NoContent();
        }
    }
}

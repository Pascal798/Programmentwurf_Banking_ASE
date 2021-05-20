using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi.Adapter.Konto;
using Programmentwurf_BankingApi.Domain.Entities;
using Programmentwurf_BankingApi.Plugin.Konto;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontoController : ControllerBase
    {
        private KontoRepositoryBridge KontoRepositoryBridge;
        private KontoToKontoResourceMapper KontoToKontoResourceMapper;

        public KontoController(KontoRepositoryBridge kontoRepositoryBridge, KontoToKontoResourceMapper kontoToKontoResourceMapper)
        {
            KontoRepositoryBridge = kontoRepositoryBridge;
            KontoToKontoResourceMapper = kontoToKontoResourceMapper;
        }

        // GET: api/Konto
        [HttpGet]
        public async Task<List<KontoResource>> GetUsers()
        {
            var konten = await KontoRepositoryBridge.findAllKonten();
            List<KontoResource> kontoList = new List<KontoResource>();

            foreach (var konto in konten)
            {
                kontoList.Add(KontoToKontoResourceMapper.apply(konto));
            }

            return kontoList;
        }

        // GET: api/Konto/GetKonten/5
        [HttpGet("[action]/{userid}")]
        public List<KontoResource> GetKonten(int userid)
        {
            var konten = KontoRepositoryBridge.getAllKontenFromUser(userid);
            List<KontoResource> kontoList = new List<KontoResource>();

            foreach (var konto in konten)
            {
                kontoList.Add(KontoToKontoResourceMapper.apply(konto));
            }

            return kontoList;
        }

        // GET: api/Konto/5
        [HttpGet("{kontoid}")]
        public async Task<KontoResource> GetKontoEntity(int kontoid)
        {
            var kontoEntity = await KontoRepositoryBridge.findById(kontoid);

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
        public NoContentResult PutKontoEntity(int kontoid, double betrag)
        {
            KontoRepositoryBridge.updateKontostand(kontoid, betrag);

            return NoContent();
        }

        // POST: api/Konto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public CreatedAtActionResult PostKontoEntity(KontoEntity kontoEntity)
        {
            KontoRepositoryBridge.create(kontoEntity);

            return CreatedAtAction(
                nameof(GetKontoEntity), 
                new { kontoid = kontoEntity.Id }, 
                kontoEntity);
        }

        // DELETE: api/Konto/5
        [HttpDelete("{kontoid}")]
        public NoContentResult DeleteKontoEntity(int kontoid)
        {
            KontoRepositoryBridge.delete(kontoid);

            return NoContent();
        }
    }
}

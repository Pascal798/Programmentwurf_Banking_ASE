﻿using System.Collections.Generic;
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

        public KontoController(KontoRepositoryBridge kontoRepositoryBridge)
        {
            KontoRepositoryBridge = kontoRepositoryBridge;
            KontoToKontoResourceMapper = KontoToKontoResourceMapper.getInstance();
        }

        // GET: api/Konto
        [HttpGet]
        public async Task<List<KontoResource>> GetKonten()
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
        public List<KontoEntity> GetKonten(int userid)
        {
            var konten = KontoRepositoryBridge.getAllKontenFromUser(userid);

            return konten;
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
        public IActionResult PutKontoEntity(int kontoid, double betrag)
        {
            KontoRepositoryBridge.updateKontostand(kontoid, betrag);

            return new OkObjectResult("Updated");
        }

        // POST: api/Konto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userid}")]
        public CreatedAtActionResult PostKontoEntity(KontoResource konto, int userid)
        {
            KontoRepositoryBridge.create(new KontoEntity(konto.Kontostand, userid, konto.BIC));

            return CreatedAtAction(
                nameof(GetKontoEntity), 
                new { kontoid = konto.Id }, 
                konto);
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

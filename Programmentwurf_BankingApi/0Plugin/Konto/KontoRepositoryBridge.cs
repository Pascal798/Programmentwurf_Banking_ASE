using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi.Domain.Entities;
using Programmentwurf_BankingApi.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Plugin.Konto
{
    public class KontoRepositoryBridge : KontoRepository
    {
        private BankingContext Context;

        public KontoRepositoryBridge(BankingContext context)
        {
            Context = context;
        }

        public async Task<List<KontoEntity>> findAllKonten()
        {
            var list = await Context.Konten.ToListAsync();
            var kontoList = new List<KontoEntity>();
            foreach(var konto in list)
            {
                kontoList.Add(konto);
            }
            return kontoList;
        }

        public List<KontoEntity> getAllKontenFromUser(int userid)
        {
            var konten = Context.Konten.Where(x => x.UserId == userid);
            var list = new List<KontoEntity>();
            foreach(var konto in konten)
            {
                list.Add(konto);
            }
            return list;
        }

        public async void create(KontoEntity konto)
        {
            Context.Konten.Add(konto);
            await Context.SaveChangesAsync();
        }

        public async void updateKontostand(int kontoid, double betrag)
        {
            var konto = await findById(kontoid);
            konto.Kontostand += betrag;
            try
            {
                Context.Entry(konto).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontoEntityExists(konto.Id))
                {
                    System.Console.WriteLine("Konto doesn't exist");
                }
                else
                {
                    throw;
                }
            }
        }

        public async void delete(int kontoid)
        {
            var kontoEntity = await Context.Konten.FindAsync(kontoid);
            if (kontoEntity == null)
            {
                System.Console.WriteLine("User not found");
                return;
            }

            Context.Konten.Remove(kontoEntity);
            await Context.SaveChangesAsync();
        }

        public async Task<KontoEntity> findById(int kontoid)
        {
            var kontoEntity = await Context.Konten.FindAsync(kontoid);
            if (kontoEntity == null)
            {
                System.Console.WriteLine("User not found");
            }
            return kontoEntity;
        }

        public bool KontoEntityExists(int id)
        {
            return Context.Konten.Any(e => e.Id == id);
        }
    }
}

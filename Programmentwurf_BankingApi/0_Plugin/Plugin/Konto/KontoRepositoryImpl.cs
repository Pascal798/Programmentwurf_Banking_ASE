using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_Domain.Domain.Entities;
using _3_Domain.Domain.Repositories;

namespace Programmentwurf_BankingApi.Plugin.Konto
{
    public class KontoRepositoryImpl : KontoRepository
    {
        private IBankingContext _context;

        public KontoRepositoryImpl(IBankingContext context)
        {
            _context = context;
        }

        public async Task<List<KontoEntity>> findAllKonten()
        {
            var list = await _context.Konten.ToListAsync();
            
            return list;
        }

        public List<KontoEntity> getAllKontenFromUser(int userid)
        {
            var konten = _context.Konten.Where(x => x.UserId == userid);
            var list = new List<KontoEntity>();
            foreach(var konto in konten)
            {
                list.Add(konto);
            }
            return list;
        }

        public async void create(KontoEntity konto)
        {
            _context.Konten.Add(konto);
            await _context.SaveChangesAsync();
        }

        public async void updateKontostand(int kontoid, double betrag)
        {
            var konto = await findById(kontoid);
            konto.Kontostand += betrag;
            try
            {
                _context.Update(konto);
                await _context.SaveChangesAsync();
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
            var kontoEntity = await _context.Konten.FindAsync(kontoid);
            if (kontoEntity == null)
            {
                System.Console.WriteLine("User not found");
                return;
            }

            _context.Konten.Remove(kontoEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<KontoEntity> findById(int kontoid)
        {
            var kontoEntity = await _context.Konten.FindAsync(kontoid);
            if (kontoEntity == null)
            {
                System.Console.WriteLine("User not found");
            }
            return kontoEntity;
        }

        public bool KontoEntityExists(int id)
        {
            return _context.Konten.Any(e => e.Id == id);
        }
    }
}

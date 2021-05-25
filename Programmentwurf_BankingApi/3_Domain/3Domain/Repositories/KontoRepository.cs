using Programmentwurf_BankingApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Domain.Repositories
{
    public interface KontoRepository
    {
        Task<List<KontoEntity>> findAllKonten();
        List<KontoEntity> getAllKontenFromUser(int userid);
        void create(KontoEntity konto);
        void updateKontostand(int id, double betrag);
        void delete(int kontonummer);
        Task<KontoEntity> findById(int kontoid);
    }
}

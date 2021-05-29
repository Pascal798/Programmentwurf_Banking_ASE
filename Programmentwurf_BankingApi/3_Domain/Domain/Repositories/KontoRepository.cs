using System.Collections.Generic;
using System.Threading.Tasks;
using _3_Domain.Domain.Entities;

namespace _3_Domain.Domain.Repositories
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

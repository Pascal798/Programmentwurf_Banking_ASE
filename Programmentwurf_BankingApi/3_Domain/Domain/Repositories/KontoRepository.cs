using System.Collections.Generic;
using System.Threading.Tasks;
using _3_Domain.Domain.Entities;

namespace _3_Domain.Domain.Repositories
{
    public interface KontoRepository
    {
        Task<List<KontoEntity>> findAllKonten();
        List<KontoEntity> getAllKontenFromUser(int userid);
        Task<bool> kontoErstellen(KontoEntity konto);
        Task<bool> kontostandÄndern(int id, double betrag);
        Task<bool> kontoLöschen(int kontonummer);
        Task<KontoEntity> findById(int kontoid);
    }
}

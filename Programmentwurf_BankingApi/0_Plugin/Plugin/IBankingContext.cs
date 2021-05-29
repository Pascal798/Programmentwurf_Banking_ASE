using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using _3_Domain.Domain.Aggregates;
using _3_Domain.Domain.Entities;

namespace Programmentwurf_BankingApi.Plugin
{
    public interface IBankingContext
    {
        DbSet<BankAggregate> BankAggregate { get; set; }
        DbSet<KontoEntity> Konten { get; set; }
        DbSet<TransactionAggregate> Transaction { get; set; }
        DbSet<UserEntity> Users { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        EntityEntry Entry(EntityEntry obj);
        EntityEntry Update(object obj);
    }
}
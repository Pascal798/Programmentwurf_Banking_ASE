using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using _3_Domain.Domain.Aggregates;
using _3_Domain.Domain.Entities;
using _3_Domain.Domain.Value_Objects;

namespace Programmentwurf_BankingApi.Plugin
{
    public class BankingContext : DbContext, IBankingContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<TransactionAggregate>().OwnsOne(typeof(TransactionVO), "TransactionInfo");
            modelbuilder.Entity<BankAggregate>().OwnsOne(typeof(BankEntity), "Bank");
            modelbuilder.Entity<BankAggregate>().OwnsOne(typeof(AdressVO), "Adresse");
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<KontoEntity> Konten { get; set; }
        public DbSet<TransactionAggregate> Transaction { get; set; }
        public DbSet<BankAggregate> BankAggregate { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        public EntityEntry Entry(EntityEntry obj)
        {
            return base.Entry(obj);
        } 
        public override EntityEntry Update(object obj)
        {
            var result = base.Update(obj);
            return result;
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi._3Domain.Value_Objects;
using Programmentwurf_BankingApi.Domain.Entities;

namespace Programmentwurf_BankingApi.Plugin
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<TransactionEntity>().OwnsOne(typeof(TransactionVO), "TransactionInfo");
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<KontoEntity> Konten { get; set; }
        public DbSet<TransactionEntity> Transaction { get; set; }
    }
}

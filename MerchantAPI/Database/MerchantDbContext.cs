using MerchantAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MerchantAPI.Database
{
    public class MerchantDbContext : DbContext
    //oti zaborajv deka nasledva od DbContext barav error 28 minuti, Ne zaboravaj!
    {
        public MerchantDbContext(DbContextOptions<MerchantDbContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Store> Stores { get; set; }
        ///ova mi treba za vo repozitorium, go imav students ostaeno zato ne go naogjashe, vo edna klasa 2 greshki...

    }
}

using MerchantAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MerchantAPI.Database
{
    public class MerchantDbContext : DbContext
    //Don't forget, it has to inherit from DbContext!
    {
        public MerchantDbContext(DbContextOptions<MerchantDbContext> options) : base(options)
        {
        }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Store> Stores { get; set; }
        //Because you have + class stores that should have crud functionalities you need separate list from merchants

    }
}

namespace EtsStore;
using Microsoft.EntityFrameworkCore;

internal class StoreContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=JVL-C-0008M\\SQLEXPRESS;Database=EtsStoreDB;Trusted_Connection=true;TrustServerCertificate=True");
    }
}
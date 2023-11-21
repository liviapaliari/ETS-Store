namespace EtsStore;
using Microsoft.EntityFrameworkCore;

internal class StoreContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<Promocao> Promocoes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=JVL-C-0008M\\SQLEXPRESS;Database=EtsStoreDB;Trusted_Connection=true;TrustServerCertificate=True");
    }

    // ENDEREÇO NÃO ESTÁ NO DBSET ACIMA, POR ISSO PRECISAMOS PASSAR AQUI
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Endereco>().ToTable("Enderecos");
        modelBuilder.Entity<Endereco>().Property<int>("ClienteId");
        modelBuilder.Entity<Endereco>().HasKey("ClienteId");
    }
}
using Microsoft.EntityFrameworkCore;

public class ListaCompraConext : DbContext
    {
        public ListaCompraConext(DbContextOptions<ListaCompraConext> options)
            : base(options)
        { }

        public DbSet<Compra> Compra { get; set; }
      

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Compra>().ToTable("Compra");
           
        }
    }
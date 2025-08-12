using ElectronicStore.BackEnd.Models;
using Microsoft.EntityFrameworkCore;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceDetails> InvoiceDetails => Set<InvoiceDetails>();
    public DbSet<Items> Items => Set<Items>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        // Table names (opsional)
        b.Entity<Invoice>().ToTable("Invoices");
        b.Entity<InvoiceDetails>().ToTable("InvoiceDetails");
        b.Entity<Items>().ToTable("Items");

        // Keys
        b.Entity<Invoice>().HasKey(x => x.Id);
        b.Entity<InvoiceDetails>().HasKey(x => x.Id);
        b.Entity<Items>().HasKey(x => x.Id);

        // Money precision
        b.Entity<Invoice>().Property(x => x.LabourPrice).HasColumnType("decimal(18,2)");
        b.Entity<Invoice>().Property(x => x.GrandPrice).HasColumnType("decimal(18,2)");
        b.Entity<InvoiceDetails>().Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        b.Entity<InvoiceDetails>().Property(x => x.Discount).HasColumnType("decimal(18,2)");
        b.Entity<Items>().Property(x => x.Price).HasColumnType("decimal(18,2)");

        // Concurrency token (rowversion/timestamp)
        b.Entity<Invoice>().Property(x => x.RowVersion).IsRowVersion();
        b.Entity<Items>().Property(x => x.RowVersion).IsRowVersion();

        // Relations
        b.Entity<Invoice>()
            .HasMany(i => i.InvoiceDetails)
            .WithOne(d => d.Invoice)
            .HasForeignKey(d => d.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade); // hapus invoice -> delete details

        b.Entity<InvoiceDetails>()
            .HasOne(d => d.Item)
            .WithMany() // tidak ingin cascade hapus item
            .HasForeignKey(d => d.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        b.Entity<Items>().HasIndex(x => x.ItemCode).IsUnique();
        b.Entity<Invoice>().HasIndex(x => x.InvoiceDate);
    }
}
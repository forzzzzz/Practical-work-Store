using Microsoft.EntityFrameworkCore;

namespace Store
{
    class DataContext : DbContext //наслідуємося від класу DbContext
    {
        //перевизначаємо метод OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            //тут вказаний шлях до бази даних
            optionsBuilder.UseSqlite("Data Source = UserData.db");
        }

        //створюємо таблиці, які будуть в базі даних
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Category> Categories { get; set; }

        // метод який буде визвано при створенні бази даних
        // потрібен для того щоб правильно зкофігурувати створення бази даних
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Receipt>()
                .HasMany(c => c.Products)
                .WithMany(s => s.Receipts)
                .UsingEntity<ReceiptProduct > (
                    j => j
                        .HasOne(pt => pt.Product)
                        .WithMany(t => t.ReceiptProduct)
                        .HasForeignKey(pt => pt.ProductId),
                    j => j
                        .HasOne(pt => pt.Receipt)
                        .WithMany(p => p.ReceiptProduct)
                        .HasForeignKey(pt => pt.ReceiptId)
                );
        }
    }
}

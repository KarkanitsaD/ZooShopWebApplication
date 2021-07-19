using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using ZooShop.Data.Entities;

namespace ZooShop.Data
{
    public class ZooShopContext: DbContext
    {
        public ZooShopContext()
        {

        }

        public ZooShopContext(DbContextOptions<ZooShopContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }        
        public virtual DbSet<OrderStatusEntity> OrderStatuses { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }        
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();

                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");

                var configuration = builder.Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            ConfigureProduct(modelBuilder);
            ConfigureOrderStatus(modelBuilder);
            ConfigureUser(modelBuilder);
            ConfigureOrder(modelBuilder);
            ConfigureCategory(modelBuilder);                                  
        }

        private void ConfigureProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .HasMany(p => p.Users)
                .WithMany(c => c.Products)
                .UsingEntity<CartItemEntity>(
                j => j
                     .HasOne(ci => ci.User)
                     .WithMany(c => c.CartItems)
                     .HasForeignKey(ci => ci.UserId),
                j => j
                     .HasOne(ci => ci.Product)
                     .WithMany(p => p.CartItems)
                     .HasForeignKey(ci => ci.ProductId),
                j =>
                {
                    j.Property(pt => pt.Quantity).HasDefaultValue(1);
                    j.HasKey(t => new { t.ProductId, t.UserId });
                    j.ToTable("UserCartItems");
                }
                );

            modelBuilder.Entity<ProductEntity>()
                .HasMany(p => p.Orders)
                .WithMany(c => c.Products)
                .UsingEntity<OrderItemEntity>(
                j => j
                    .HasOne(ci => ci.Order)
                    .WithMany(c => c.OrderItems)
                    .HasForeignKey(ci => ci.OrderId),
                j => j
                    .HasOne(ci => ci.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(ci => ci.ProductId),
                j =>
                {
                    j.Property(pt => pt.Quantity).HasDefaultValue(1);
                    j.HasKey(t => new { t.ProductId, t.OrderId });
                    j.ToTable("OrderItem");
                }
                );

            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(6, 2)")
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });


            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.Carts)
            //    .WithMany(c => c.Products)
            //    .UsingEntity<CartItem>(
            //    j => j
            //         .HasOne(ci => ci.Cart)
            //         .WithMany(c => c.CartItems)
            //         .HasForeignKey(ci => ci.CartId),
            //    j => j
            //         .HasOne(ci => ci.Product)
            //         .WithMany(p => p.CartItems)
            //         .HasForeignKey(ci => ci.ProductId),
            //    j =>
            //    {
            //          j.Property(pt => pt.Quantity).HasDefaultValue(1);
            //          j.HasKey(t => new { t.ProductId, t.CartId });
            //          j.ToTable("CartItem");
            //    }
            //    );

        }

        private void ConfigureOrderStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatusEntity>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsAdmin)
                    .HasDefaultValue(false);
            });

            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Cart)
            //    .WithOne(c => c.User)
            //    .HasForeignKey<Cart>(c => c.Id);

        }

        private void ConfigureOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Flat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.House)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__order__StatusId__45F365D3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__order__UserId__44FF419A");
            });
        }

        private void ConfigureCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .UsingEntity(j => j.ToTable("ProductCategory"));
        }        
    }
}

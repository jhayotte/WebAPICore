using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiCore.Models
{
    public partial class MarketplaceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ric-one-dev.crrvhrz65df6.eu-west-1.rds.amazonaws.com;Database=Marketplace;User ID=MarketplaceOwner;Password=k1pbD1WmWxJ5AaUltXOO;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => new { e.BuyerId, e.Id })
                    .HasName("PK_Account_Address_Id");

                entity.ToTable("Address", "Account");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Account_Address_BuyerId_Account_Buyer_Id");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("Attribute", "Shopping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.Unit).HasColumnType("xml");
            });

            modelBuilder.Entity<AttributeSet>(entity =>
            {
                entity.HasKey(e => new { e.AttributeId, e.CategoryId })
                    .HasName("PK_Shopping_AttributeSet_AttributeId_CategoryId");

                entity.ToTable("AttributeSet", "Shopping");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributeSet)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_AttributeSet_AttributeId_Shopping_Attribute_Id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.AttributeSet)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_AttributeSet_CategoryId_Shopping_Category_Id");
            });

            modelBuilder.Entity<AttributeVariant>(entity =>
            {
                entity.HasKey(e => new { e.VariantId, e.AttributeId })
                    .HasName("PK_Shopping_AttributeVariant_Id");

                entity.ToTable("AttributeVariant", "Shopping");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributeVariant)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_AttributeVariant_AttributeId_Shopping_Attribute_Id");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.AttributeVariant)
                    .HasForeignKey(d => d.VariantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_AttributeVariant_VariantId_Shopping_Category_Id");
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyer", "Account");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "Shopping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("xml");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.ToTable("Merchant", "Shopping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Emails)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.LogoUrl)
                    .IsRequired()
                    .HasColumnName("LogoURL")
                    .HasColumnType("varchar(2048)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.WebsiteUrl)
                    .HasColumnName("WebsiteURL")
                    .HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer", "Shopping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.PictureUrl)
                    .IsRequired()
                    .HasColumnName("PictureURL")
                    .HasColumnType("xml");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Properties)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.MerchantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_Offer_MerchantId_Shopping_Merchant_Id");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.VariantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_Offer_VariantId_Shopping_Variant_Id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "Ordering");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuyerSnapshot)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.ExternalTrackingId)
                    .IsRequired()
                    .HasColumnType("char(100)");

                entity.Property(e => e.ExternalTransactionId)
                    .IsRequired()
                    .HasColumnType("char(100)");

                entity.Property(e => e.OrderDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnType("xml");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.OfferId })
                    .HasName("PK_Ordering_OrderDetail_OrderId_OfferId");

                entity.ToTable("OrderDetail", "Ordering");

                entity.Property(e => e.ExternalTrackingId)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.OfferSnapshot)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.TrackingSatus)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Ordering_OrderDetail_OrderId__Ordering_Order_Id");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => new { e.MerchantId, e.Code })
                    .HasName("PK_Shopping_PaymentMethod_MerchantId_Code");

                entity.ToTable("PaymentMethod", "Shopping");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.PaymentMethod)
                    .HasForeignKey(d => d.MerchantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_PaymentMethod_MerchantId_Shopping_Merchant_Id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Shopping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_Variant_ProductId_Shopping_Attribute_Id");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.OfferId)
                    .HasName("PK_Shopping_Shipping_OfferId");

                entity.ToTable("Shipping", "Shopping");

                entity.Property(e => e.OfferId).ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.HasOne(d => d.Offer)
                    .WithOne(p => p.Shipping)
                    .HasForeignKey<Shipping>(d => d.OfferId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_Shipping_OfferId_Shopping_Offer_Id");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.ToTable("Variant", "Shopping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StandartIdentificationNunber)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Variant)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Shopping_Variant_ProductId_Shopping_Product_Id");
            });
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Attribute> Attribute { get; set; }
        public virtual DbSet<AttributeSet> AttributeSet { get; set; }
        public virtual DbSet<AttributeVariant> AttributeVariant { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Merchant> Merchant { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<Variant> Variant { get; set; }
    }
}
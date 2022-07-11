using BookStore.Domain;
using BookStore.Domain.Domain;
using BookStore.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStore.Infrastructure.Data
{
	public partial class BookStoreContext : DbContext
    {

		public BookStoreContext()
        {
		}

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-97SPTF5;Initial Catalog=BookStoreDb;Integrated Security=True");


        }
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AddressStatus> AddressStatuses { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CustOrder> CustOrders { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
        public virtual DbSet<OrderHistory> OrderHistories { get; set; } = null!;
        public virtual DbSet<OrderLine> OrderLines { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ShippingMethod> ShippingMethods { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("address_id");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(200)
                    .HasColumnName("street_name");

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(10)
                    .HasColumnName("street_number");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("fk_addr_ctry");
            });

            modelBuilder.Entity<AddressStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("pk_addr_status");

                entity.ToTable("address_status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("status_id");

                entity.Property(e => e.AddressStatus1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("address_status");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.AuthorId)
                    .ValueGeneratedNever()
                    .HasColumnName("author_id");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(400)
                    .HasColumnName("author_name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("book_id");

                entity.Property(e => e.Isbn13)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("isbn13");


                entity.Property(e => e.NumPages).HasColumnName("num_pages");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("date")
                    .HasColumnName("publication_date");

                entity.Property(e => e.PublisherId).HasColumnName("publisher_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(400)
                    .HasColumnName("title");

             

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("fk_book_pub");
                entity.HasOne(d => d.Category)
                        .WithMany(e => e.Books)
                        .HasForeignKey(d => d.CategotyId); 
                        
                entity.HasMany(d => d.Authors)
                    .WithMany(p => p.Books)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookAuthor",
                        l => l.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ba_author"),
                        r => r.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_ba_book"),
                        j =>
                        {
                            j.HasKey("BookId", "AuthorId").HasName("pk_bookauthor");

                            j.ToTable("book_author");

                            j.IndexerProperty<Guid>("BookId").HasColumnName("book_id");

                            j.IndexerProperty<Guid>("AuthorId").HasColumnName("author_id");
                        });
            });

           

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(200)
                    .HasColumnName("country_name");
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategotyId);
                        
            });
            modelBuilder.Entity<CustOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("pk_custorder");

                entity.ToTable("cust_order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DestAddressId).HasColumnName("dest_address_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.ShippingMethodId).HasColumnName("shipping_method_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_order_cust");

                entity.HasOne(d => d.DestAddress)
                    .WithMany(p => p.CustOrders)
                    .HasForeignKey(d => d.DestAddressId)
                    .HasConstraintName("fk_order_addr");

                entity.HasOne(d => d.ShippingMethod)
                    .WithMany(p => p.CustOrders)
                    .HasForeignKey(d => d.ShippingMethodId)
                    .HasConstraintName("fk_order_ship");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AddressId })
                    .HasName("pk_custaddr");

                entity.ToTable("customer_address");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ca_addr");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ca_cust");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_customer_address_address_status");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("pk_orderhist");

                entity.ToTable("order_history");

                entity.Property(e => e.HistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("history_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.StatusDate)
                    .HasColumnType("datetime")
                    .HasColumnName("status_date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_oh_order");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_oh_status");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.LineId)
                    .HasName("pk_orderline");

                entity.ToTable("order_line");

                entity.Property(e => e.LineId)
                    .ValueGeneratedNever()
                    .HasColumnName("line_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("fk_ol_book");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_ol_order");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("pk_orderstatus");

                entity.ToTable("order_status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("status_id");

                entity.Property(e => e.StatusValue)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status_value");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");

                entity.Property(e => e.PublisherId)
                    .ValueGeneratedNever()
                    .HasColumnName("publisher_id");

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(400)
                    .HasColumnName("publisher_name");
            });

            modelBuilder.Entity<ShippingMethod>(entity =>
            {
                entity.HasKey(e => e.MethodId)
                    .HasName("pk_shipmethod");

                entity.ToTable("shipping_method");

                entity.Property(e => e.MethodId)
                    .ValueGeneratedNever()
                    .HasColumnName("method_id");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("cost");

                entity.Property(e => e.MethodName)
                    .HasMaxLength(100)
                    .HasColumnName("method_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

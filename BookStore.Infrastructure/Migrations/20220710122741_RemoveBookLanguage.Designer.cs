﻿// <auto-generated />
using System;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Infrastructure.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20220710122741_RemoveBookLanguage")]
    partial class RemoveBookLanguage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("book_id");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("author_id");

                    b.HasKey("BookId", "AuthorId")
                        .HasName("pk_bookauthor");

                    b.HasIndex("AuthorId");

                    b.ToTable("book_author", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("address_id");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("city");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("country_id");

                    b.Property<string>("StreetName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("street_name");

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("street_number");

                    b.HasKey("AddressId");

                    b.HasIndex("CountryId");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.AddressStatus", b =>
                {
                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("status_id");

                    b.Property<string>("AddressStatus1")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("address_status");

                    b.HasKey("StatusId")
                        .HasName("pk_addr_status");

                    b.ToTable("address_status", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("author_id");

                    b.Property<string>("AuthorName")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("author_name");

                    b.HasKey("AuthorId");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("book_id");

                    b.Property<Guid?>("CategotyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn13")
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("isbn13");

                    b.Property<int?>("NumPages")
                        .HasColumnType("int")
                        .HasColumnName("num_pages");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("date")
                        .HasColumnName("publication_date");

                    b.Property<Guid?>("PublisherId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("publisher_id");

                    b.Property<int>("Reviews")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("title");

                    b.HasKey("BookId");

                    b.HasIndex("CategotyId");

                    b.HasIndex("PublisherId");

                    b.ToTable("book", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<string>("Email")
                        .HasMaxLength(350)
                        .IsUnicode(false)
                        .HasColumnType("varchar(350)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("last_name");

                    b.HasKey("CustomerId");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.CustomerAddress", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("address_id");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("status_id");

                    b.HasKey("CustomerId", "AddressId")
                        .HasName("pk_custaddr");

                    b.HasIndex("AddressId");

                    b.HasIndex("StatusId");

                    b.ToTable("customer_address", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.CustOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<Guid?>("DestAddressId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dest_address_id");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime")
                        .HasColumnName("order_date");

                    b.Property<Guid?>("ShippingMethodId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("shipping_method_id");

                    b.HasKey("OrderId")
                        .HasName("pk_custorder");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DestAddressId");

                    b.HasIndex("ShippingMethodId");

                    b.ToTable("cust_order", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Domain.Category", b =>
                {
                    b.Property<Guid>("CategotyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategotyId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookStore.Domain.OrderHistory", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("history_id");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<DateTime?>("StatusDate")
                        .HasColumnType("datetime")
                        .HasColumnName("status_date");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("status_id");

                    b.HasKey("HistoryId")
                        .HasName("pk_orderhist");

                    b.HasIndex("OrderId");

                    b.HasIndex("StatusId");

                    b.ToTable("order_history", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.OrderLine", b =>
                {
                    b.Property<Guid>("LineId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("line_id");

                    b.Property<Guid?>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("book_id");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("price");

                    b.HasKey("LineId")
                        .HasName("pk_orderline");

                    b.HasIndex("BookId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_line", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.OrderStatus", b =>
                {
                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("status_id");

                    b.Property<string>("StatusValue")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("status_value");

                    b.HasKey("StatusId")
                        .HasName("pk_orderstatus");

                    b.ToTable("order_status", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Publisher", b =>
                {
                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("publisher_id");

                    b.Property<string>("PublisherName")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("publisher_name");

                    b.HasKey("PublisherId");

                    b.ToTable("publisher", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.ShippingMethod", b =>
                {
                    b.Property<Guid>("MethodId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("method_id");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("cost");

                    b.Property<string>("MethodName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("method_name");

                    b.HasKey("MethodId")
                        .HasName("pk_shipmethod");

                    b.ToTable("shipping_method", (string)null);
                });

            modelBuilder.Entity("BookStore.Infrastructure.Models.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("country_id");

                    b.Property<string>("CountryName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("country_name");

                    b.HasKey("CountryId");

                    b.ToTable("country", (string)null);
                });

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.HasOne("BookStore.Domain.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("fk_ba_author");

                    b.HasOne("BookStore.Domain.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("fk_ba_book");
                });

            modelBuilder.Entity("BookStore.Domain.Address", b =>
                {
                    b.HasOne("BookStore.Infrastructure.Models.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("fk_addr_ctry");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BookStore.Domain.Book", b =>
                {
                    b.HasOne("BookStore.Domain.Domain.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategotyId");

                    b.HasOne("BookStore.Domain.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .HasConstraintName("fk_book_pub");

                    b.Navigation("Category");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookStore.Domain.CustomerAddress", b =>
                {
                    b.HasOne("BookStore.Domain.Address", "Address")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("fk_ca_addr");

                    b.HasOne("BookStore.Domain.Customer", "Customer")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("fk_ca_cust");

                    b.HasOne("BookStore.Domain.AddressStatus", "Status")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_customer_address_address_status");

                    b.Navigation("Address");

                    b.Navigation("Customer");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("BookStore.Domain.CustOrder", b =>
                {
                    b.HasOne("BookStore.Domain.Customer", "Customer")
                        .WithMany("CustOrders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("fk_order_cust");

                    b.HasOne("BookStore.Domain.Address", "DestAddress")
                        .WithMany("CustOrders")
                        .HasForeignKey("DestAddressId")
                        .HasConstraintName("fk_order_addr");

                    b.HasOne("BookStore.Domain.ShippingMethod", "ShippingMethod")
                        .WithMany("CustOrders")
                        .HasForeignKey("ShippingMethodId")
                        .HasConstraintName("fk_order_ship");

                    b.Navigation("Customer");

                    b.Navigation("DestAddress");

                    b.Navigation("ShippingMethod");
                });

            modelBuilder.Entity("BookStore.Domain.OrderHistory", b =>
                {
                    b.HasOne("BookStore.Domain.CustOrder", "Order")
                        .WithMany("OrderHistories")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_oh_order");

                    b.HasOne("BookStore.Domain.OrderStatus", "Status")
                        .WithMany("OrderHistories")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("fk_oh_status");

                    b.Navigation("Order");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("BookStore.Domain.OrderLine", b =>
                {
                    b.HasOne("BookStore.Domain.Book", "Book")
                        .WithMany("OrderLines")
                        .HasForeignKey("BookId")
                        .HasConstraintName("fk_ol_book");

                    b.HasOne("BookStore.Domain.CustOrder", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_ol_order");

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BookStore.Domain.Address", b =>
                {
                    b.Navigation("CustOrders");

                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("BookStore.Domain.AddressStatus", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("BookStore.Domain.Book", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("BookStore.Domain.Customer", b =>
                {
                    b.Navigation("CustOrders");

                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("BookStore.Domain.CustOrder", b =>
                {
                    b.Navigation("OrderHistories");

                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("BookStore.Domain.Domain.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStore.Domain.OrderStatus", b =>
                {
                    b.Navigation("OrderHistories");
                });

            modelBuilder.Entity("BookStore.Domain.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStore.Domain.ShippingMethod", b =>
                {
                    b.Navigation("CustOrders");
                });

            modelBuilder.Entity("BookStore.Infrastructure.Models.Country", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}

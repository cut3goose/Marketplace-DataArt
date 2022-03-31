﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Order.Persistence.Context;

namespace OnlineShop.Order.Persistence.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20211115134731_AddAudit")]
    partial class AddAudit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("online_shop.Order.Persistence.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CancelDate")
                        .HasColumnName("cancel_date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CancelReason")
                        .HasColumnName("cancel_reason")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnName("payment_type")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnName("ship_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ShippingPrice")
                        .HasColumnName("shipping_price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ShippingType")
                        .HasColumnName("shipping_type")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("online_shop.Order.Persistence.Entities.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Discount")
                        .HasColumnName("discount")
                        .HasColumnType("real");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId", "ProductId");

                    b.ToTable("order_product");
                });

            modelBuilder.Entity("online_shop.Order.Persistence.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("transaction_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("online_shop.Order.Persistence.Entities.OrderProduct", b =>
                {
                    b.HasOne("online_shop.Order.Persistence.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("online_shop.Order.Persistence.Entities.Transaction", b =>
                {
                    b.HasOne("online_shop.Order.Persistence.Entities.Order", "Order")
                        .WithMany("Transactions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

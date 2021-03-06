// <auto-generated />
using System;
using DemoApplication.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoApplication.Migrations
{
    [DbContext(typeof(databaseContext))]
    [Migration("20220527210230_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoApplication.Data.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("ProductCode");

                    b.Property<decimal?>("price");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("DemoApplication.Data.Entity.PurchaseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("productId");

                    b.Property<int?>("purchaseMasterId");

                    b.Property<int?>("quantity");

                    b.Property<decimal?>("totalPrice");

                    b.HasKey("Id");

                    b.HasIndex("productId");

                    b.HasIndex("purchaseMasterId");

                    b.ToTable("purchaseDetails");
                });

            modelBuilder.Entity("DemoApplication.Data.Entity.PurchaseMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code");

                    b.Property<DateTime?>("purchaseDate");

                    b.Property<int?>("totalQuantity");

                    b.HasKey("Id");

                    b.ToTable("purchaseMasters");
                });

            modelBuilder.Entity("DemoApplication.Data.Entity.PurchaseDetail", b =>
                {
                    b.HasOne("DemoApplication.Data.Entity.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId");

                    b.HasOne("DemoApplication.Data.Entity.PurchaseMaster", "purchaseMaster")
                        .WithMany()
                        .HasForeignKey("purchaseMasterId");
                });
#pragma warning restore 612, 618
        }
    }
}

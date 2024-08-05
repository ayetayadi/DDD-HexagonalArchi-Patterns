﻿// <auto-generated />
using HexagonalDesignPatterns.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HexagonalDesignPatterns.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HexagonalDesignPatterns.Domain.Entities.Smartphone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Smartphones");
                });

            modelBuilder.Entity("HexagonalDesignPatterns.Domain.Entities.Smartphone", b =>
                {
                    b.OwnsOne("HexagonalDesignPatterns.Domain.Entities.Specifications", "Specifications", b1 =>
                        {
                            b1.Property<int>("SmartphoneId")
                                .HasColumnType("int");

                            b1.Property<int>("BatteryLife")
                                .HasColumnType("int");

                            b1.Property<string>("ScreenSize")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("SmartphoneId");

                            b1.ToTable("Smartphones");

                            b1.WithOwner()
                                .HasForeignKey("SmartphoneId");
                        });

                    b.Navigation("Specifications");
                });
#pragma warning restore 612, 618
        }
    }
}

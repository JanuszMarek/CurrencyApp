﻿// <auto-generated />
using System;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyApi.Migrations
{
    [DbContext(typeof(CurrencyContext))]
    [Migration("20210309213519_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Entities.CurrencyDelta", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Delta1H")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Delta24H")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Delta30D")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Delta7D")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Hight24H")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Low24H")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyDeltas");
                });

            modelBuilder.Entity("Entity.Entities.CurrencyPrice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("SymbolId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SymbolId");

                    b.ToTable("CurrencyPrices");
                });

            modelBuilder.Entity("Entity.Entities.Symbol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("SymbolTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SymbolTypeId");

                    b.ToTable("Symbols");
                });

            modelBuilder.Entity("Entity.Entities.SymbolType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("SymbolTypes");
                });

            modelBuilder.Entity("Entity.Entities.CurrencyDelta", b =>
                {
                    b.HasOne("Entity.Entities.CurrencyPrice", "CurrencyPrice")
                        .WithOne("CurrencyDelta")
                        .HasForeignKey("Entity.Entities.CurrencyDelta", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencyPrice");
                });

            modelBuilder.Entity("Entity.Entities.CurrencyPrice", b =>
                {
                    b.HasOne("Entity.Entities.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Symbol");
                });

            modelBuilder.Entity("Entity.Entities.Symbol", b =>
                {
                    b.HasOne("Entity.Entities.SymbolType", "SymbolType")
                        .WithMany()
                        .HasForeignKey("SymbolTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SymbolType");
                });

            modelBuilder.Entity("Entity.Entities.CurrencyPrice", b =>
                {
                    b.Navigation("CurrencyDelta");
                });
#pragma warning restore 612, 618
        }
    }
}

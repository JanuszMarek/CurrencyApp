﻿// <auto-generated />
using System;
using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyApi.Migrations
{
    [DbContext(typeof(CurrencyContext))]
    [Migration("20210309200326_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF.Entities.CurrencyDelta", b =>
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

            modelBuilder.Entity("EF.Entities.CurrencyPrice", b =>
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

            modelBuilder.Entity("EF.Entities.Symbol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("SymbolName")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("SymbolTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SymbolTypeId");

                    b.ToTable("Symbols");
                });

            modelBuilder.Entity("EF.Entities.SymbolType", b =>
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

            modelBuilder.Entity("EF.Entities.CurrencyDelta", b =>
                {
                    b.HasOne("EF.Entities.CurrencyPrice", "CurrencyPrice")
                        .WithOne("CurrencyDelta")
                        .HasForeignKey("EF.Entities.CurrencyDelta", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencyPrice");
                });

            modelBuilder.Entity("EF.Entities.CurrencyPrice", b =>
                {
                    b.HasOne("EF.Entities.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Symbol");
                });

            modelBuilder.Entity("EF.Entities.Symbol", b =>
                {
                    b.HasOne("EF.Entities.SymbolType", "SymbolType")
                        .WithMany()
                        .HasForeignKey("SymbolTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SymbolType");
                });

            modelBuilder.Entity("EF.Entities.CurrencyPrice", b =>
                {
                    b.Navigation("CurrencyDelta");
                });
#pragma warning restore 612, 618
        }
    }
}

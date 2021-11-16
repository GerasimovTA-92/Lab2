﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab2;

namespace lab2.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20211111120817_initial_table")]
    partial class initial_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab2.Bill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<int>("Currency_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Currencyid")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Currencyid");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("lab2.Card", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bill_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Billid")
                        .HasColumnType("int");

                    b.Property<string>("CVC_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("Billid");

                    b.HasIndex("Userid");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("lab2.Credit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Guarantor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Percent")
                        .HasColumnType("int");

                    b.Property<string>("Pledge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Term")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("lab2.Currency", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("lab2.Deposit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Current_Amount")
                        .HasColumnType("real");

                    b.Property<float>("Initial_Amount")
                        .HasColumnType("real");

                    b.Property<int>("Percent")
                        .HasColumnType("int");

                    b.Property<DateTime>("Term")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("lab2.EmployeeData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("lab2.ExchangeCurrency", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Buy")
                        .HasColumnType("real");

                    b.Property<int>("CurrencyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Sale")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("CurrencyID");

                    b.ToTable("ExchangeCurrencies");
                });

            modelBuilder.Entity("lab2.Operation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExchangeCurrencyID")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("BillID");

                    b.HasIndex("ExchangeCurrencyID");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("lab2.Service", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Credit_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Creditid")
                        .HasColumnType("int");

                    b.Property<int>("Deposit_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Depositid")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Creditid");

                    b.HasIndex("Depositid");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("lab2.UserData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("lab2.Bill", b =>
                {
                    b.HasOne("lab2.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("Currencyid");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("lab2.Card", b =>
                {
                    b.HasOne("lab2.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("Billid");

                    b.HasOne("lab2.UserData", "User")
                        .WithMany()
                        .HasForeignKey("Userid");

                    b.Navigation("Bill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("lab2.ExchangeCurrency", b =>
                {
                    b.HasOne("lab2.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("lab2.Operation", b =>
                {
                    b.HasOne("lab2.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lab2.ExchangeCurrency", "currency")
                        .WithMany()
                        .HasForeignKey("ExchangeCurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("currency");
                });

            modelBuilder.Entity("lab2.Service", b =>
                {
                    b.HasOne("lab2.Credit", "Credit")
                        .WithMany()
                        .HasForeignKey("Creditid");

                    b.HasOne("lab2.Deposit", "Deposit")
                        .WithMany()
                        .HasForeignKey("Depositid");

                    b.Navigation("Credit");

                    b.Navigation("Deposit");
                });

            modelBuilder.Entity("lab2.UserData", b =>
                {
                    b.HasOne("lab2.EmployeeData", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
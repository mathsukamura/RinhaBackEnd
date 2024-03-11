﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RinhaBackEnd.Infra.Context;

#nullable disable

namespace RinhaBackEnd.Migrations
{
    [DbContext(typeof(DbContextCfg))]
    partial class DbContextCfgModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RinhaBackEnd.Models.Client.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Limite")
                        .HasColumnType("int")
                        .HasColumnName("limite");

                    b.Property<int>("Saldo")
                        .HasColumnType("int")
                        .HasColumnName("saldo");

                    b.Property<uint>("Xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id");

                    b.ToTable("cliente", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Limite = 100000,
                            Saldo = 0
                        },
                        new
                        {
                            Id = 2,
                            Limite = 80000,
                            Saldo = 0
                        },
                        new
                        {
                            Id = 3,
                            Limite = 1000000,
                            Saldo = 0
                        },
                        new
                        {
                            Id = 4,
                            Limite = 10000000,
                            Saldo = 0
                        },
                        new
                        {
                            Id = 5,
                            Limite = 500000,
                            Saldo = 0
                        });
                });

            modelBuilder.Entity("RinhaBackEnd.Models.Client.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("descricao");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer")
                        .HasColumnName("id_cliente");

                    b.Property<DateTime>("RealizadoEm")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("realizado_em");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(1)")
                        .HasColumnName("tipo");

                    b.Property<int>("Valor")
                        .HasColumnType("int")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("transacao", (string)null);
                });

            modelBuilder.Entity("RinhaBackEnd.Models.Client.Transacao", b =>
                {
                    b.HasOne("RinhaBackEnd.Models.Client.Cliente", "Cliente")
                        .WithMany("Transacoes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("RinhaBackEnd.Models.Client.Cliente", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}

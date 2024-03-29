﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RinhaBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    limite = table.Column<int>(type: "int", nullable: false),
                    saldo = table.Column<int>(type: "int", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_cliente = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "varchar(1)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(10)", nullable: false),
                    realizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_transacao_cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "id", "limite", "saldo" },
                values: new object[,]
                {
                    { 1, 100000, 0 },
                    { 2, 80000, 0 },
                    { 3, 1000000, 0 },
                    { 4, 10000000, 0 },
                    { 5, 500000, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_transacao_id_cliente",
                table: "transacao",
                column: "id_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transacao");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}

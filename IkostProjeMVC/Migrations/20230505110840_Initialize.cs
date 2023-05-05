﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkostProjeMVC.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bayilers",
                columns: table => new
                {
                    BayiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BayiAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakedisYuzde = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bayilers", x => x.BayiID);
                });

            migrationBuilder.CreateTable(
                name: "Siparislers",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisTutar = table.Column<int>(type: "int", nullable: false),
                    HakedisTutar = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BayiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparislers", x => x.SiparisID);
                    table.ForeignKey(
                        name: "FK_Siparislers_Bayilers_BayiID",
                        column: x => x.BayiID,
                        principalTable: "Bayilers",
                        principalColumn: "BayiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparislers_BayiID",
                table: "Siparislers",
                column: "BayiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siparislers");

            migrationBuilder.DropTable(
                name: "Bayilers");
        }
    }
}
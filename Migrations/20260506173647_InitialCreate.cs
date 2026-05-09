using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcRentApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    BidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.BidId);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuisnessCenterAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuisnessCenterFloor = table.Column<int>(type: "int", nullable: false),
                    OfficeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeSquare = table.Column<double>(type: "float", nullable: false),
                    RentalRate = table.Column<double>(type: "float", nullable: false),
                    OfficeState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeLayout = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}

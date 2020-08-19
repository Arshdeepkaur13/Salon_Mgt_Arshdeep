using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon_Mgt_Arshdeep.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Msts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Msts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Staff_Msts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff_Msts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Appointment_Msts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_MstID = table.Column<int>(nullable: false),
                    Customer_MstID = table.Column<int>(nullable: false),
                    AppointmentDate = table.Column<DateTime>(nullable: true),
                    Charges = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment_Msts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointment_Msts_Customer_Msts_Customer_MstID",
                        column: x => x.Customer_MstID,
                        principalTable: "Customer_Msts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Msts_Staff_Msts_Staff_MstID",
                        column: x => x.Staff_MstID,
                        principalTable: "Staff_Msts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Msts_Customer_MstID",
                table: "Appointment_Msts",
                column: "Customer_MstID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Msts_Staff_MstID",
                table: "Appointment_Msts",
                column: "Staff_MstID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment_Msts");

            migrationBuilder.DropTable(
                name: "Customer_Msts");

            migrationBuilder.DropTable(
                name: "Staff_Msts");
        }
    }
}

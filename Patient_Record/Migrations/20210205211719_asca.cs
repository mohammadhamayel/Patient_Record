using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patient_Record.Migrations
{
    public partial class asca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetPatient_Records",
                columns: table => new
                {
                    Patient_Record_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Id = table.Column<int>(type: "int", nullable: false),
                    Disease_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time_Of_Entry = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bill = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetPatient_Records", x => x.Patient_Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Official_ID = table.Column<int>(type: "int", nullable: false),
                    Patient_DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Patient_Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Patient_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Patient_Official_ID",
                table: "Patients",
                column: "Patient_Official_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetPatient_Records");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}

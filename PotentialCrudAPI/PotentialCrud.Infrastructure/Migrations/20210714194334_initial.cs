using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PotentialCrud.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Hobby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Desenvolvedores",
                columns: new[] { "Nome", "Sexo", "Idade", "Hobby", "DataNascimento" },
                values: new object[,]
                {
                    { "Ada Lovelace", "F", 36, "	Escrever algoritmos", Convert.ToDateTime("10/12/1815") },
                    { "Alan Turing", "M", 41, "Propor modelos", Convert.ToDateTime("	23/06/1912") },
                    { "Edsger Dijkstra", "M", 72, "Algoritmos recursivos", Convert.ToDateTime("11/05/1930")  },
                    { "Donald Knuth", "M", 83, "Analisar algoritmos", Convert.ToDateTime("19/01/1938") },
                    { "Andrew S. Tanenbaum", "M", 77, "Estudar sistemas operacionais", Convert.ToDateTime("16/03/1944") }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desenvolvedores");
        }
    }
}

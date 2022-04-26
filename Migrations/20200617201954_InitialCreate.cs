using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    Fabricante = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    AnoFab = table.Column<System.DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}

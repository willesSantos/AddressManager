using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressManagerAPI.Migrations
{
    public partial class onDbMigrationAddressManagerApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Ibge = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Gia = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Ddd = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Siafi = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.Cep);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "endereco");
        }
    }
}

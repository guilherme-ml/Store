using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class Store : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PosCategoria",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Situacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescSituacaoCompra = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IdfAtivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Situacao");

            migrationBuilder.AlterColumn<string>(
                name: "PosCategoria",
                table: "Categories",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

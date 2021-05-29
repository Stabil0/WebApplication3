using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Position_code = table.Column<int>(type: "INT", nullable: false),
                    Job_title = table.Column<string>(type: "CHAR (255)", nullable: false),
                    Salary = table.Column<int>(type: "INT", nullable: false),
                    Responsibilities = table.Column<string>(type: "CHAR (255)", nullable: false),
                    Requirements = table.Column<string>(type: "CHAR (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Position_code);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Ingredient_code = table.Column<int>(type: "INT", nullable: false),
                    Ingredient_name = table.Column<string>(type: "CHAR (255)", nullable: false),
                    Data = table.Column<int>(type: "INT", nullable: false),
                    Volume = table.Column<int>(type: "INT", nullable: false),
                    Shelf__ife = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false),
                    Provider = table.Column<string>(type: "CHAR (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Ingredient_code);
                });

            migrationBuilder.CreateTable(
                name: "Emploeey",
                columns: table => new
                {
                    Employee_code = table.Column<int>(type: "INT", nullable: false),
                    Full_name = table.Column<string>(type: "CHAR (255)", nullable: false),
                    Old = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "CHAR (50)", nullable: false),
                    Adress = table.Column<string>(type: "CHAR (255)", nullable: false),
                    Phone = table.Column<int>(type: "INT", nullable: false),
                    Passport_data = table.Column<int>(type: "INT", nullable: false),
                    Position_code = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emploeey", x => x.Employee_code);
                    table.ForeignKey(
                        name: "FK_Emploeey_Position_Position_code",
                        column: x => x.Position_code,
                        principalTable: "Position",
                        principalColumn: "Position_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Dish_Code = table.Column<int>(type: "INT", nullable: false),
                    Dish_name = table.Column<string>(type: "CHAR (255)", nullable: false),
                    volume_1 = table.Column<int>(type: "INT", nullable: false),
                    volume_2 = table.Column<int>(type: "INT", nullable: false),
                    volume_3 = table.Column<int>(type: "INT", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false),
                    Time = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ingredient_code = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Dish_Code);
                    table.ForeignKey(
                        name: "FK_Menu_Warehouse_Ingredient_code",
                        column: x => x.Ingredient_code,
                        principalTable: "Warehouse",
                        principalColumn: "Ingredient_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orde",
                columns: table => new
                {
                    Customer_name = table.Column<string>(type: "CHAR (255)", nullable: false),
                    Data = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Time = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Phone = table.Column<int>(type: "INT", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false),
                    Chec = table.Column<int>(type: "INT", nullable: false),
                    Employee_code = table.Column<int>(type: "INT", nullable: false),
                    Dish_Code = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orde", x => x.Customer_name);
                    table.ForeignKey(
                        name: "FK_Orde_Menu_Dish_Code",
                        column: x => x.Dish_Code,
                        principalTable: "Menu",
                        principalColumn: "Dish_Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orde_Emploeey_Employee_code",
                        column: x => x.Employee_code,
                        principalTable: "Emploeey",
                        principalColumn: "Employee_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emploeey_Position_code",
                table: "Emploeey",
                column: "Position_code");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Ingredient_code",
                table: "Menu",
                column: "Ingredient_code");

            migrationBuilder.CreateIndex(
                name: "IX_Orde_Dish_Code",
                table: "Orde",
                column: "Dish_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Orde_Employee_code",
                table: "Orde",
                column: "Employee_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orde");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Emploeey");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}

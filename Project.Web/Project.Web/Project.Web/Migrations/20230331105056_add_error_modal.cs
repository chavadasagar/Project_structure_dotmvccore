using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Web.Migrations
{
    /// <inheritdoc />
    public partial class add_error_modal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Error",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    StackTrace = table.Column<string>(type: "TEXT", nullable: true),
                    Createdby = table.Column<int>(type: "INTEGER", nullable: true),
                    Updatedby = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Updateddate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    isactive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Createdby = table.Column<int>(type: "INTEGER", nullable: true),
                    Updatedby = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Updateddate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    Mobile = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    RoleidFk = table.Column<int>(type: "INTEGER", nullable: false),
                    Createdby = table.Column<int>(type: "INTEGER", nullable: true),
                    Updatedby = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Updateddate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Error");

            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

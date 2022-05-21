using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABEGestionProyectos.Infrastructure.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Responsible = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    SprintID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Estate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.SprintID);
                });

            migrationBuilder.CreateTable(
                name: "Epics",
                columns: table => new
                {
                    EpicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epics", x => x.EpicID);
                    table.ForeignKey(
                        name: "FK_Epics_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_People_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHistories",
                columns: table => new
                {
                    UserHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IAsA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    INeed = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SoThat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Estimate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EpicID = table.Column<int>(type: "int", nullable: false),
                    SprintID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistories", x => x.UserHistoryID);
                    table.ForeignKey(
                        name: "FK_UserHistories_Epics_EpicID",
                        column: x => x.EpicID,
                        principalTable: "Epics",
                        principalColumn: "EpicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHistories_Sprints_SprintID",
                        column: x => x.SprintID,
                        principalTable: "Sprints",
                        principalColumn: "SprintID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chores",
                columns: table => new
                {
                    ChoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    UserHistoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chores", x => x.ChoreID);
                    table.ForeignKey(
                        name: "FK_Chores_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chores_UserHistories_UserHistoryID",
                        column: x => x.UserHistoryID,
                        principalTable: "UserHistories",
                        principalColumn: "UserHistoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "Description", "Name", "Responsible", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, "juego para moviles", "CRAPS", "ABE", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "App para Android" },
                    { 2, "juego para moviles", "4 PALABRAS", "ABE", new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "App para Android" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Name" },
                values: new object[,]
                {
                    { 1, "Informador" },
                    { 2, "Desarrollador" }
                });

            migrationBuilder.InsertData(
                table: "Sprints",
                columns: new[] { "SprintID", "Estate", "Name", "Points" },
                values: new object[,]
                {
                    { 1, "Por empezar", "G3 - Modelado", 3 },
                    { 2, "En proceso", "G3 - Productos", 5 }
                });

            migrationBuilder.InsertData(
                table: "Epics",
                columns: new[] { "EpicID", "Name", "ProjectID" },
                values: new object[,]
                {
                    { 1, "Gestión de la BD", 1 },
                    { 2, "Gestión de UI", 2 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonID", "Name", "RoleID" },
                values: new object[,]
                {
                    { 1, "Ronal Estrada", 1 },
                    { 2, "Andre Maylle", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserHistories",
                columns: new[] { "UserHistoryID", "EpicID", "Estimate", "IAsA", "INeed", "Priority", "SoThat", "SprintID", "Title" },
                values: new object[] { 1, 1, "8", "Admin", "Ver un listado de productos completo", "Alta", "Atender las consultas de los clientes", 1, "Listado de Productos" });

            migrationBuilder.InsertData(
                table: "UserHistories",
                columns: new[] { "UserHistoryID", "EpicID", "Estimate", "IAsA", "INeed", "Priority", "SoThat", "SprintID", "Title" },
                values: new object[] { 2, 2, "5", "Admin", "Ver un listado de modelados completo", " Muy Alta", "Atender las consultas de los usuarios", 2, "Listado de modelados" });

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "ChoreID", "Name", "PersonID", "Points", "State", "UserHistoryID" },
                values: new object[] { 1, "Llenado BD", 1, 3, "En proceso", 1 });

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "ChoreID", "Name", "PersonID", "Points", "State", "UserHistoryID" },
                values: new object[] { 2, "Llenado tablas", 2, 5, "Por empezar", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Chores_PersonID",
                table: "Chores",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Chores_UserHistoryID",
                table: "Chores",
                column: "UserHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Epics_ProjectID",
                table: "Epics",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_People_RoleID",
                table: "People",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistories_EpicID",
                table: "UserHistories",
                column: "EpicID");

            migrationBuilder.CreateIndex(
                name: "IX_UserHistories_SprintID",
                table: "UserHistories",
                column: "SprintID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chores");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "UserHistories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Epics");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}

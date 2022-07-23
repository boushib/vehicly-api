using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vehicly.Migrations.Users;

public partial class UsersMigration : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.AlterDatabase()
      .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

    migrationBuilder.CreateTable(
      "Users",
      table => new
      {
        Id = table.Column<Guid>("uuid", nullable: false),
        Username = table.Column<string>("text", nullable: false),
        Password = table.Column<string>("text", nullable: false),
        Roles = table.Column<List<string>>("text[]", nullable: true)
      },
      constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
      "Users");
  }
}
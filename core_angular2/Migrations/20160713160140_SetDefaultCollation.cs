using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace core_angular2.Migrations
{
    public partial class SetDefaultCollation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER DATABASE dotnetcore_angular2 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", suppressTransaction: true);
            migrationBuilder.Sql("ALTER DATABASE dotnetcore_angular2 COLLATE Japanese_BIN2;", suppressTransaction: true);
            migrationBuilder.Sql("ALTER DATABASE dotnetcore_angular2 SET MULTI_USER;", suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

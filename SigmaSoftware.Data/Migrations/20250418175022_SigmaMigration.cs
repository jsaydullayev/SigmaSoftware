using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigmaSoftware.Data.Migrations
{
    /// <inheritdoc />
    public partial class SigmaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "my");

            migrationBuilder.CreateTable(
                name: "Candidates",
                schema: "my",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    call_start_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    call_end_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    linkedin_profile = table.Column<string>(type: "text", nullable: true),
                    git_hub_profile = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_email",
                schema: "my",
                table: "Candidates",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates",
                schema: "my");
        }
    }
}

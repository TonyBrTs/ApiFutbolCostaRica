using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiFutbolCostaRica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalIdAndMatchDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Matches]') AND name = N'ExternalId')
                BEGIN
                    ALTER TABLE [dbo].[Matches] ADD [ExternalId] int NOT NULL DEFAULT 0;
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Matches]') AND name = N'Referee')
                BEGIN
                    ALTER TABLE [dbo].[Matches] ADD [Referee] nvarchar(max) NOT NULL DEFAULT '';
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Matches]') AND name = N'Venue')
                BEGIN
                    ALTER TABLE [dbo].[Matches] ADD [Venue] nvarchar(max) NOT NULL DEFAULT '';
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Referee",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Matches");
        }
    }
}

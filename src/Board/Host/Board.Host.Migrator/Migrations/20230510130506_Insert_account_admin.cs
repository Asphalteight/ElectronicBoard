using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Host.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Insert_account_admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var insert_query = $"INSERT INTO public.\"Accounts\" (\"Name\", \"Email\", \"Password\", \"CreatedAt\") VALUES ";
            insert_query += $"('Администратор', 'admin', 'admin', '{DateTime.UtcNow}')";

            migrationBuilder.Sql(insert_query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

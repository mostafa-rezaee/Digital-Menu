using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigiMenu.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class add_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE [product].Products
                ADD CONSTRAINT FK_Products_Categories_CategoryId
                FOREIGN KEY (CategoryId) REFERENCES [category].Categories(Id);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

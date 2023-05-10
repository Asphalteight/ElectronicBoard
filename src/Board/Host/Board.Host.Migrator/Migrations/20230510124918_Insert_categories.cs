using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Host.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Insert_categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var insert_query = $"INSERT INTO public.\"Categories\" (\"Name\", \"ParentCategoryId\") VALUES ";
            var categories =
                " ('Электроника', 0)," +
                " ('Бытовая техника', 0)," +
                " ('Одежда', 0)," +
                " ('Авто', 0)," +
                " ('Недвижимость', 0)," +
                " ('Другое', 0),";
            
            var subCategories =
                " ('Компьютеры', 1)," +
                " ('Мобильные устройства', 1)," +
                " ('Мужская', 3)," +
                " ('Женская', 3)," +
                " ('Автомобили', 4)," +
                " ('Запчасти для авто', 4)," +
                " ('Квартиры', 5)," +
                " ('Частные дома', 5)," +
                " ('Участки', 5),";
            
            var subSubCategories = 
                " ('Видеокарты', 7)," +
                " ('Процессоры', 7)," +
                " ('Оперативная память', 7)," +
                " ('Накопители', 7)," +
                " ('Смартфоны', 8)," +
                " ('Планшеты', 8)," +
                " ('Телефоны', 8)";
            insert_query += categories + subCategories + subSubCategories;
            
            migrationBuilder.Sql(insert_query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

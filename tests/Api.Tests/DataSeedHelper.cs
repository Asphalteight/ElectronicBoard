using System;
using Board.Domain.Advertisement;
using Board.Domain.Category;
using Board.Infrastructure.DataAccess;

namespace Api.Tests;

public static class DataSeedHelper
{
    public static int TestAdvertId { get; set; }
    public static int TestCategoryId { get; set; }

    public static void InitializeDbForTests(BoardDbContext db)
    {
        var testCategory = new Categories
        {
            Name = "Какая-то категория",
        };
        db.Add(testCategory);

        TestCategoryId = testCategory.Id;

        var advert = new Advertisements
        {
            Title = "Какое-то название",
            Description = "Какое-то описание",
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CategoryId = testCategory.Id,
            Address = "Какой-то адрес"
        };
        db.Add(advert);

        db.SaveChanges();

        TestAdvertId = advert.Id;
    }
}    
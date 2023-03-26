using AutoMapper;
using Board.Application.AppData.Context.Account.Repositories;
using Board.Application.AppData.Context.Account.Services;
using Board.Application.AppData.Context.Advertisement.Repositories;
using Board.Application.AppData.Context.Advertisement.Services;
using Board.Application.AppData.Context.Category.Repositories;
using Board.Application.AppData.Context.Category.Services;
using Board.Application.AppData.Context.Comment.Repositories;
using Board.Application.AppData.Context.Comment.Services;
using Board.Application.AppData.Context.Message.Repositories;
using Board.Application.AppData.Context.Message.Services;
using Board.Application.AppData.Context.Subcategory.Repositories;
using Board.Application.AppData.Context.Subcategory.Services;
using Board.Contracts.Contexts.Accounts;
using Board.Infrastructure.DataAccess;
using Board.Infrastructure.DataAccess.Contexts.Account.Repository;
using Board.Infrastructure.DataAccess.Contexts.Advertisement.Repository;
using Board.Infrastructure.DataAccess.Contexts.Category.Repository;
using Board.Infrastructure.DataAccess.Contexts.Comment.Repository;
using Board.Infrastructure.DataAccess.Contexts.Message.Repository;
using Board.Infrastructure.DataAccess.Contexts.Subcategory.Repository;
using Board.Infrastructure.DataAccess.Interfaces;
using Board.Infrastructure.MapProfiles;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddSingleton<IDbContextOptionsConfigurator<BoardDbContext>, BoardDbContextConfiguration>();
        
builder.Services.AddDbContext<BoardDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
    ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<BoardDbContext>>()
        .Configure((DbContextOptionsBuilder<BoardDbContext>)dbOptions)));

builder.Services.AddScoped((Func<IServiceProvider, DbContext>) (sp => sp.GetRequiredService<BoardDbContext>()));

// Add repositories to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

// Add services to the container.
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMessageService, MessageService>();

// Add automapper
builder.Services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Advert Api", Version = "V1" });
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, $"{typeof(CreateAccountDto).Assembly.GetName().Name}.xml")));
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static MapperConfiguration GetMapperConfiguration()
{
    var configuration = new MapperConfiguration(cfg => 
    {
        cfg.AddProfile<AdvertisementProfile>();
        cfg.AddProfile<AccountProfile>();
        cfg.AddProfile<CategoryProfile>();
        cfg.AddProfile<SubcategoryProfile>();
        cfg.AddProfile<CommentProfile>();
        cfg.AddProfile<MessageProfile>();
    });
    configuration.AssertConfigurationIsValid();
    return configuration;
}
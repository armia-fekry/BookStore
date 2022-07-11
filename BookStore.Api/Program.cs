using BookStore.Application.IRepositories;
using BookStore.Application.Services.BooksServices;
using BookStore.Application.Services.CategoriesServices;
using BookStore.Application.Services.CustOrderServices;
using BookStore.Application.Services.OrderHistories;
using BookStore.Application.Services.PublisherService;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseSerilog((ctx, config) =>
//{
//	config.MinimumLevel.Debug();
//	config.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning);
//	config.WriteTo.File(new RenderedCompactJsonFormatter(), @$"{Environment.CurrentDirectory}");
//});
// Add services to the container.
#region Add Cors 
builder.Services.AddCors(options =>
{

    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
#endregion

builder.Services.AddDbContext<BookStoreContext>(opt => {
	opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
	});
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<ICustOrderService, CustOrderService>();
builder.Services.AddTransient<IOrderHistoryService, OrderHistoryService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddControllers();
builder.Services.Configure<JsonOptions>(opt=>
{
	opt.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "ImgFiles")),
    RequestPath = "/ImgFiles",
    EnableDefaultFiles = true
});
app.UseCors("AllowOrigin");
app.UseAuthorization();
app.MapControllers();

app.Run();

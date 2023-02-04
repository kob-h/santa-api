using Microsoft.EntityFrameworkCore;
using SantaApi.BusinessService;
using SantaApi.DAL;
using SantaApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddScoped<IGiftsService, GiftsService>();
builder.Services.AddScoped<IChildrenRepository, ChildrenRepository>();
builder.Services.AddScoped<IGiftsRepository, GiftsRepository>();
builder.Services.AddScoped<IChildGiftOwndershipRepository, ChildGiftOwndershipRepository>();
builder.Services.AddDbContext<SantaDb>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SantaDb")));

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


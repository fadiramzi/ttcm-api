using ttcm_api.Contexts;
using ttcm_api.Interfaces;
using ttcm_api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MainAppContext>(options => options.UseSqlite("Data Source=ttcm.db"));

builder.Services.AddScoped<ICategoryCRUD, CategoryService>();
builder.Services.AddScoped<IProgramCRUD, ProgramsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

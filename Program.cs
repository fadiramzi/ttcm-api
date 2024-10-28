using ttcm_api.Contexts;
using ttcm_api.Interfaces;
using ttcm_api.Services;
using Microsoft.EntityFrameworkCore;
using ttcm_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MainAppContext>(options => options.UseSqlite("Data Source=ttcm.db"));

// Add IDentity
builder.Services.AddIdentity<User, ApplicationRole>()
     .AddEntityFrameworkStores<MainAppContext>()
    .AddDefaultTokenProviders();


IConfiguration Configuration = builder.Configuration;
var JwtSettings = Configuration.GetSection("Jwt");
var Key = System.Text.Encoding.UTF8.GetBytes(JwtSettings["Key"]);
var Issuer = JwtSettings["Issuer"];
var Audience = JwtSettings["Audience"];
var ExpireInMinutes = JwtSettings["ExpireInMinutes"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {

        ValidateIssuer = true,
        ValidIssuer = Issuer,
        ValidateAudience = true,
        ValidAudience = Audience,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<ICategoryCRUD, CategoryService>();
builder.Services.AddScoped<IProgramCRUD, ProgramsService>();
builder.Services.AddScoped<ITrainerCRUD, TrainerService>();

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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

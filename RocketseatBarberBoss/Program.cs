using Api.Filters;
using Api.Middleware;
using Application;
using Infraestructure;
using Infraestructure.Migrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());

builder.Services.AddApplicationServices();
builder.Services.AddInfraServices(builder.Configuration);

AddJwtBerar();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();


async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();

    await DataBaseMigration.MigrateDataBase(scope.ServiceProvider);
}

void AddJwtBerar()
{

    var sigingKey = builder.Configuration.GetValue<string>("Settings:Jwt:SigningKey")!;
    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sigingKey));
    var tokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = new TimeSpan(0),
        IssuerSigningKey = symmetricSecurityKey
    };

    builder.Services
        .AddAuthentication(config =>
    {
        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(config =>
    {
        config.TokenValidationParameters = tokenValidationParameters;
    });
}

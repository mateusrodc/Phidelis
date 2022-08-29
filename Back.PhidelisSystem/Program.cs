using Back.PhidelisSystem;
using Back.PhidelisSystem.Application.Interfaces;
using Back.PhidelisSystem.Application.Services;
using Back.PhidelisSystem.Domain.Interfaces;
using Back.PhidelisSystem.HostedService;
using Back.PhidelisSystem.Infra;
using Back.PhidelisSystem.Infra.Data;
using Back.PhidelisSystem.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHostedService<TimerHostedService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddDbContext<SqlContext>(options => options.UseNpgsql(ConnectionString.Connect));
builder.Services.AddScoped<SqlContext, SqlContext>();
builder.Services.AddScoped<IRegistrationApplication, RegistrationApplication>();
builder.Services.AddScoped<IStudentApplication, StudentApplication>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAuthentication(x =>
{
x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
x.RequireHttpsMetadata = false;
x.SaveToken = true;
x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();

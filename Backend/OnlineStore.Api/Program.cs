using OnlineStore.Infrastructure;
using OnlineStore.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineStore.Application.Options;
using OnlineStore.Api.TestMiddleware;
var builder = WebApplication.CreateBuilder(args);

var tokenIssuer = builder.Configuration.GetSection("Token:Issuer").Get<string>();
var tokenKey = builder.Configuration.GetSection("Token:Key").Get<string>() ?? string.Empty;
var originUrl = builder.Configuration.GetSection("OriginUrl").Get<string>() ?? string.Empty;
// will be get variable from Environment Variable before read from appsetting.json and the same json file
builder.Configuration.AddEnvironmentVariables();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.Configure<JwtTokenOption>(builder.Configuration.GetSection("Token"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = tokenIssuer,
         ValidAudience = tokenIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey))
     };
 });

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(x => x.WithOrigins(originUrl)
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<TestMiddleware>();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

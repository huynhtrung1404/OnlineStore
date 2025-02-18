using OnlineStore.Infrastructure;
using OnlineStore.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineStore.Application.Options;
using OnlineStore.Shared.Common.Constants;
var builder = WebApplication.CreateBuilder(args);

// will be get variable from Environment Variable before read from appsetting.json and the same json file
builder.Configuration.AddEnvironmentVariables();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddWebApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.Configure<JwtTokenOption>(builder.Configuration.GetSection(DefaultSchemas.Token));
builder.Services.AddAuthentication(option => option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     var tokenIssuer = builder.Configuration.GetSection(DefaultSchemas.JwtIssuer).Get<string>();
     var tokenKey = builder.Configuration.GetSection(DefaultSchemas.JwtTokenKey).Get<string>();
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = tokenIssuer,
         ValidAudience = tokenIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey!))
     };
 });
builder.Services.AddCors(option =>
{
    var originUrls = builder.Configuration.GetSection(DefaultSchemas.OriginUrl).Get<string[]>();
    option.AddDefaultPolicy(x => x.WithOrigins(originUrls!)
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

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

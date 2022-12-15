using Microsoft.AspNetCore.Authentication.JwtBearer;
using MyFirstBlog.Helpers;
using MyFirstBlog.Services;

var  MyAllowLocalhostOrigins = "_myAllowLocalhostOrigins";

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var env = builder.Environment;

// Add services to the container.

services.AddDbContext<DataContext>();

services.AddCors(policyBuilder => {
    policyBuilder.AddPolicy( MyAllowLocalhostOrigins,
        policy => {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
     {
         c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
         c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
         {
             ValidAudience = builder.Configuration["Auth0:Audience"],
             ValidIssuer = $"{builder.Configuration["Auth0:Domain"]}"
         };
     });

builder.Services.AddAuthorization(o =>
    {
        o.AddPolicy("post:read-write", p => p.
            RequireAuthenticatedUser().
            RequireClaim("scope", "post:read-write"));
    });

services.AddScoped<IPostService, PostService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
await DataHelper.ManageDataAsync(scope.ServiceProvider);

// Configure the HTTP request pipeline.
if (env.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(MyAllowLocalhostOrigins);
}

if (env.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

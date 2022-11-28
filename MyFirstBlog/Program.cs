using MyFirstBlog.Helpers;
using MyFirstBlog.Repositories;

var  MyAllowLocalhostOrigins = "_myAllowLocalhostOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>();

builder.Services.AddCors(policyBuilder => {
    policyBuilder.AddPolicy( MyAllowLocalhostOrigins,
        policy => {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddSingleton<IPostsRepository, InMemPostsRepository>();
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

    app.UseCors(MyAllowLocalhostOrigins);
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

using ZooHelp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var serviceScope = app.Services.CreateScope();

    {
        var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
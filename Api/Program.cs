using Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDataAccessService(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MigrateDb();

app.Run();

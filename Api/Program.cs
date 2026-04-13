using Api.StartupConfigurations.Options;
using Application;
using Domain;
using Infrastructure;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;

var builder = WebApplication.CreateBuilder(args);

#if DEBUG
builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<UlidSchemaFilter>();
    c.SchemaFilter<EnumSchemaFilter>();

    Directory
        .GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
        .ToList()
        .ForEach(xmlFile =>
        {
            var doc = XDocument.Load(xmlFile);
            c.IncludeXmlComments(() => new XPathDocument(doc.CreateReader()), includeControllerXmlComments: true);
        });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Telegram Mini App API",
        Version = "v1",
        Description = "API for Telegram Mini Application"
    });
});
#endif

builder.Services.RegisterDataAccessService(builder.Configuration);
builder.Services.RegisterUseCasesService();
builder.Services.RegisterInfrastructureServices();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

#if DEBUG
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "haTracker API v1");
    c.DefaultModelsExpandDepth(-1);
    c.DisplayRequestDuration();
});
#endif

app.MapControllers();

#if DEBUG
app.UseCors("AllowAll");
#endif

app.MigrateDb();

app.Run();

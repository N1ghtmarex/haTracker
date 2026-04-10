using Api.StartupConfigurations.Options;
using Application;
using Domain;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;
using System.Xml.XPath;

var builder = WebApplication.CreateBuilder(args);

#if DEBUG
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

builder.Services.AddControllers();

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

app.MigrateDb();

app.Run();

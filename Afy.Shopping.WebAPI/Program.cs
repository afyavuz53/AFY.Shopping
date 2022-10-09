using Afy.Shopping.BLL;
using Afy.Shopping.Core;
using Afy.Shopping.Model.Settings;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catalog API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Ahmet Fehmi Yavuz",
            Email = "a.fehmi.yavuz@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/ahmet-fehmi-yavuz"),
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.Configure<ShoppingDatabaseSettings>(builder.Configuration.GetSection(nameof(ShoppingDatabaseSettings)));
builder.Services.AddBusinessLogicLayer(builder.Configuration);
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API V1");
        //c.RoutePrefix = "";
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

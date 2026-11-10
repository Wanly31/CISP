using CispOData.Data;
using CispOData.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Grades>("Grades");
modelBuilder.EntitySet<Students>("Students");
modelBuilder.EntitySet<Subjects>("Subjects");
modelBuilder.EntitySet<Teachers>("Teachers");

// Add services to the container.

builder.Services.AddDbContext<StudentContext>();

builder.Services.AddControllers().AddOData(opt =>
    opt.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100)
    .AddRouteComponents("odata", modelBuilder.GetEdmModel()));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseDefaultFiles();   // / -> wwwroot/index.html
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

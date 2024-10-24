using EnterpriseWarehouse.API.Mapper;
using EnterpriseWarehouse.API.Services;
using EnterpriseWarehouse.Domain.Context;
using EnterpriseWarehouse.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<WarehouseContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 39))));

builder.Services.AddScoped<OrganizationRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CellRepository>();
builder.Services.AddScoped<SupplyRepository>();


builder.Services.AddScoped<OrganizationService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CellService>();
builder.Services.AddScoped<SupplyService>();
builder.Services.AddScoped<QueryService>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
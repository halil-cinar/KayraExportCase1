using KayraExportCase1.DataAccess.Context;
using KayraExportCase1.Domain;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped(typeof(KayraExportCase1.DataAccess.Abstract.IRepository<>), typeof(KayraExportCase1.DataAccess.Abstract.EfGenericRepositoryBase<>));
builder.Services.AddScoped<KayraExportCase1.Business.Abstract.IProductService, KayraExportCase1.Business.Services.ProductService>();

var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);
AppSettings.Initialize(appSettings);
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

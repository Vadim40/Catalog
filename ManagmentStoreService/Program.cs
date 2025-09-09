using dotenv.net;
using ManagmentStoreService.Services;
using ManagmentStoreService.Services.Impl;
using Microsoft.EntityFrameworkCore;
using ManagmentStoreService.Config;
using EntityFramework.Exceptions.Sqlite;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Client", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular dev server
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // if using cookies/auth
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<ICloudinaryService, CloudinaryServiceImpl>();
builder.Services.AddScoped<IPhoneService, PhoneServiceImpl>();
builder.Services.AddScoped<IHeadphoneService, HeadphonesServiceImpl>();
builder.Services.AddScoped<IItemService, ItemServiceImpl>();
builder.Services.AddScoped<IManufacturerService, ManufacturerServiceImpl>();
builder.Services.AddScoped<IColorService, ColorServiceImpl>();
DotEnv.Load();
builder.Services.AddDbContext<ManagStoreDbContext>(options =>
    options.UseSqlite("Data Source=catalog.db")
    .UseExceptionProcessor());
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Client");
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.UseExceptionHandler();
app.Run();



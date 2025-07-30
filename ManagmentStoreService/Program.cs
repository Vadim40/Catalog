using dotenv.net;
using ManagmentStoreService.Services;
using ManagmentStoreService.Services.Impl;
using Microsoft.EntityFrameworkCore;
using ManagmentStoreService.Config;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICloudinaryService, CloudinaryServiceImpl>();
builder.Services.AddScoped<IPhoneService, PhoneServiceImpl>();
builder.Services.AddScoped<IHeadphoneService, HeadphonesServiceImpl>();
builder.Services.AddScoped<IItemService, ItemServiceImpl>();
DotEnv.Load();
builder.Services.AddDbContext<ManagStoreDbContext>(options =>
    options.UseSqlite("Data Source=catalog.db"));
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();


app.Run();



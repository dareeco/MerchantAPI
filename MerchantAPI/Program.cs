using MerchantAPI.Database;
using MerchantAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IMerchantRepository, MerchantRepositoryImpl>();
builder.Services.AddDbContext<MerchantDbContext>(opt => opt.UseInMemoryDatabase("MerchantsDB"));


//builder.Services.AddDbContext<MerchantDbContext>(opt =>
//{
  //  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//}); // This is for using Database that is not InMemory
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
  options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
      ); //you need this in order to connect with angular

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using VirtualStore.Controllers;
using VirtualStore.Data;
using VirtualStore.Models;

var builder = WebApplication.CreateBuilder(args);

var MyConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbcontext>(x =>
{
    x.UseSqlServer(MyConnection);
});

 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapSwagger();
}






app.MapControllers();   

app.Run();

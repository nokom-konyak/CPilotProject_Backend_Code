using Microsoft.EntityFrameworkCore;
using Pilot_Project.Model;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//add the DB Context
builder.Services.AddDbContext<PilotProjectDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));
//Enable cors
builder.Services.AddCors(c => c.AddPolicy("MyPolicy", c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V2", new OpenApiInfo { Title = "My Pilot_Project", Version = "V2" });
});
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/V2/swagger.json", "My Pilot_Project V2");
    });
}
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();
app.MapControllers();
app.Run();
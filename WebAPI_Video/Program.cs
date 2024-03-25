using Microsoft.EntityFrameworkCore;
using WebAPI_Video.DataContext;
using WebAPI_Video.Service.FuncionarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFuncionarioInterface,FuncionarioService>(); // Aqui estamos falando pro program Que o IFuncionarioInterface se comunica com o FuncionarioService

//Nesse builder.Services.AddDbContext, estamos falando pra ele qual é nosso AplicationDbContext e falando que options vão usar o SqlServer e com o builder.Configuration.GetConnectionString estamos passando a nossa cstring de conexão que ta no appsettings.json
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

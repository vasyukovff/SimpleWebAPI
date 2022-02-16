using SimpleWebAPI.Repositories;
using SimpleWebAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();

builder.Services.AddSingleton<IVideoGameRepository, VideoGameRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//WebApplicationBuilder.Build

//builder.WebHost.UseStartup<Startup>();

var app = builder.Build();



//CreateHostBuilder(args).Build().Run();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

//Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
//{
//    webBuilder.UseStartup<Startup>();
//});
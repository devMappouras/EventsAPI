using DataAccess.DbAccess;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services;
using EventsAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//lDataAccess DI
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IVenuesRepository, VenuesRepository>();
builder.Services.AddSingleton<IEventsRepository, EventsRepository>();

//Application Services DI
builder.Services.AddTransient<IVenuesService, VenuesService>();
builder.Services.AddTransient<IEventsService, EventsService>();

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

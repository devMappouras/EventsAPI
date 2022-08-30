using DataAccess.DbAccess;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services;
using EventsAPI.Services.Interfaces;
using SectionsAPI.Services.Interfaces;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy => {
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//lDataAccess DI
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IVenuesRepository, VenuesRepository>();
builder.Services.AddSingleton<IEventsRepository, EventsRepository>();
builder.Services.AddTransient<ICollectionsRepository, CollectionsRepository>();
builder.Services.AddTransient<ISectionsRepository, SectionsRepository>();
builder.Services.AddTransient<IOrganisersRepository, OrganisersRepository>();

//Application Services DI
builder.Services.AddTransient<IVenuesService, VenuesService>();
builder.Services.AddTransient<IEventsService, EventsService>();
builder.Services.AddTransient<ICollectionsService, CollectionsService>();
builder.Services.AddTransient<ISectionsService, SectionsService>();
builder.Services.AddTransient<IOrganisersService, OrganisersService>();



var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

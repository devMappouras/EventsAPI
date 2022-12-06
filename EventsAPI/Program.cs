using System.Text;
using DataAccess.DbAccess;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using EventsAPI.Services;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SectionsAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Filters;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();

//Allows to access Authorised User Identifier
builder.Services.AddHttpContextAccessor();

/* REPOSITORY - SERVICES DI */
//lDataAccess DI
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IVenuesRepository, VenuesRepository>();
builder.Services.AddSingleton<IEventsRepository, EventsRepository>();
builder.Services.AddTransient<ICollectionsRepository, CollectionsRepository>();
builder.Services.AddTransient<ISectionsRepository, SectionsRepository>();
builder.Services.AddTransient<IOrganisersRepository, OrganisersRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<ICountriesRepository, CountriesRepository>();
builder.Services.AddTransient<IHierarchiesRepository, HierarchiesRepository>();
builder.Services.AddTransient<ICustomersRepository, CustomersRepository>();

//Application Services DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IVenuesService, VenuesService>();
builder.Services.AddTransient<IEventsService, EventsService>();
builder.Services.AddTransient<ICollectionsService, CollectionsService>();
builder.Services.AddTransient<ISectionsService, SectionsService>();
builder.Services.AddTransient<IOrganisersService, OrganisersService>();
builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<ICountriesService, CountriesService>();
builder.Services.AddTransient<IHierarchiesService, HierarchiesService>();
builder.Services.AddTransient<ICustomersService, CustomersService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Swagger and Swagger Athentication
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy => {
        //policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.UseStaticFiles();
//app.UseRouting();
app.MapControllers();
app.Run();

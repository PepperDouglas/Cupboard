using Cupboard.Contexts;
using Cupboard.Repository.Interfaces;
using Cupboard.Repository.Repos;
using Cupboard.Services.Interfaces;
using Cupboard.Services.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddDbContext<CupboardContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("HousingDB"))
);

builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUserService, UserService>();

//builder.Services.AddTransient<IApartmentRepo, ApartmentRepo>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

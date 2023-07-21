using AutoMapper;
using Manager.API.ViewModels;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Manager.Infra.Repositories;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Services.Services;
using Microsoft.EntityFrameworkCore;


var autoMapperConfig = new MapperConfiguration(cfg =>

    {
        cfg.CreateMap<User, UserDTO>().ReverseMap();
        cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
        cfg.CreateMap<UpdateViewModel, UserDTO>().ReverseMap();
    }
);

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(d => builder.Configuration);
builder.Services.AddDbContext<ManagerContext>(
    options => options.UseSqlServer(builder.Configuration["ConnectionStrings:USER_MANAGER"]), ServiceLifetime.Transient);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());


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

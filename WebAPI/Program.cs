using Business.Abstract;
using Business.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IOC Container

builder.Services.AddDbContext<TrainContext>();
builder.Services.AddScoped<ITrainDal, TrainDal>();
builder.Services.AddScoped<IVagonDal, VagonDal>();

builder.Services.AddScoped<ITrainService, TrainService>();
builder.Services.AddScoped<IVagonService, VagonService>();

builder.Services.AddScoped<IReservationService, ReservationService>();

var context = new TrainContext();
context.Trains.AddRange(
    new() { Id = 1, CreateDate = DateTime.Now, Name = "Baþkent Express", Vagons = new() },
    new() { Id = 2, CreateDate = DateTime.Now, Name = "YHT", Vagons = new() }
    );
context.Vagons.AddRange(
    new() { Id = 1, Name = "Vagon 1", Capacity = 100, RentedSeatCount = 68, TrainId = 1 },
    new() { Id = 2, Name = "Vagon 2", Capacity = 90, RentedSeatCount = 50, TrainId = 1 },
    new() { Id = 3, Name = "Vagon 3", Capacity = 80, RentedSeatCount = 80, TrainId = 1 }
    );
context.SaveChanges();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

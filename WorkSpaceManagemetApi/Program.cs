using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<WsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringForRooms"), sqlServerOptionsAction: sqlOptions =>
{
    sqlOptions.EnableRetryOnFailure();
}));
builder.Services.AddScoped<IEmployee, EmployeeRepo>();
builder.Services.AddScoped<ILocation, LocationRepo>();
builder.Services.AddScoped<IEvent, EventRepo>();
builder.Services.AddScoped<INotification, NotificationRepo>();
builder.Services.AddScoped<IDeskBooking, DeskBookingRepo>();
builder.Services.AddScoped<IRoomBooking, RoomBookingRepo>();
builder.Services.AddScoped<IRoomDetail, RoomDetailRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Mappings;
using Hospital_Management_System.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HospitalManagmentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HMSConnectionString")));
builder.Services.AddScoped<IDoctorRepository, SqlDoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, SqlAppointmentRepository>();
builder.Services.AddScoped<IMedicalRecordRepository, SqlMedicalRecordRepository>();
builder.Services.AddScoped<IPatientRepository, SqlPatientRepository>();
builder.Services.AddAutoMapper(typeof(AutomapperProfiles));
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

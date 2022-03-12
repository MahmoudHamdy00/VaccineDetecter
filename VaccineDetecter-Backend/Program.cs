using Microsoft.EntityFrameworkCore;
using VaccineDetecter_Backend.Data;
using VaccineDetecter_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
var myEmail = builder.Configuration["email"];
var myPassword = builder.Configuration["emailpassword"];
var SMTPServerAddress = builder.Configuration["SMTPServerAddress"];
var mailSubmissionPort = Convert.ToInt32(builder.Configuration["mailSubmissionPort"]);
builder.Services.AddTransient<IEmailSenderService, EmailSenderService>(op => new EmailSenderService(myEmail, myPassword, SMTPServerAddress, mailSubmissionPort));
builder.Services.AddTransient<ISavingDataService, SavingDataService>();
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

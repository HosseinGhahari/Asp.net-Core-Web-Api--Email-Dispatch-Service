using EmailSender_Api.Model;
using EmailSender_Api.Service;

var builder = WebApplication.CreateBuilder(args);


// here our MailSettings class take the data from 'MailSettings'
// in appsettings.json to handle the opreations.
// also we have to add our interface and service for IOC concept

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();


// here which is a important part , we define our CORS
// means we restrict all https requests to our api

builder.Services.AddCors(options =>
{
	options.AddPolicy("Allowhost",
		builder => builder.WithOrigins("http://127.0.0.1:5500", "http://127.0.0.1:8080", "https://hosseinghahari.ir")
						  .AllowAnyHeader()
						  .AllowAnyMethod());
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("Allowhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

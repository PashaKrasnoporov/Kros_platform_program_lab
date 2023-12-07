using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(options =>
	{
		options.Authority = builder.Configuration["Auth0:Authority"];
		options.Audience = builder.Configuration["Auth0:Audience"];
	});

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowLocalhost", builder =>
	{
		builder.WithOrigins("http://localhost:3000")
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
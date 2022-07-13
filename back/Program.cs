using back.Hubs;
using back.Services;

var builder = WebApplication.CreateBuilder(args);

#region services
builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddSingleton<ChatManager>();
builder.Services.AddSingleton<UserProfileService>();
builder.Services.AddSingleton<FIleService>();
builder.Services.AddSingleton<JWTService>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<ChatService>();


builder.Services.AddCors(options =>
{
	options.AddPolicy("Development", policy =>
	{
		policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials();
	});
	options.AddPolicy("Production", policy =>
	{
		policy.WithOrigins("http://localhost", "https://localhost")
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials();
	});
});
#endregion

WebApplication app = builder.Build();

Console.WriteLine($"IsDevelopment - {app.Environment.IsDevelopment()}");
if (app.Environment.IsDevelopment())
{
	app.UseCors("Development");
}
else
{
	app.UseCors("Production");
}

app.UseHttpsRedirection();

app.MapHub<ChatHub>("/api/ChatHub");
app.MapControllers();

app.Run();

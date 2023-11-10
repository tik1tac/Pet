using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.ConfigureComparison();
builder.Services.ConfigureProtection();
builder.Services.ConfigureDataBase(builder.Configuration);
builder.Services.ConfigureValidation();
builder.Services.ConfigureException();
builder.Services.ConfigureLogger();
builder.Host.UseSerilog();
builder.Services.ConfigurationAutoMapper();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureMediatR();
builder.Services.ConfigurationEmailService(builder.Configuration);
builder.Services.ConfigureSwagger();

var app = builder.Build();
Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.CreateLogger();
// Configure the HTTP request pipeline.
try
{
	Log.Information("Starting App");

	app.UseMiddleware<ExceptionHandling>();
	app.UseSerilogRequestLogging();
	app.UseStaticFiles();
	app.UseHttpsRedirection();
	app.UseAuthentication();
	app.UseAuthorization();
	app.MapControllers();
	app.UseDeveloperExceptionPage();
	app.UseSwagger();

	app.UseSwaggerUI(
	opt =>
	{
		opt.SwaggerEndpoint("/swagger/MySwagger/swagger.json", "My Api)");
	});
	await app.MigrateDatabase();

	await app.RunAsync();
}
catch (Exception exception)
{
	Log.Fatal(exception, "Server not responding");
}
finally
{
	await Log.CloseAndFlushAsync();
}

using ProjectEstimaterRealTime;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x
       .AllowAnyMethod()
       .AllowAnyHeader()
       .SetIsOriginAllowed(origin => true) // allow any origin
       .AllowCredentials()); // allow credentials
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.MapHub<SignalRHub>("/hub");

app.Run();

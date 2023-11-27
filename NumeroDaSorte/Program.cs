var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
{
    

builder.Services.AddCors(x =>
{
    x.AddPolicy("NumeroSorteCors", config =>
    {
        config.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(x => true)
        .AllowCredentials();
    });
});

builder.Services.AddMemoryCache();

builder.Services.AddHttpClient();
        };

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials
    app.UseSwaggerUI();
    app.UseCors("NumeroSorteCors");
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

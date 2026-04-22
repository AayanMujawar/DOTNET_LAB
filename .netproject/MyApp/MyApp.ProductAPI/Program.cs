var builder = WebApplication.CreateBuilder(args);

// Exp 10: Register In-Memory Caching globally
builder.Services.AddMemoryCache();

// Add controllers
builder.Services.AddControllers();

// Exp 9: Enable CORS so our MVC App can fetch data from this API!
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add Swagger for easy UI testing along with Postman (Exp 9) 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

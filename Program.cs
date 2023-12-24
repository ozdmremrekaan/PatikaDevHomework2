using PatikaAkbank.NETCohorts_Homework1.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseRouting();

app.UseAuthorization();

// Global Loglama Middleware eklemek
app.UseMiddleware<LoggerMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Global Exception Middleware eklemek
app.UseExceptionHandler("/error");
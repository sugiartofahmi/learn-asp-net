using learn_asp_net.Data;
using learn_asp_net.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseMySql(
     mySqlConnection,
      ServerVersion.AutoDetect(mySqlConnection),
       options => options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)
       );
});
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


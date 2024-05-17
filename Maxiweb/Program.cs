using Maxi.Infrastructure.DbContexts;
using Maxi.Infrastructure;
using Maxi.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Maxi.Infrastructure.Common;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationService();

builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//For api integration

builder.Services.AddCors(Options=>
{
    Options.AddPolicy("Custompolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//updata database async

static async void UpdateDatabaseAsync(IHost host)
{
    using(var scope=host.Services.CreateScope())
    {
        var Services=scope.ServiceProvider;

        try
        {
            var context = Services.GetRequiredService<ApplicationDbContext>();

            if(context.Database.IsSqlServer()) 
            {
                context.Database.Migrate();
            }

            await SeedData.SeedDataAsync(context);
        }
        catch (Exception ex)
        {
            var logger=scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Error occoured");
            
        }
    }
}

var app = builder.Build();
UpdateDatabaseAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("Custompolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

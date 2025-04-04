using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Infrastructure;
using Infrastructure;
using Infrastructure.EntityFrameworkDiver;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<FootballContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}
builder.Services.AddDbContext<FootballContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbContext, FootballContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<Manager>), typeof(Repository<Manager>));
builder.Services.AddScoped(typeof(IRepository<Match>), typeof(Repository<Match>));
builder.Services.AddScoped(typeof(IRepository<Player>), typeof(Repository<Player>));
builder.Services.AddScoped(typeof(IRepository<Referee>), typeof(Repository<Referee>));

builder.Services.AddScoped<IDapperStatistics>(provider => new DapperStatistics(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IFootballService<Manager>), typeof(FootballService<Manager>));
builder.Services.AddScoped(typeof(IFootballService<Match>), typeof(FootballService<Match>));
builder.Services.AddScoped(typeof(IFootballService<Player>), typeof(FootballService<Player>));
builder.Services.AddScoped(typeof(IFootballService<Referee>), typeof(FootballService<Referee>));
builder.Services.AddScoped(typeof(IFootballStatisticsService), typeof(FootballStatisticsService));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

CreateDbIfNotExists(app);

app.Run();
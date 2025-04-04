using FootballJob;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHostedService<CronJobService>();

var app = builder.Build();

app.Run();

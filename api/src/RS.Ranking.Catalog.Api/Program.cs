using Microsoft.EntityFrameworkCore;
using RS.Ranking.Catalog.Api.Configurations;
using RS.Ranking.Catalog.Infra.Data.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAppConections(builder.Configuration)
    .AddUseCases()
    .AddAndConfigureControllers();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RankingCatalogDbContext>();    
    db.Database.Migrate();
}

app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

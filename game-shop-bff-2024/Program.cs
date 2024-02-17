using game_shop_bff_2024.Models;
using game_shop_bff_2024.Repository;
using game_shop_bff_2024.Repository.PlayerRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DbContext
builder.Services.AddDbContext<GameShopBFFDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("GameShopBFFDbConnnectionString"));
});
#endregion

#region AddedDbContextWithUserAndRole
builder.Services.AddIdentity<PlayerModel, IdentityRole>()
    .AddEntityFrameworkStores<GameShopBFFDbContext>();
#endregion

#region IdentityPasswordSettingOverride
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 2;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
});
#endregion

#region Dependencys
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();    //Added Because using Identity
app.UseAuthorization();

app.MapControllers();

app.Run();

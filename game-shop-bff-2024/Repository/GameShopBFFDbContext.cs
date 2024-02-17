using game_shop_bff_2024.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace game_shop_bff_2024.Repository
{
    public class GameShopBFFDbContext : IdentityDbContext<PlayerModel>
    {
        public GameShopBFFDbContext(DbContextOptions<GameShopBFFDbContext> options) : base(options)
        {

        }

        public DbSet<PlayerModel> Players { get; set; }
    }
}

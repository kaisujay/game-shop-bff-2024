using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace game_shop_bff_2024.Repository
{
    public class GameShopBFFDbContext : IdentityDbContext
    {
        public GameShopBFFDbContext(DbContextOptions<GameShopBFFDbContext> options) : base(options)
        {

        }
    }
}

using game_shop_bff_2024.Models.Dtos.PlayerDtos;
using Microsoft.AspNetCore.Identity;

namespace game_shop_bff_2024.Repository.PlayerRepository
{
    public interface IPlayerRepository
    {
        Task<string> CreatePlayerAsync(RegisterPlayerDto registerPlayer);
        Task<DisplayPlayerDto> GetPlayerDetailsByUserNameAsync(string userName);
        Task<DisplayPlayerDto> GetPlayerDetailsByIdAsync(string id);
        Task<SignInResult> LogInPlayerAsync(LogInPlayerDto logInPlayer);
        Task LogOutPlayerAsync();
    }
}

using game_shop_bff_2024.Models.Dtos.PlayerDtos;
using game_shop_bff_2024.Models;
using Microsoft.AspNetCore.Identity;

namespace game_shop_bff_2024.Repository.PlayerRepository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly UserManager<PlayerModel> _userManager;
        private readonly SignInManager<PlayerModel> _signInManager;

        public PlayerRepository(UserManager<PlayerModel> userManager, SignInManager<PlayerModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreatePlayerAsync(RegisterPlayerDto registerPlayer) //Return can be "Task<IdentityResult>" also
        {
            var newPlayer = new PlayerModel()
            {
                FirstName = registerPlayer.FirstName,
                LastName = registerPlayer.LastName,
                UserName = registerPlayer.UserName,
                Email = registerPlayer.Email,
                PhoneNumber = registerPlayer.PhoneNumber,
                DateOfBirth = registerPlayer.DateOfBirth,
                Gender = registerPlayer.Gender,
                Country = registerPlayer.Country,
                Language = registerPlayer.Language,
                Disabled = false,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            await _userManager.CreateAsync(newPlayer, registerPlayer.Password);

            var newCreatedPlayerId = newPlayer.Id;
            return newCreatedPlayerId;
        }

        public async Task<DisplayPlayerDto> GetPlayerDetailsByUserNameAsync(string userName)
        {
            var outputPlayerModel = await _userManager.FindByNameAsync(userName);

            var player = new DisplayPlayerDto()
            {
                PlayerId = outputPlayerModel.Id,
                FirstName = outputPlayerModel.FirstName,
                LastName = outputPlayerModel.LastName,
                UserName = outputPlayerModel.UserName,
                Email = outputPlayerModel.Email,
                PhoneNumber = outputPlayerModel.PhoneNumber,
                DateOfBirth = outputPlayerModel.DateOfBirth,
                Gender = outputPlayerModel.Gender,
                Country = outputPlayerModel.Country,
                Language = outputPlayerModel.Language,
                Disabled = outputPlayerModel.Disabled,
                CreatedDate = outputPlayerModel.CreatedDate,
                LastModifiedDate = outputPlayerModel.LastModifiedDate
            };
            return player;
        }

        public async Task<DisplayPlayerDto> GetPlayerDetailsByIdAsync(string id)
        {
            var outputPlayerModel = await _userManager.FindByIdAsync(id);

            var player = new DisplayPlayerDto()
            {
                PlayerId = outputPlayerModel.Id,
                FirstName = outputPlayerModel.FirstName,
                LastName = outputPlayerModel.LastName,
                UserName = outputPlayerModel.UserName,
                Email = outputPlayerModel.Email,
                PhoneNumber = outputPlayerModel.PhoneNumber,
                DateOfBirth = outputPlayerModel.DateOfBirth,
                Gender = outputPlayerModel.Gender,
                Country = outputPlayerModel.Country,
                Language = outputPlayerModel.Language,
                Disabled = outputPlayerModel.Disabled,
                CreatedDate = outputPlayerModel.CreatedDate,
                LastModifiedDate = outputPlayerModel.LastModifiedDate
            };
            return player;
        }

        public async Task<SignInResult> LogInPlayerAsync(LogInPlayerDto logInPlayer)
        {
            var res = await _signInManager.PasswordSignInAsync(logInPlayer.UserName, logInPlayer.Password, false, false);
            return res;
        }

        public async Task LogOutPlayerAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

using game_shop_bff_2024.Models.Dtos.PlayerDtos;
using game_shop_bff_2024.Repository.PlayerRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace game_shop_bff_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePlayerAsync([FromBody] RegisterPlayerDto registerPlayer)
        {
            if (ModelState.IsValid)
            {
                var createdPlayerId = await _playerRepository.CreatePlayerAsync(registerPlayer);
                return StatusCode(201, createdPlayerId);
            }
            return BadRequest();
        }

        [HttpGet("ByUserName/{userName}")]
        public async Task<IActionResult> GetPlayerByUserNameAsync(string userName)
        {
            var player = await _playerRepository.GetPlayerDetailsByUserNameAsync(userName);
            return Ok(player);
        }

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetPlayerByIdAsync(string id)
        {
            var player = await _playerRepository.GetPlayerDetailsByIdAsync(id);
            return Ok(player);
        }

        [HttpPost("LogIn")]  //This need to be a "post" because we are posting UserName and Password to API.
        public async Task<IActionResult> LogInPlayerAsync([FromBody] LogInPlayerDto logInPlayer)
        {
            if (ModelState.IsValid)
            {
                var res = await _playerRepository.LogInPlayerAsync(logInPlayer);
                if (res.Succeeded)
                {
                    return Ok("LogIn Successful");
                }
            }
            return Unauthorized("UserName or Password does not match");
        }

        [HttpPost("LogOut")]
        public async Task LogOutPlayerAsync()
        {
            await _playerRepository.LogOutPlayerAsync();            
        }
    }
}

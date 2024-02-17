using System.ComponentModel.DataAnnotations;

namespace game_shop_bff_2024.Models.Dtos.PlayerDtos
{
    public class LogInPlayerDto
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}

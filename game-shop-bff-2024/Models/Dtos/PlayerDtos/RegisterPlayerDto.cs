using System.ComponentModel.DataAnnotations;

namespace game_shop_bff_2024.Models.Dtos.PlayerDtos
{
    public class RegisterPlayerDto : PlayerDtoBase
    {
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirmed Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmedPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace game_shop_bff_2024.Models.Dtos.PlayerDtos
{
    public class DisplayPlayerDto : PlayerDtoBase
    {
        public string? PlayerId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace game_shop_bff_2024.Models.Dtos.PlayerDtos
{
    public class PlayerDtoBase
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        //[DataType(DataType.EmailAddress)]   //This one for screen DISPLAY
        [EmailAddress] //This is one Validates
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime DateOfBirth { get; set; }
       
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Language is Required")]
        public string? Language { get; set; }

        public bool Disabled { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

    }
}

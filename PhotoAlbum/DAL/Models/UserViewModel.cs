namespace DAL.Models
{
    using DAL;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Пароль должен содержать от 4-х до 10-и символов", MinimumLength = 4)]
        public string Pass { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Pass", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPass { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public byte[] Avatar { get; set; }

        public const int Role = 2;
    }
}
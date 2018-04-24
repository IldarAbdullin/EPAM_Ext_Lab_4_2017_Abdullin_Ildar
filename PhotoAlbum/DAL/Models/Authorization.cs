namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Authorization
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Пароль должен содержать от 4-х до 10-и символов", MinimumLength = 4)]
        public string Pass { get; set; }
    }
}

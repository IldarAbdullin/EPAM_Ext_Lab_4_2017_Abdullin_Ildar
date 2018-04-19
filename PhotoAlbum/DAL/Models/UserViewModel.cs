namespace PhotoAlbum.Models
{
    using DAL;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Pass { get; set; }

        [Required]
        public string UserName { get; set; }

        public const int Role = 2;
    }
}
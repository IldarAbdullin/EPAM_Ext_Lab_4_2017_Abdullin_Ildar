namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Cryptography;
    using System.Text;
    using static Dal;

    public class User
    {
        [Required]
        public int IdUser { get; set; }

        public string UserName { get; set; }

        public byte[] Avatar { get; set; }

    }
}

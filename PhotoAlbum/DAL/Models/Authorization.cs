namespace DAL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Authorization
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}

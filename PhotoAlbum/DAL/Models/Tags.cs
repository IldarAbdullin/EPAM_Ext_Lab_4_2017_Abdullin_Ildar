namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tags
    {
        [Required]
        public int IdTag { get; set; }

        public int IdPhoto { get; set; }

        public string NameTag { get; set; }
    }
}

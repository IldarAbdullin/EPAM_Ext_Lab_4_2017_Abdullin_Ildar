namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Photo
    {
        [Required]
        public int IdPhoto { get; set; }
        public int IdUser { get; set; }
        public byte[] File { get; set; }
        //public Image Img { get; set; }
    }
}

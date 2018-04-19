namespace PhotoAlbum.Models
{
    using System.Drawing;

    public class PhotoViewModel
    {
        public int IdPhoto { get; set; }
        public int IdUser { get; set; }
        public Image Img { get; set; }
    }
}
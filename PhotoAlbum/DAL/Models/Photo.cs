namespace DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Photo
    {
        [Required]
        public int IdPhoto { get; set; }

        public int IdUser { get; set; }

        public byte[] File { get; set; }

        public List<string> Tags { get; set; }
    }
}

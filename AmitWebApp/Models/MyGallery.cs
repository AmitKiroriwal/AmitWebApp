using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmitWebApp.Models
{
    public class MyGallery
    {
        [Key]
        public int Id { get; set; }
        public string GalName { get; set; }
        public string PhotoPath { get; set; }
        public ICollection<GalleryCategory> GalleryCategories { get; set; }
        [ForeignKey("GalleryCategory")]
        public int? categoryId { get; set; }

    }
}

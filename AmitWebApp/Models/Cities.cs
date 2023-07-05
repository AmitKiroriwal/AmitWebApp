using System.ComponentModel.DataAnnotations;

namespace AmitWebApp.Models
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
}

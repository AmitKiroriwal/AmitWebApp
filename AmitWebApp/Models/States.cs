using System.ComponentModel.DataAnnotations;

namespace AmitWebApp.Models
{
    public class States
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
